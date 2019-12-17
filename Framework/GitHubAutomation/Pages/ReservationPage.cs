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
    public class ReservationPage : WaitingItemLoad
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'Cancel Reservation')]")]
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
            WaitWebElementLoad(driver, 10, By.XPath("//li[contains(text(),'Cancel Reservation')]"));
            selectCancelReservation.Click();
            return new ReservationСancellationPage(driver);
        }
    }

}
