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
    public partial class PlaceOrderForm : Form
    {
        public PlaceOrderForm()
        {
            InitializeComponent();
        }

        public void placeOrder(object sender, EventArgs e)
        {
            SQLConnectionHandler.MakeConnection();
            string query = "INSERT INTO Orders ([Name], [Time], [Quantity], [Buyer ID], [Seller ID]) VALUES (@name, @time, @quantity, @bid, @sid)";
            using (SqlCommand cmd = new SqlCommand(query, SQLConnectionHandler.GetConnection()))
            {
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "Bulves";
                cmd.Parameters.Add("@time", SqlDbType.Time).Value = timeBox.Text;
                cmd.Parameters.Add("@quantity", SqlDbType.Float).Value = float.Parse(quantityBox.Text);
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = 1;

                int rowsAdded = cmd.ExecuteNonQuery();
                if (rowsAdded > 0)
                    MessageBox.Show("You have succesfully placed a product order! rowsAdded:"+rowsAdded);
                else
                    // Well this should never really happen
                    MessageBox.Show("No row inserted");
            }
        }


        
    }
}
