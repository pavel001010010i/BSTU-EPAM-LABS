using System;
using System.IO;
using GitHubAutomation.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    public class ScreenShotsErrorTest
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setter()
        {
            Driver = DriverSingle.GetInstance();
        }

        protected void MakeScreenshotWhenFail(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                DateTime time = DateTime.Now;
                string dateToday = "_date_" + time.ToString("yyyy-MM-dd") + "_time_" + time.ToString("HH-mm-ss");
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
             
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + "Exception" + dateToday + ".png",
                    ScreenshotImageFormat.Png);
                throw;
            }
        }

        [TearDown]
        public void ClearDriver()
        {
            DriverSingle.CloseBrowser();
        }
    }
}
