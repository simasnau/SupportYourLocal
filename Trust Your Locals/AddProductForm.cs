using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ComboBoxHandler.HandleComboBoxWithoutAll(comboBox1);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product product= (Product)Enum.Parse(typeof(Product), comboBox1.SelectedValue.ToString());

            if (float.TryParse(textBox1.Text, out float f))
            {
                SQLConnectionHandler.MakeConnection();
                string query = "INSERT INTO Products ([Shop ID], [Price], [Name], [Product type ID]) VALUES (@id, @price,@name,@pid)";
                using (SqlCommand cmd = new SqlCommand(query, SQLConnectionHandler.GetConnection()))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = LoginStatusHandler.getId(); //Temporary set to Jono Ukis(Id:16) defaut as there is no login system at the moment
                    cmd.Parameters.Add("@price", SqlDbType.Money).Value = textBox1.Text;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = comboBox1.SelectedValue.ToString();
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = (int)product;

                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("You have succesfully added a product!");
                    else
                        // Well this should never really happen
                        MessageBox.Show("No row inserted");
                }

            }
            else MessageBox.Show("Please enter price");


        }
    }
}
