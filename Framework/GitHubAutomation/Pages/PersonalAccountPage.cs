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
    public class PersonalAccountPage : WaitingItemLoad
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='NewPasswordForm__errorMessage']")]
        private readonly IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='CustomerLayout__customerContent']//a[1]")]
        private readonly IWebElement selectCancelThisBooking;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'NewProfileButton__wrapper')]")]
        private readonly IWebElement sixtProfiledAddButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Change Password')]")]
        private readonly IWebElement changePasswordButton;

        [FindsBy(How = How.XPath, Using = "//h4[contains(text(),'Private Profile')]")]
        private readonly IWebElement addPrivateProfile;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Current Password']")]
        private readonly IWebElement currentPassword;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='New Password']")]
        private readonly IWebElement newPassword;

        [FindsBy(How = How.XPath, Using = "//button[@class='Button__button 1200px']")]
        private readonly IWebElement buttonSave;

        [FindsBy(How = How.XPath, Using = "//div[@class='CustomerLayout__quickLinksWrapper']//li[3]")]
        private readonly IWebElement reservationItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='CustomerLayout__quickLinksWrapper']//li[2]")]
        private readonly IWebElement profilesItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='CustomerLayout__quickLinksWrapper']//li[1]//a[1]")]
        private readonly IWebElement accountItem;

        public string ErrorMessage()
        {
            return errorMessage.Text;
        }
        public PersonalAccountPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public PersonalAccountPage ReservationItemOpen()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='CustomerLayout__quickLinksWrapper']//li[3]"));
            reservationItem.Click();
            return new PersonalAccountPage(driver);
        }

        public ReservationPage SelectCancelThisBookingClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='CustomerLayout__customerContent']//a[1]"));
            selectCancelThisBooking.Click();
            return new ReservationPage(driver);
        }

        public PersonalAccountPage ProfilesItemClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='CustomerLayout__quickLinksWrapper']//li[2]"));
            profilesItem.Click();
            return new PersonalAccountPage(driver);
        }
        
        public PersonalAccountPage SixtProfiledAddButtonClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[contains(@class,'NewProfileButton__wrapper')]"));
            sixtProfiledAddButton.Click();
            return new PersonalAccountPage(driver);
        }

        public ProfilesPage AddPrivateProfileclick()
        {
            addPrivateProfile.Click();
            return new ProfilesPage(driver);
        }
        public PersonalAccountPage AccountItemOpen()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='CustomerLayout__quickLinksWrapper']//li[1]//a[1]"));
            accountItem.Click();
            return new PersonalAccountPage(driver);
        }
        public PersonalAccountPage ChangePasswordButtonClick()
        {
            WaitWebElementLoad(driver, 10, By.XPath("//span[contains(text(),'Change Password')]"));
            changePasswordButton.Click();
            return new PersonalAccountPage(driver);
        }
        public PersonalAccountPage PasswordEntry(User user)
        {
            currentPassword.SendKeys(user.NotCorrectPassword);
            newPassword.SendKeys(user.NotCorrectPassword);
            return new PersonalAccountPage(driver);
        }
        public PersonalAccountPage ButtonSaveClick()
        {
            buttonSave.Click();
            WaitWebElementLoad(driver, 10, By.XPath("//div[@class='NewPasswordForm__errorMessage']"));

            return new PersonalAccountPage(driver);
        }
    }
}
