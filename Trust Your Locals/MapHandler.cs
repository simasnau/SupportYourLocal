using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
                if (adresas != string.Empty)
                {
                    StringBuilder queryaddress = new StringBuilder();
                    queryaddress.Append("http://maps.google.com/maps/search/");
                    queryaddress.Append(adresas + "," + "+");
                    webBrowser.Navigate(queryaddress.ToString());                 
                }
                else {
                    string path = Directory.GetCurrentDirectory();
                    webBrowser.Navigate(new System.Uri(path + "\\index.html"));
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }


    }
}
