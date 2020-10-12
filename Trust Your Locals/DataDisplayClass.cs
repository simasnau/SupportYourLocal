using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Trust_Your_Locals
{
    public class DataDisplayClass
    {
        private ComboBox cb;
        private DataGridView dgv;


        public DataDisplayClass(ComboBox cb, DataGridView dgv){
            this.cb = cb;
            this.dgv = dgv;
        }

        
        public void updateDataGridView()
        {
            string product = "'" + cb.SelectedValue.ToString() + "'";
            string sqlQuery = "SELECT Name, Price, \"Name:\", \"Adress:\" FROM Products, Seller WHERE \"Shop ID\"=ID";
            if (product != "'Visi'") sqlQuery += " AND Name=" + product;

            DataTable dt = new DataTable();
            SQLConnectionHandler.MakeConnection();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, SQLConnectionHandler.GetConnection());
            da.Fill(dt);
            dgv.DataSource = dt;


        }

        public void getAdress(TextBox textBox, DataGridViewCellEventArgs eArgs)
        {
            try
            {
                dgv.CurrentRow.Selected = true;
                textBox.Text = dgv.getSelectedCellAdress(eArgs);

            }
            catch (ArgumentOutOfRangeException)
            { }
        }

    }
}
