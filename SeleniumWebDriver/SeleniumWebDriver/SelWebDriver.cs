using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using SeleniumWebDriver;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestFixture]
    public abstract class TrainpalWebTests
    {
        protected IWebDriver Browser;
        [SetUp]
        public void StartBrowserChrome()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://www.sixt.com/#/");
        }

        [TearDown]
        public void QuitDriver()
        {
            Browser.Quit();
            Browser.Dispose();
        }
    }
}