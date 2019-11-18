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
    class ReservationСancellationPage : Page
    {
        [FindsBy(How = How.CssSelector, Using = "//ul[@class='ReservationDetailsView__actions']/li[2]")]
        private readonly IWebElement SelectCancelReservation;

        [FindsBy(How = How.ClassName, Using = "Button__buttonContent")]
        public IWebElement СonfirmationСancellation { get; private set; }

        public ReservationСancellationPage(IWebDriver driver) : base(driver) { }

        public ReservationСancellationPage CancelReservations()
        {
            SelectCancelReservation.Click();
            return this;
        }
    }
}
