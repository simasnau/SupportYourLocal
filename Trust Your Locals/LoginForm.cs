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
    public partial class LoginForm : Form
    {
        
        public LoginForm()
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

            SQLConnectionHandler.MakeConnection();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID FROM Seller WHERE [Email]='" + textBox1.Text + "' AND [Password]='" + maskedTextBox1.Text + "'", SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Visible = false;
                string id = dt.Rows[0][0].ToString();
                MessageBox.Show("Successful log in");
                LoginStatusHandler.loggedIn(Int16.Parse(id));
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Invalid username or password");


        }
    }
}
