using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Trust_Your_Locals
{
    public partial class Form3 : Form
    {

        int ix = 0;

        public Form3()
        {
            InitializeComponent();
            fillCombo(comboBox2);
        }
        void fillCombo(ComboBox cb)
        {
            
            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT \"Name:\" FROM Seller";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "Name:";
            cb.ValueMember = "Name:";
            cb.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

     
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }
        
        private void addRating(String name, String comment, int star)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            if ( checkedListBox1.CheckedItems.Count != 0)
            {//string s;
                
               // String m = comboBox2.SelectedItem.ToString();
               // MessageBox.Show(m); 
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                      //  addRating( , , i);
                    }
                }

                Close();
            }
            else
            { MessageBox.Show("Please choose a rating"); }
            // DialogResult dr = MessageBox.Show("Rating added");
            Form3 Form_3 = new Form3();

        }
    }
}
