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
using GitHubAutomation.Pages;
using GitHubAutomation.Model;
using GitHubAutomation.Service;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Pages
{
    class MainPage
    {
        IWebDriver driver;
        [FindsBy(How = How.ClassName, Using = "SearchInput__isPickupAsReturn")]
        private readonly IWebElement SearchInputCountry;

        [FindsBy(How = How.XPath, Using = "//*div[@class='CustomerLayout__quickLinksWrapper']/ul/li[3]/a")]
        private readonly IWebElement ReservationItem;


        [FindsBy(How = How.ClassName, Using = "LoginButton__circle")]
        private readonly IWebElement SignInToYourAccount;

        [FindsBy(How = How.CssSelector, Using = "UserDetails__link")]
        private readonly IWebElement AccountOpen;
        public MainPage(IWebDriver driver) 
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public SearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage EnterTheCountry(CountryModel countryModel)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("SearchInput__isPickupAsReturn")));
            SearchInputCountry.SendKeys(countryModel.Country);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("ErrorMessage__message")));
            return new SearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage(driver);
        }


        public PersonalAccountPage SearchReservationPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*div[@class='CustomerLayout__quickLinksWrapper']/ul/li[3]/a")));
            ReservationItem.Click();
            return new PersonalAccountPage(driver);
        }

        public AuthorizationPage EntranceProfile()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("LoginButton__circle")));
            SignInToYourAccount.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("UserDetails__link")));
            AccountOpen.Click();
            return new AuthorizationPage(driver);
        }
    }
}
