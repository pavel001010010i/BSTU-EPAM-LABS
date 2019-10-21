using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Tests;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver
{
    public static class FindElement
    {
        public static IWebElement Element(this IWebDriver driver, By by, int timeoutInSeconds)
        {

            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
