using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public static class LoginStatusHandler
    {
        static Boolean isLoggedIn = false;
        static int loggedId;

        public static void loggedIn(int loggedIdparam)
        {
            isLoggedIn = true;
            loggedId = loggedIdparam;
        }

        public static void logOut()
        {
            isLoggedIn = false;
        }

        public static Boolean isLogged()
        {
            return isLoggedIn;
        }

        public static int getId ()
        {
            return loggedId;
        }
    }
}
