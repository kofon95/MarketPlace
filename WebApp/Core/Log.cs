using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace WebApp.Core
{
    public static class Log
    {
        private static readonly ILog Logger = LogManager.GetLogger("main");
        private const string Format = "args: {0}";

        public static void T(string message)
        {
            Logger.Debug(message);
        }
        public static void T(string message, params object[] args)
        {
            Logger.DebugFormat("");
        }

        public static void D(string message)
        {
            Logger.Debug(message);
        }

        public static void D(string message, params object[] args)
        {
            Logger.DebugFormat(Format, args);
        }

        public static void I(string message)
        {
            Logger.Info(message);
        }
        public static void I(string message, params object[] args)
        {
            Logger.InfoFormat(Format, message);
        }

        public static void W(string message)
        {
            Logger.Warn(message);
        }
        public static void W(string message, params object[] args)
        {
            Logger.WarnFormat(Format, message);
        }
        public static void E(string message)
        {
            Logger.Error(message);
        }
        public static void E(string message, params object[] args)
        {
            Logger.ErrorFormat(Format, message);
        }
    }
}