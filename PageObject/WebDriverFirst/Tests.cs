﻿using System;
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

namespace PageObject
{

    [TestFixture]
    public class Tests
    {
        private IWebDriver Browser;
        private string WebsiteURL;

        [SetUp]
        public void SetupTest()
        {
            WebsiteURL = "https://www.sixt.com/#/";
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl(WebsiteURL);
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            Browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [Test, Description("Test is not complete")]
        public void TrainpalSearchForNonexistentCountry()
        {

            TrainpalSearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage TrainpalSearchOfTheCar = new TrainpalSearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage(Browser);

            TrainpalSearchOfTheCar
                .EnterTheCountry("Indonesia");

            Assert.AreEqual(TrainpalSearchOfTheCar.SelectError.Text, "Sorry, but there are no SIXT stations available near Indonesia!");
        }

        [Test, Description("Test is not complete")]
        public void TrainpalCancellationOfOrderOfConfirmation()
        {
            MainPage mainPage = new MainPage(Browser).AuthorizationButton();

            AuthorizationPage authorizationPage = new AuthorizationPage(Browser);
            authorizationPage
                .FillLogin("user1.user2@gmail.com" + Keys.Enter)
                .FillPass("qwerty123" + Keys.Enter);

            mainPage.EntranceProfile();

            PersonalAccountPage personalAccountPage = new PersonalAccountPage(Browser).SearchReservationPage();

            ReservationPage reservationPage = new ReservationPage(Browser).ReservationManipulation();

            ReservationСancellationPage reservationСancellationPage = new ReservationСancellationPage(Browser).CancelReservations();
            
            Assert.True(reservationСancellationPage.СonfirmationСancellation.Enabled);
        }

        [TearDown]
        public void TearDownTest()
        {
            if (Browser != null)
                Browser.Quit();        
        }
    }
}
