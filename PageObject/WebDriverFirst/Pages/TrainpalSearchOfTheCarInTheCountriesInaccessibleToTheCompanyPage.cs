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
    class TrainpalSearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage : Page
    {
        [FindsBy(How = How.ClassName, Using = "SearchInput__isPickupAsReturn")]
        private readonly IWebElement SearchInputCountry;

        [FindsBy(How = How.ClassName, Using = "ErrorMessage__message")] 
        public IWebElement SelectError { get; private set; }

        [Obsolete]
        public TrainpalSearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage(IWebDriver driver) : base(driver) { }

        public TrainpalSearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage EnterTheCountry(string text)
        {
            SearchInputCountry.SendKeys(text);
            return this;
        }
    }
}
