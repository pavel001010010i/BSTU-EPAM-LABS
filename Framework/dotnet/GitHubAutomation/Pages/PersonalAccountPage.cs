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

namespace GitHubAutomation.Pages
{
    class PersonalAccountPage
    {
        IWebDriver driver;
        [FindsBy(How = How.ClassName, Using = "ReservationItem__optionsLinkLabel")]
        private readonly IWebElement SelectCancelThisBooking;

        [FindsBy(How = How.XPath, Using = "//*div[@class='CustomerLayout__quickLinksWrapper']/ul/li[3]/a")]
        private readonly IWebElement ReservationItem;
        public PersonalAccountPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        
        public ReservationPage ReservationManipulation()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("ReservationItem__optionsLinkLabel")));
            SelectCancelThisBooking.Click();
            return new ReservationPage(driver);
        }
    }
}
