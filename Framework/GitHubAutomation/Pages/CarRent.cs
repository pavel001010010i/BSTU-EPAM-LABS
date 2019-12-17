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
    public class CarRent : WaitingItemLoad
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='DayPicker-Day DayPicker-Day--isDisabled'][contains(text(),'14')]")]
        private readonly IWebElement dayPicker;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'OfferListView__offerListBar')]//li[1]")]
        private readonly IWebElement driveAgeValue;

        [FindsBy(How = How.XPath, Using = "//div[@class='PassengersFilter__valueMarker'][contains(text(),'2')]")]
        private readonly IWebElement noOfSeatsValue;

        [FindsBy(How = How.XPath, Using = "//button[@class='Button__button 1200px']//div[@class='Button__buttonContent']")]
        public IWebElement addDriverButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Vehicle Type')]")]
        private readonly IWebElement vehicleTypeList;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Driver age 30+')]")]
        private readonly IWebElement driveAgeList;

        [FindsBy(How = How.XPath, Using = "//li[@class='OffergridCarTile__wrapper car-CLAR']//div[@class='OffergridCarTile__container']")]
        private readonly IWebElement selectedCar;

        [FindsBy(How = How.XPath, Using = "//button[@class='Button__onDark 1200px']")]
        private readonly IWebElement selectButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='OfferDetailView__payment']//div[2]//label[1]")]
        private readonly IWebElement selectButton1;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Additional Driver')]")]
        private readonly IWebElement addingDriverButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'No. of Seats 2')]")]
        private readonly IWebElement noOfSeatsList;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'react-toggle react-toggle--orange')]//div[contains(@class,'react-toggle-thumb')]")]
        private readonly IWebElement vehicleTypeListThumb;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'FilterError__errorText')]")]
        private IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        private readonly IWebElement InputPassword;
        public CarRent(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public string ErrorMessage()
        {
            return errorMessage.Text;
        }
        public string NoOfSeatsValue()
        {
            return noOfSeatsValue.Text;
        }

        public string DayPickerOut()
        {
            return dayPicker.Text;
        }
        public string DriveAgeValue()
        {
            return driveAgeValue.Text;
        }
        public CarRent SelectionGuaranteedCars()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(text(),'Vehicle Type')]"));
            vehicleTypeList.Click();
            vehicleTypeListThumb.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(@class,'FilterError__errorText')]"));

            return new CarRent(driver);
        }
        public CarRent SearchForAgeLessThanEighteen()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(text(),'Driver age 30+')]"));
            driveAgeList.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(@class,'OfferListView__offerListBar')]//li[1]"));

            return new CarRent(driver);
        }

        public CarRent SearchForTheNumberPlacesLessThanTwo()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(text(),'No. of Seats 2')]"));
            noOfSeatsList.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='PassengersFilter__valueMarker'][contains(text(),'2')]"));

            return new CarRent(driver);
        }
        public CarRent SelectedCarClick()
        {
            WaitWebElementLoad(driver, 20, By.XPath("//li[@class='OffergridCarTile__wrapper car-CLAR']//div[@class='OffergridCarTile__container']"));
            selectedCar.Click();
            return new CarRent(driver);
        }

        public CarRent SelectButtonClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//button[@class='Button__onDark 1200px']"));
            selectButton.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//button[@class='Button__onDark 1200px']//div[@class='Button__buttonContent']"));
            selectButton.Click();
            return new CarRent(driver);
        }

        public CarRent AddingDriverButton()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(text(),'Additional Driver')]"));
            addingDriverButton.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//button[@class='Button__button 1200px']//div[@class='Button__buttonContent']"));
            return new CarRent(driver);
        }
    }
}
