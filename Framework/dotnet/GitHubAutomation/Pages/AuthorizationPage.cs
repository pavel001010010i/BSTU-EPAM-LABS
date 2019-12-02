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
using GitHubAutomation.Pages;
using GitHubAutomation.Model;
using GitHubAutomation.Service;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Pages
{
    class AuthorizationPage
    {
        IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "LoginButton__circle")]
        private readonly IWebElement SignInToYourAccount;

        [FindsBy(How = How.CssSelector, Using = "UserDetails__link")]
        private readonly IWebElement AccountOpen;

        [FindsBy(How = How.ClassName, Using = "floatl__input")]
        private readonly IWebElement InputLogin;

        [FindsBy(How = How.ClassName, Using = "floatl__input")]
        private readonly IWebElement InputPassword;
        public AuthorizationPage(IWebDriver driver) 
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public MainPage FillLogin(User user)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("floatl__input")));
            InputLogin.SendKeys(user.Login + Keys.Enter);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("floatl__input")));
            InputPassword.SendKeys(user.Password + Keys.Enter);
            return new MainPage(driver);
        }
    }
}
