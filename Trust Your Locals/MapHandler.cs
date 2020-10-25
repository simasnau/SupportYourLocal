using System;
using System.IO;
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
                string path = Directory.GetCurrentDirectory();
                webBrowser.Navigate(new Uri(path + "\\index.html"));
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }


    }
}
