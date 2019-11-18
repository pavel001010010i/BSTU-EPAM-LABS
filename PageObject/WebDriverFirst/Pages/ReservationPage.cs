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
    class ReservationPage: Page
    {
        [FindsBy(How = How.ClassName, Using = "ReservationItem__optionsLinkLabel")]
        private readonly IWebElement SelectCancelThisBooking;

        public ReservationPage(IWebDriver driver) : base(driver) { }

        public ReservationPage ReservationManipulation()
        {
            SelectCancelThisBooking.Click();
            return this;
        }
        
    }
}
