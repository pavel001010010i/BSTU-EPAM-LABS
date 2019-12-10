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
using GitHubAutomation.Model;
using GitHubAutomation.Service;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Pages
{
    class SearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage
    {
        IWebDriver driver;
        [FindsBy(How = How.ClassName, Using = "SearchInput__isPickupAsReturn")]
        private readonly IWebElement SearchInputCountry;

        [FindsBy(How = How.ClassName, Using = "ErrorMessage__message")] 
        public IWebElement SelectError { get; private set; }

        [Obsolete]
        public SearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
    }
}
