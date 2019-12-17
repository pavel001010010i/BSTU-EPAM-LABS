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
using Framework.Model;
using Framework.Utils;

namespace Framework.Pages
{
    public class ProfilesPage : WaitingItemLoad
    {
        IWebDriver driver;


        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Profile Name')]")]
        private readonly IWebElement profileName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Email')]")]
        private readonly IWebElement fieldEmail;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'Dialog__headLine')]")]
        private readonly IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='Button__buttonContent']")]
        private readonly IWebElement buttonAddProfile;
        public ProfilesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public string ErrorMessage()
        {
            return errorMessage.Text;
        }
        public ProfilesPage ProfileNameSendKeys(User user)
        {
            WaitWebElementLoad(driver, 10, By.XPath("//input[contains(@placeholder,'Profile Name')]"));
            profileName.SendKeys(user.UserName);
            return new ProfilesPage(driver);
        }

        public ProfilesPage FieldEmailSendKeys(User user)
        {
            fieldEmail.SendKeys(user.NewEmail);
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(@class,'Button__buttonContent')]"));
            return new ProfilesPage(driver);
        }
        public ProfilesPage ButtonAddProfileClick()
        {
            buttonAddProfile.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(@class,'Dialog__headLine')]"));
            return new ProfilesPage(driver);
        }
    }
}
