using System;
using System.Collections;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Framework.driver;
using Framework.Pages;
using Framework.Tests;
using Framework.Model;
using Framework.Service;
using Framework.Utils;
using OpenQA.Selenium.Support.Extensions;
using log4net;
using log4net.Config;


namespace Framework.Tests
{
    public class Tests: ManagerTests
    {
        const string errorTextSearchCountryInWhichThereIsNoCompany =
            "Sorry, but there are no SIXT stations available near Indonesia!";

        const string guaranteedAutoSearchErrorText =
            "No offers were found for these filter settings.";

        const string textOfTheResultOfAddingNewUser =
            "PROFILE CREATED SUCCESSFULLY";

        const string minimumAgeSearchErrorText =
            "driver age 17";

        const string textOfSearchResultRepresentative =
            "SIXT LOCATIONS IN MINSK";

        const string passwordChangeErrorText =
            "Your current password is wrong.";

        [Test, Description("Test is not complete")]
        public void SearchForNonexistentCountry()
        {
            Logger.Log.Info("Start SearchForNonexistentCountry test.");
            MainPage trainpalSearchOfTheCar = new MainPage(driver)
                     .SearchInputCountrySendKeys(CreatorCountryModel.WithCountryProperties())
                     .SearchInputCountryItemClick();
            Assert.AreEqual(trainpalSearchOfTheCar.SelectError(), errorTextSearchCountryInWhichThereIsNoCompany);

        }


        [Test, Description("Test is not complete")]
        public void CancellationOfOrderOfConfirmation()
        {
            Logger.Log.Info("Start CancellationOfOrderOfConfirmation test.");
            ReservationСancellationPage reservationСancellationPage = new MainPage(driver)
                     .EntranceProfile()
                     .FillLogin(CreatorLogIn.WithAllProperties())
                     .EntranceProfileAcc()
                     .ReservationItemOpen()
                     .SelectCancelThisBookingClick()
                     .CancelReservations();
            Assert.True(reservationСancellationPage.СonfirmationСancellation.Enabled);
        }

        [Test, Description("Test is not complete")]
        public void RentCarRetroactively()
        {
            Logger.Log.Info("Start RentCarRetroactively test.");
            MainPage rentCarRetroactively = new MainPage(driver)
                      .EntranceProfile()
                      .FillLogin(CreatorLogIn.WithAllProperties())
                      .PickupStationSendKeysAndClick(CreatorCountryModel.WithCountryProperties())
                      .SelectFromListClick()
                      .PickupDateButtonClick()
                      .WaitPickupDateEnabled();
            Assert.True(rentCarRetroactively.dayPicker.Enabled);
        }

        [Test, Description("Test is not complete")]
        public void FoundOnlyGuaranteeTheModel()
        {
            Logger.Log.Info("Start FoundOnlyGuaranteeTheModel test.");
            CarRent foundOnlyGuaranteeTheModel = new MainPage(driver)
                      .EntranceProfile()
                      .FillLogin(CreatorLogIn.WithAllProperties())
                      .PickupStationSendKeysAndClick(CreatorCountryModel.WithCountryProperties())
                      .SelectFromListClick()
                      .PickupDateButtonClick()
                      .PickupDateReservationClick()
                      .PickupDateDeliveriesClick()
                      .ButtonShowerClick()
                      .SelectionGuaranteedCars();
            Assert.AreEqual(foundOnlyGuaranteeTheModel.ErrorMessage(), guaranteedAutoSearchErrorText);
        }

        [Test, Description("Test is not complete")]
        public void AddAdditionalUser()
        {
            Logger.Log.Info("Start AddAdditionalUser test.");
            ProfilesPage addCreditCard = new MainPage(driver)
                     .EntranceProfile()
                     .FillLogin(CreatorLogIn.WithAllProperties())
                     .EntranceProfileAcc()
                     .ProfilesItemClick()
                     .SixtProfiledAddButtonClick()
                     .AddPrivateProfileclick()
                     .ProfileNameSendKeys(CreatorLogIn.ConclusionNameAndNewAccount())
                     .FieldEmailSendKeys(CreatorLogIn.ConclusionNameAndNewAccount())
                     .ButtonAddProfileClick();
            Assert.AreEqual(addCreditCard.ErrorMessage(), textOfTheResultOfAddingNewUser);
        }

        [Test, Description("Test is not complete")]
        public void ToSpecifyTheDriversAgeIsLessThanEighteenYearsOfAge()
        {
            Logger.Log.Info("Start ToSpecifyTheDriversAgeIsLessThanEighteenYearsOfAge test.");
            CarRent rentCar = new MainPage(driver)
                      .EntranceProfile()
                      .FillLogin(CreatorLogIn.WithAllProperties())
                      .PickupStationSendKeysAndClick(CreatorCountryModel.WithCountryProperties())
                      .SelectFromListClick()
                      .PickupDateButtonClick()
                      .PickupDateReservationClick()
                      .PickupDateDeliveriesClick()
                      .ButtonShowerClick()
                      .SearchForAgeLessThanEighteen();
            Assert.AreNotEqual(rentCar.DayPickerOut(), minimumAgeSearchErrorText);
        }

        [Test, Description("Test is not complete")]
        public void FindCarWithLessThanTwoSeats()
        {
            Logger.Log.Info("Start FindCarWithLessThanTwoSeats test.");
            CarRent rentCar = new MainPage(driver)
                      .EntranceProfile()
                      .FillLogin(CreatorLogIn.WithAllProperties())
                      .PickupStationSendKeysAndClick(CreatorCountryModel.WithCountryProperties())
                      .SelectFromListClick()
                      .PickupDateButtonClick()
                      .PickupDateReservationClick()
                      .PickupDateDeliveriesClick()
                      .ButtonShowerClick()
                      .SearchForTheNumberPlacesLessThanTwo();
            Assert.AreNotEqual(rentCar.NoOfSeatsValue(), "1");
        }

        [Test, Description("Test is not complete")]
        public void SelectionOfAdditionalDriver()
        {
            Logger.Log.Info("Start SelectionOfAdditionalDriver test.");
            CarRent newDriver = new MainPage(driver)
                      .EntranceProfile()
                      .FillLogin(CreatorLogIn.WithAllProperties())
                      .PickupStationSendKeysAndClick(CreatorCountryModel.WithCountryProperties())
                      .SelectFromListClick()
                      .PickupDateButtonClick()
                      .PickupDateReservationClick()
                      .PickupDateDeliveriesClick()
                      .ButtonShowerClick()
                      .SelectedCarClick()
                      .SelectButtonClick()
                      .AddingDriverButton();
            Assert.True(newDriver.addDriverButton.Enabled);
        }

        [Test, Description("Test is not complete")]
        public void SearchRepresentativeInTheCountry()
        {
            Logger.Log.Info("Start SearchRepresentativeInTheCountry test.");
            RepresentativeInTheCountryPage representativeInTheCountry = new MainPage(driver)
                      .EntranceProfile()
                      .FillLogin(CreatorLogIn.WithAllProperties())
                      .FindLocation()
                      .InputStationSendKeysAndClick(CreatorCountryModel.ChosenCountryAndSelectCity())
                      .InputStationItemClick()
                      .InputStationSearchClick()
                      .InputStationSendKeysAndClickCity(CreatorCountryModel.ChosenCountryAndSelectCity())
                      .InputStationSearchBelarusClick()
                      .ButtonFullListLocationClick();
            Assert.AreEqual(representativeInTheCountry.SixLocationsInMinsk(), textOfSearchResultRepresentative);
        }

        [Test, Description("Test is not complete")]
        public void ChangePassword()
        {
            Logger.Log.Info("Start ChangePassword test.");
            PersonalAccountPage addCreditCard = new MainPage(driver)
                     .EntranceProfile()
                     .FillLogin(CreatorLogIn.WithAllProperties())
                     .EntranceProfileAcc()
                     .AccountItemOpen()
                     .ChangePasswordButtonClick()
                     .PasswordEntry(CreatorLogIn.ConclusionWrongPassword())
                     .ButtonSaveClick();
            Assert.AreEqual(addCreditCard.ErrorMessage(), passwordChangeErrorText);
        }

    }
}
