using System;
using System.Collections;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Tests;
using GitHubAutomation.Model;
using GitHubAutomation.Service;
using GitHubAutomation.Utils;
using OpenQA.Selenium.Support.Extensions;


namespace GitHubAutomation.Tests
{
    public class Tests: ScreenShotsErrorTest
    {
        [Test, Description("Test is not complete")]
        public void SearchForNonexistentCountry()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://www.sixt.com/#/");
                SearchOfTheCarInTheCountriesInaccessibleToTheCompanyPage trainpalSearchOfTheCar = new MainPage(Driver)
                         .EnterTheCountry(CreatorCountryModel.WithCountryProperties());
                Assert.AreEqual(trainpalSearchOfTheCar.SelectError.Text, "Sorry, but there are no SIXT stations available near Indonesia!");

            });
        }


        [Test, Description("Test is not complete")]
        public void CancellationOfOrderOfConfirmation()
            {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://www.sixt.com/#/");
                ReservationСancellationPage reservationСancellationPage = new MainPage(Driver)
                         .EntranceProfile()
                         .FillLogin(CreatorLogIn.WithAllProperties())
                        .SearchReservationPage()
                        .ReservationManipulation()
                        .CancelReservations();
                Assert.True(reservationСancellationPage.СonfirmationСancellation.Enabled);

            });
        }
    }
}
