using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using PageObject;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class AuthorizationPage : Page
    {
        [FindsBy(How = How.ClassName, Using = "floatl__input")]
        private readonly IWebElement InputLogin;

        [FindsBy(How = How.ClassName, Using = "floatl__input")]
        private readonly IWebElement InputPassword;
        public AuthorizationPage(IWebDriver driver) : base(driver) { }

        public AuthorizationPage FillLogin(string text)
        {
            InputLogin.SendKeys(text);
            return this;
        }

        public AuthorizationPage FillPass(string text)
        {
            InputPassword.SendKeys(text);
            return this;
        }
    }
}
