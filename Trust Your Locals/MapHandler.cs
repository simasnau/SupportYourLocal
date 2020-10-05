using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public class MapHandler
    {
        private WebBrowser webBrowser;
        public MapHandler(WebBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
        }

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
