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
    public class MainPage : WaitingItemLoad
    {
        IWebDriver driver;
        private readonly string Url = "https://www.sixt.com/#/";

        [FindsBy(How = How.XPath, Using = "//div[@class='ErrorMessage__message']")]
        public IWebElement selectError { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='DayPicker-Day DayPicker-Day--isDisabled'][contains(text(),'14')]")]
        public IWebElement dayPicker { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='Button__toggleLarge Button__button 1200px']")]
        private readonly IWebElement buttonShower;

        [FindsBy(How = How.XPath, Using = "//section[@class='section bg-dark location-map']//div//img[@class='lazy fade-in']")]
        private readonly IWebElement buttonFinaAllLocattion;

        [FindsBy(How = How.XPath, Using = "//div[@class='DayPicker-Day'][contains(text(),'13')]")]
        private readonly IWebElement pickupDateReservation;

        [FindsBy(How = How.XPath, Using = "//div[@class='DayPicker-Day'][contains(text(),'15')]")]
        private readonly IWebElement pickupDateDeliveries;

        [FindsBy(How = How.XPath, Using = "//input[@id='pickupStation']")]
        private readonly IWebElement pickupStation;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'DateButton__horizontal DateButton__wrapper')]")]
        private readonly IWebElement pickupDateButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='pickupStation']")]
        private readonly IWebElement searchInputCountry;

        [FindsBy(How = How.XPath, Using = "//div[@class='ListItems__listItem groupedListItem ListItems__listItemSelected']")]
        private readonly IWebElement searchInputCountryItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='ListItems__listItem groupedListItem ListItems__listItemSelected']")]
        private readonly IWebElement selectFromList;

        [FindsBy(How = How.XPath, Using = "//div[@class='dark LoginButton__wrapper']")]
        private readonly IWebElement signInToYourAccount;

        [FindsBy(How = How.XPath, Using = "//div[@class='UserDetails__link']//span[contains(text(),'Account')]")]
        private readonly IWebElement accountOpen;

        public MainPage(IWebDriver driver) 
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            driver.Navigate().GoToUrl(Url);
        }

        public MainPage SearchInputCountrySendKeys(CountryModel countryModel)
        {
            WaitWebElementLoad(driver, 10, By.XPath("//input[@id='pickupStation']"));
            searchInputCountry.SendKeys(countryModel.Country);
            searchInputCountry.Click();
            return new MainPage(driver);
        }

        public MainPage SearchInputCountryItemClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='ListItems__listItem groupedListItem ListItems__listItemSelected']"));
            searchInputCountryItem.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='ErrorMessage__message']"));
            return new MainPage(driver);
        }


        public AuthorizationPage EntranceProfile()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='dark LoginButton__wrapper']"));
            signInToYourAccount.Click();
            return new AuthorizationPage(driver);
        }
        public PersonalAccountPage EntranceProfileAcc()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='dark LoginButton__wrapper']"));
            signInToYourAccount.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='UserDetails__link']//span[contains(text(),'Account')]"));
            accountOpen.Click();
            return new PersonalAccountPage(driver);
        }


        public MainPage PickupStationSendKeysAndClick(CountryModel countryModel)
        {
            WaitWebElementLoad(driver, 10, By.XPath("//input[@id='pickupStation']"));
            pickupStation.SendKeys(countryModel.CountryBelarus);
            pickupStation.Click();
            return new MainPage(driver);
        }

        public MainPage SelectFromListClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='ListItems__listItem groupedListItem ListItems__listItemSelected']"));
            selectFromList.Click();
            return new MainPage(driver);
        }

        public MainPage PickupDateButtonClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(@class,'DateButton__horizontal DateButton__wrapper')]"));
            pickupDateButton.Click();
            return new MainPage(driver);
        }

        public MainPage WaitPickupDateEnabled()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='DayPicker-Day DayPicker-Day--isDisabled'][contains(text(),'14')]"));
            return new MainPage(driver);
        }

        public MainPage PickupDateReservationClick()
        {
            WaitWebElementLoad(driver, 100, By.XPath("//div[contains(@class,'DayPicker-wrapper')]//div[1]//div[2]//div[1]//div[1]"));
            pickupDateReservation.Click();
            return new MainPage(driver);
        }

        public MainPage PickupDateDeliveriesClick()
        {
            pickupDateDeliveries.Click();
            return new MainPage(driver);
        }

        public CarRent ButtonShowerClick()
        {
            buttonShower.Click();
            return new CarRent(driver);
        }

        public RepresentativeInTheCountryPage FindLocation()
        {
            WaitWebElementLoad(driver, 100, By.XPath("//section[@class='section bg-dark location-map']//div//img[@class='lazy fade-in']"));
            buttonFinaAllLocattion.Click();
            return new RepresentativeInTheCountryPage(driver);
        }

    }
}
