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


        [FindsBy(How = How.ClassName, Using = "//*/div/div/input")]
        private readonly IWebElement InputLogin;

        [FindsBy(How = How.XPath, Using = "//*/div[1]/div/input")]
        private readonly IWebElement InputPassword;
        public AuthorizationPage(IWebDriver driver) 
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public MainPage FillLogin(User user)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*/div/div/input")));
            InputLogin.SendKeys(user.Login + Keys.Enter);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*/div[1]/div/input")));
            InputPassword.SendKeys(user.Password + Keys.Enter);
            return new MainPage(driver);
        }
    }
}
