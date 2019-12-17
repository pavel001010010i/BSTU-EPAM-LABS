using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Framework.driver;
using Framework.Pages;
using Framework.Tests;
using Framework.Model;
using Framework.Service;
using Framework.Utils;

namespace Framework.Pages
{
    public class AuthorizationPage : WaitingItemLoad
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email']")]
        private readonly IWebElement InputLogin;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        private readonly IWebElement InputPassword;

        public AuthorizationPage(IWebDriver driver) 
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public MainPage FillLogin(User user)
        {
            WaitWebElementLoad(driver, 10, By.XPath("//input[@placeholder='Email']"));
            InputLogin.SendKeys(user.Login + Keys.Enter);
            WaitWebElementLoad(driver, 10, By.XPath("//input[@placeholder='Password']"));
            InputPassword.SendKeys(user.Password + Keys.Enter);
            Thread.Sleep(3000);
            return new MainPage(driver);
        }
    }
}
