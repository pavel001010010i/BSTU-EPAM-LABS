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
    class PersonalAccountPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//*div[@class='CustomerLayout__quickLinksWrapper']/ul/li[3]/a")]
        private readonly IWebElement ReservationItem;
        public PersonalAccountPage(IWebDriver driver) : base(driver) { }
        public PersonalAccountPage SearchReservationPage()
        {
            ReservationItem.Click();
            return this;
        }
    }
}
