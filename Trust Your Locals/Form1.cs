﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Trust_Your_Locals
{
    public partial class Form1 : Form
    {
        private DataDisplayClass dataDisplay;
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            signOut_Button.Hide();
            if (LoginStatusHandler.isLogged() == true)
            {

                navigate_button.Hide();
                button1.Hide();
                signOut_Button.Show();
            }
            dataDisplay = new DataDisplayClass(comboBox1, dgv);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBoxHandler.HandleComboBox(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataDisplay.updateDataGridView();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv.CurrentRow.Selected = true;
        }

        private void pavadinimas_button_Click(object sender, EventArgs e)
        {
            WriteCoordsToFile();
            MapHandler.showAdress(webBrowser1);
        }

        private void WriteCoordsToFile()
        {
            string requestUri;
            WebRequest request;
            WebResponse response;
            List<Pin> pinList= new List<Pin>();
            List<string> adressList = new List<string>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string name=row.Cells["Seller name"].Value.ToString();
                string adress = row.Cells["Adress"].Value.ToString();

                if (!adressList.Contains(adress))
                {
                    adressList.Add(adress);
                    requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(adress), API_keys.api_key);
                    request = WebRequest.Create(requestUri);
                    response = request.GetResponse();

                    XDocument xdoc = XDocument.Load(response.GetResponseStream());
                    XElement locationElement = xdoc.Element("GeocodeResponse").Element("result").Element("geometry").Element("location");
                    XElement lat = locationElement.Element("lat");
                    XElement lng = locationElement.Element("lng");

                    Pin pin = new Pin
                    {
                        Name = name,
                        Lat = lat.Value,
                        Lng = lng.Value
                    };
                    pinList.Add(pin);
                }
               
            }

            WritePinsToFile(pinList, new StreamWriter("locations.js"));
        }

        private void navigate_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            LoginForm form3 = new LoginForm();
            form3.Show();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            if (LoginStatusHandler.isLogged() == false)
            {
                this.Visible = false;
                LoginForm form3 = new LoginForm();
                form3.Show();
            }
            else
            {
                if (dgv.CurrentRow.Selected)
                {
                    string name = dgv.getSelectedCellValue("Name");
                    string adress = dgv.getSelectedCellValue("Adress");

                    if (LoginStatusHandler.getId().ToString().Equals(SQLConnectionHandler.getSellerIdByAdress(adress)) == false)
                    {
                        PlaceOrderForm placeOrderForm = new PlaceOrderForm(adress: adress, productName: name);
                        placeOrderForm.Show();
                    }
                    else MessageBox.Show("You cant order products from your own shop.");
                    
                }
                else MessageBox.Show("Please select product to order");
            }
        }
        private void viewOrdersClick(object sender, EventArgs e)
        {
            OrderViewForm orderViewForm;

            if (LoginStatusHandler.isLogged()) orderViewForm = new OrderViewForm(LoginStatusHandler.getId());
            else orderViewForm = new OrderViewForm();
            orderViewForm.Show();

        }

        private void rateButton_Click(object sender, EventArgs e)
        {
            if (LoginStatusHandler.isLogged() == false)
            {
                this.Visible = false;
                LoginForm form3 = new LoginForm();
                form3.Show();
            }
            else
            {
                RatingForm form_Rate = new RatingForm();
                form_Rate.ShowDialog();
            }
        }

        private void signOut_Button_Click(object sender, EventArgs e) 
        {
            LoginStatusHandler.logOut();
            Form1 nala = new Form1();
            nala.Show();
            this.Hide();
            MessageBox.Show("You have been successfully signed out");
        }

        private void addProduct_Button_Click(object sender, EventArgs e)
        {
            if (LoginStatusHandler.isLogged() == false)
            {
                this.Visible = false;
                LoginForm form3 = new LoginForm();
                form3.Show();
            }
            else
            {
                AddProductForm productForm = new AddProductForm();
                productForm.Show();
                this.Visible = false;
            }
        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void WritePinsToFile(List<Pin> pinList, StreamWriter file)
        {
            file.Write("locations=[");
            foreach (Pin pin in pinList)
            {
                file.Write("[\"" + pin.Name + "\"," + pin.Lat + "," + pin.Lng + "],");
            }
            file.Write("[]]");

            file.Close();
        }
    }
}