using System;
using System.Collections;
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
            dataDisplay = new DataDisplayClass(comboBox1, dgv);
            if (LoginStatusHandler.isLogged()==true)
            {
                navigate_button.Hide();
                button1.Hide();
            }
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
            dataDisplay.getAdress(textBox:txt_pavadinimas, eArgs:e);
        }

        private void pavadinimas_button_Click(object sender, EventArgs e)
        {
            WriteCoordsToFile();
            MapHandler mapHandler = new MapHandler(webBrowser1);
            mapHandler.showAdress(txt_pavadinimas.Text);
        }


        private void WriteCoordsToFile()
        {
            string requestUri;
            WebRequest request;
            WebResponse response;
            ArrayList pinList= new ArrayList();
            ArrayList adressList = new ArrayList();
            StreamWriter file = new StreamWriter("locations.js");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string name=row.Cells["Name:"].Value.ToString();
                string adress = row.Cells["Adress:"].Value.ToString();

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
                    Pin pin = new Pin(name, lat.Value, lng.Value);
                    pinList.Add(pin);
                }
                
                
            }
            file.Write("locations=[");
            foreach(Pin pin in pinList)
            {
                file.Write("[\""+pin.name+"\","+pin.lat+","+pin.lng+"],");
            }
            file.Write("[]]");

            file.Close();
        }

        private void navigate_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 form3 = new Form3();
            form3.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }
    }
}


