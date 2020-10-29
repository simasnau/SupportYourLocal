using System;
using System.IO;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public static class MapHandler
    {
        public static void showAdress(WebBrowser webBrowser)
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
