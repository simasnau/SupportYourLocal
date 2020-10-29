using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public partial class PlaceOrderForm : Form
    {
        private string productName;
        private string adress;


        public PlaceOrderForm(string productName, string adress)
        {
            InitializeComponent();
            this.productName=productName;
            this.adress=adress;
        }

        public void placeOrder(object sender, EventArgs e)
        {
            if (Regex.IsMatch(timeBox.Text, @"^[0-2]\d:[0-5]\d$"))
            {
                SQLConnectionHandler.MakeConnection();
                string sqlQuery = "SELECT ID FROM Seller WHERE Adress= @adress";
                SqlCommand cmd = new SqlCommand(sqlQuery, SQLConnectionHandler.GetConnection());
                cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = adress;
                string sellerID = cmd.ExecuteScalar().ToString();


                string query = "INSERT INTO Orders ([Name], [Time], [Quantity], [Buyer ID], [Seller ID]) VALUES (@name, @time, @quantity, @bid, @sid)";
                using (cmd = new SqlCommand(query, SQLConnectionHandler.GetConnection()))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = productName;
                    cmd.Parameters.Add("@time", SqlDbType.Time).Value = timeBox.Text;
                    cmd.Parameters.Add("@quantity", SqlDbType.Float).Value = quantityBox.Text;
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = LoginStatusHandler.getId();
                    cmd.Parameters.Add("@sid", SqlDbType.Int).Value = sellerID;
                    try
                    {
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0) MessageBox.Show("You have succesfully placed a product order!");
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Wrong time entered");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Wrong quantity entered");
                    }

                }
                this.Close();
            }
            else MessageBox.Show("Wrong time entered");
                        
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
