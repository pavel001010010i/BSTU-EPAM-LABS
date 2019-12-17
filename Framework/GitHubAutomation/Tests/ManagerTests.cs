using System;
using System.IO;
using Framework.driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;
using Framework.Utils;
using Framework.Pages;
using log4net;
using log4net.Config;

namespace Framework.Tests
{
    public class ManagerTests : Logger
    {
        public IWebDriver driver;

        [SetUp]
        public void Setter()
        {
            Logger.Log.Warn("Start driver initializing.");
            driver = DriverSingleton.GetInstance();
            Logger.Log.Info("Driver initialized.");
            
        }

        [TearDown]
        public void ClearDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                Logger.WhenTestSuccess();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure||
                TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                Logger.WhenTestFails();
                ScreenshotCreater.SaveScreenShot();
            }
            DriverSingleton.CloseBrowser();
        }
    }
}
