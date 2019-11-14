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
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObject
{
    public class Page
    {
        protected DefaultWait<IWebDriver> fluentWait;
        protected IWebDriver driver;
        protected static int timeoutInSeconds = 30;
        public IWebElement СonfirmationСancellation { get; private set; }
        public IWebElement SelectError { get; private set; }
        protected readonly IWebElement LogIn;
        protected readonly IWebElement SearchInputCountry;
        protected readonly IWebElement InputLogin;
        protected readonly IWebElement InputPassword;
        protected readonly IWebElement SignInToYourAccount;
        protected readonly IWebElement AccountOpen;
        protected readonly IWebElement ReservationItem;
        protected readonly IWebElement SubmitBookingButton;
        protected readonly IWebElement SelectCancelThisBooelectCancelRking;
        protected readonly IWebElement Seservation;

        [Obsolete]
        public Page(IWebDriver driver)
        {
            fluentWait = GetFluentWait(driver);
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [Obsolete]
        private static ReadOnlyCollection<IWebElement> WaitForElement(IWebDriver webDriver, By by)
        {
            return (new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by)));
        }

        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(50);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }
    }
}
