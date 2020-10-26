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
    public partial class Form3 : Form
    {
        public Form3()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
            Form2 form2 = new Form2();
            form2.Show();


            SQLConnectionHandler.MakeConnection();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID FROM Seller WHERE [Email]='" + textBox1.Text + "' AND [Password]='" + maskedTextBox1.Text + "'", SQLConnectionHandler.GetConnection());
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                this.Hide();
                string id = dt.Rows[0][0].ToString();
                MessageBox.Show("Successful log in");
                LoginStatusHandler.loggedIn(Int16.Parse(id));
            }
            else
                MessageBox.Show("Invalid username or password");


        }
    }
}
