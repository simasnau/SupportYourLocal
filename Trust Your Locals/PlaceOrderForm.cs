using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public partial class PlaceOrderForm : Form
    {
        private DataGridView dgv;


        public PlaceOrderForm(DataGridView dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
        }

        public void placeOrder(object sender, EventArgs e)
        {
            String productName = dgv.SelectedRows[0].Cells["Name"].Value.ToString();



            SQLConnectionHandler.MakeConnection();
            string query = "INSERT INTO Orders ([Name], [Time], [Quantity], [Buyer ID], [Seller ID]) VALUES (@name, @time, @quantity, @bid, @sid)";
            using (SqlCommand cmd = new SqlCommand(query, SQLConnectionHandler.GetConnection()))
            {
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = productName;
                cmd.Parameters.Add("@time", SqlDbType.Time).Value = timeBox.Text;
                cmd.Parameters.Add("@quantity", SqlDbType.Float).Value = float.Parse(quantityBox.Text);
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = 1;
                try
                {
                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0) MessageBox.Show("You have succesfully placed a product order!");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Wrong time entered");
                }
                
            }
        }


        
    }
}
