using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public class DataDisplayClass
    {
        
        public DataDisplayClass(ComboBox cb, DataGridView dgv){
            string product = "'" + cb.SelectedValue.ToString() + "'";
            string sqlQuery = "SELECT Name, Price, \"Name:\", \"Adress:\" FROM Products, Seller WHERE \"Shop ID\"=ID";
            if (product != "'Visi'") sqlQuery+= " AND Name="+product;

            DataTable dt = new DataTable();
            SQLConnectionHandler.MakeConnection();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, SQLConnectionHandler.GetConnection());
            da.Fill(dt);
            dgv.DataSource = dt;

        }

    }
}
