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
    class ReservationPage
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "//ul[@class='ReservationDetailsView__actions']/li[2]")]
        private readonly IWebElement selectCancelReservation;

        [FindsBy(How = How.ClassName, Using = "ReservationItem__optionsLinkLabel")]
        private readonly IWebElement SelectCancelThisBooking;

        public ReservationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public ReservationСancellationPage CancelReservations()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@class='ReservationDetailsView__actions']/li[2]")));
            selectCancelReservation.Click();
            return new ReservationСancellationPage(driver);
        }
    }

}
