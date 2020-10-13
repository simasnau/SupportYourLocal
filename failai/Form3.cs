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
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
          //  checkedListBox1_ItemCheck chbox = new checkedListBox1_ItemCheck();
            //if (chbox.ix != 0)
            //{
            //    MessageBox.Show("Rating added");



            //    Close();
            //}
            //else
            //{ MessageBox.Show("Please choose a rating"); }
            //// DialogResult dr = MessageBox.Show("Rating added");
            //Form3 Form_3 = new Form3();
            //Close();

        }
    }
}
