using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        public void getAdress(TextBox textBox, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgv.CurrentRow.Selected = true;
                    textBox.Text = dgv.Rows[e.RowIndex].Cells["Adress:"].FormattedValue.ToString();
                }
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

    }
}
