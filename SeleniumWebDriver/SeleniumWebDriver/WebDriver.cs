using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumWebDriver
{
    public static class WebDriver
    {
        // Default property 'Enabled' always returns 'true'
        // 'Wait.Until(ExpectedConditions.ElementToBeClickable)' also doesn't help
        public static bool IsEnabled(this IWebElement webElement)
        {
            return webElement.GetAttribute("class").Contains("Button__buttonContent");
        }
    }
}
