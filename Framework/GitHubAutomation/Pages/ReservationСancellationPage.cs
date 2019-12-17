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
    public class ReservationСancellationPage
    {
        IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//ul[@class='ReservationDetailsView__actions']/li[2]")]
        private readonly IWebElement selectCancelReservation;

        [FindsBy(How = How.ClassName, Using = "Button__buttonContent")]
        public IWebElement СonfirmationСancellation { get; set; }

        public ReservationСancellationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
    }
}
