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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 form3 = new Form3();
            form3.Show();

            String adress = (textBox2.Text + ", " + textBox3.Text + " " + textBox4.Text);

            SQLConnectionHandler.MakeConnection();
            string query = "INSERT INTO Seller ([Seller name], [Adress], [Password], [Email]) VALUES (@name, @adress,@password,@email)";
            using (SqlCommand cmd = new SqlCommand(query, SQLConnectionHandler.GetConnection()))
            {
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox5.Text;
                cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = adress;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = textBox1.Text;

                int rowsAdded = cmd.ExecuteNonQuery();
                if (rowsAdded > 0)
                {
                    MessageBox.Show("You have succesfully created an account!");
                }
                else
                    // Well this should never really happen
                    MessageBox.Show("No row inserted");


            }
        }
    }
}
