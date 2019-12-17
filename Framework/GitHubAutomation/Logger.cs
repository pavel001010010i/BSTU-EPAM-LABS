using log4net;
using log4net.Config;
using System;
using System.IO;
using Framework.driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.Pages;
using NUnit.Framework.Interfaces;

namespace Framework
{
    public class Logger
    {
        static private ILog log = LogManager.GetLogger(typeof(Logger));

        public static ILog Log
        {
            get { return log; }
        }

        public static void WhenTestFails()
        {
            Log.Error("TTestFails");
        }

        public static void WhenTestSuccess()
        {
            Log.Info("TestSuccess");
        }
    }
}
