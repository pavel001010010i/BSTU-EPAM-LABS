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
    class MainPage : Page
    {
        [FindsBy(How = How.ClassName, Using = "LoginButton__label")]
        private readonly IWebElement LogIn;

        [FindsBy(How = How.ClassName, Using = "LoginButton__circle")]
        private readonly IWebElement SignInToYourAccount;

        [FindsBy(How = How.CssSelector, Using = "UserDetails__link")]
        private readonly IWebElement AccountOpen;
        public MainPage(IWebDriver driver) : base(driver) { }

        public MainPage AuthorizationButton()
        {
            LogIn.Click();
            return this;
        }
        public MainPage EntranceProfile()
        {
            SignInToYourAccount.Click();
            AccountOpen.Click();
            return this;
        }
    }
}
