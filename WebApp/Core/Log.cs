using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bardock.Utils.Logger;

namespace WebApp.Core
{
    public static class Log
    {
        public static void T(string message, params object[] arg)
        {

        }
        public static void D(string message, params object[] arg)
        {

        }
        public static void I(string message, params object[] arg)
        {
            //ConfigSection.Default.CurrentConfiguration.AppSettings.File = "bardock.log";
            LogManager.Default.Factory.GetLog("main").Error("Fuck you logger");
        }
        public static void W(string message, params object[] arg)
        {

        }
        public static void E(string message, params object[] arg)
        {

        }
    }
}