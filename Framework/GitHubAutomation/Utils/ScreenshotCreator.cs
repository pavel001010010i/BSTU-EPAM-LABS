using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;
using Framework.driver;
using NUnit.Framework.Interfaces;

namespace Framework.Utils
{
    public class ScreenshotCreater
    {
        public static void SaveScreenShot()
        {
            Logger.Log.Error("Test failed. Taking screenshot.");
            string screenshotFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screenshots";
            Directory.CreateDirectory(screenshotFolder);
            var screen = DriverSingleton.GetInstance().TakeScreenshot();
            screen.SaveAsFile(screenshotFolder + @"\screenshot" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                ScreenshotImageFormat.Png);
            Logger.Log.Info("Took screenshot.");
        }
    }
}