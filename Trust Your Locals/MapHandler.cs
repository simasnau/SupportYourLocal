using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xamarin.Forms.Maps;

namespace Trust_Your_Locals
{
    public class MapHandler
    {
        private WebBrowser webBrowser;
        public MapHandler(WebBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
        }

  /*      public void pins(String adresas, String pavadinimas)
        {
            Pin pin = new Pin();
            {
                Label = pavadinimas;
                Adress = adresas;
                Type = PinType.Place();
                Position = new Position(adresas);
            }
        }*/

        public void addPin()
            {
     /*       string product = "'" + cb.SelectedValue.ToString() + "'";
            string sqlQuery = "SELECT Name, Price, \"Name:\", \"Adress:\" FROM Products, Seller WHERE \"Shop ID\"=ID";
            if (product != "'Visi'") sqlQuery += " AND Name=" + product;

            DataTable dt = new DataTable();
            SQLConnectionHandler.MakeConnection();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, SQLConnectionHandler.GetConnection());
            da.Fill(dt);
            dgv.DataSource = dt;
       */ }

        public void showAdress(string adresas)
        {
            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("http://maps.google.com/maps/search/");
                if (adresas != string.Empty)
                {
                    queryaddress.Append(adresas + "," + "+");
                }
                webBrowser.Navigate(queryaddress.ToString());
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }


    }
}
