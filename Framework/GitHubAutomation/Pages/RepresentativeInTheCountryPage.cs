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
    public class RepresentativeInTheCountryPage :WaitingItemLoad
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'Sixt locations in Minsk')]")]
        private readonly IWebElement sixLocationsInMinsk;

        [FindsBy(How = How.XPath, Using = "//input[@id='Station_location']")]
        private readonly IWebElement inputStation;

        [FindsBy(How = How.XPath, Using = "//a[@class='city'][contains(text(),'Belarus')]")]
        private readonly IWebElement inputStationItem;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn arrowed orange']")]
        private readonly IWebElement inputStationSearch;

        [FindsBy(How = How.XPath, Using = "//a[@class='city']")]
        private readonly IWebElement inputStationSearchBelarus;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'SEE FULL LIST OF LOCATIONS')]")]
        private readonly IWebElement buttonFullListLocation;

        public string SixLocationsInMinsk()
        {
            return sixLocationsInMinsk.Text;
        }
        public RepresentativeInTheCountryPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public RepresentativeInTheCountryPage InputStationSendKeysAndClick(CountryModel countryModel)
        {
            WaitWebElementLoad(driver, 10, By.XPath("//input[@id='Station_location']"));
            inputStation.SendKeys(countryModel.ChosenCountry);
            inputStation.Click();
            return new RepresentativeInTheCountryPage(driver);
        }

        public RepresentativeInTheCountryPage InputStationItemClick()
        {
            inputStationItem.Click();
            return new RepresentativeInTheCountryPage(driver);
        }

        public RepresentativeInTheCountryPage InputStationSearchClick()
        {
            inputStationSearch.Click();
            return new RepresentativeInTheCountryPage(driver);
        }

        public RepresentativeInTheCountryPage InputStationSendKeysAndClickCity(CountryModel countryModel)
        {
            WaitWebElementLoad(driver, 10, By.XPath("//input[@id='Station_location']"));
            inputStation.SendKeys(countryModel.SelectCity);
            inputStation.Click();
            return new RepresentativeInTheCountryPage(driver);
        }

        public RepresentativeInTheCountryPage InputStationSearchBelarusClick()
        {
            inputStationSearchBelarus.Click();
            inputStationSearch.Click();
            return new RepresentativeInTheCountryPage(driver);
        }

        public RepresentativeInTheCountryPage ButtonFullListLocationClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//span[contains(text(),'SEE FULL LIST OF LOCATIONS')]"));
            buttonFullListLocation.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//h3[contains(text(),'Sixt locations in Minsk')]"));

            return new RepresentativeInTheCountryPage(driver);
        }
    }
}
