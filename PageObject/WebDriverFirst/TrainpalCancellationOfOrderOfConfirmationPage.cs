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
    class TrainpalCancellationOfOrderOfConfirmationPage : Page
    {
        [FindsBy(How = How.ClassName, Using = "LoginButton__label")]
        private readonly IWebElement LogIn;

        [FindsBy(How = How.ClassName, Using = "floatl__input")]
        private readonly IWebElement InputLogin;

        [FindsBy(How = How.ClassName, Using = "floatl__input")]
        private readonly IWebElement InputPassword;

        [FindsBy(How = How.ClassName, Using = "LoginButton__circle")]
        private readonly IWebElement SignInToYourAccount;

        [FindsBy(How = How.CssSelector, Using = "UserDetails__link")]
        private readonly IWebElement AccountOpen;

        [FindsBy(How = How.XPath, Using = "//*div[@class='CustomerLayout__quickLinksWrapper']/ul/li[3]/a")]
        private readonly IWebElement ReservationItem;

        [FindsBy(How = How.ClassName, Using = "ReservationItem__optionsLinkLabel")]
        private readonly IWebElement SelectCancelThisBooking;


        [FindsBy(How = How.CssSelector, Using = "//ul[@class='ReservationDetailsView__actions']/li[2]")]
        private readonly IWebElement SelectCancelReservation;

        [FindsBy(How = How.ClassName, Using = "Button__buttonContent")]
        public IWebElement СonfirmationСancellation { get; private set; }

        public TrainpalCancellationOfOrderOfConfirmationPage(IWebDriver driver) : base(driver) { }

        public TrainpalCancellationOfOrderOfConfirmationPage FillLogin(string text)
        {
            InputLogin.SendKeys(text);
            return this;
        }

        public TrainpalCancellationOfOrderOfConfirmationPage FillPass(string text)
        {
            InputPassword.SendKeys(text);
            return this;
        }

        public TrainpalCancellationOfOrderOfConfirmationPage Authorization()
        {
            LogIn.Click();
            return this;
        }
        public TrainpalCancellationOfOrderOfConfirmationPage EntranceProfile()
        {
            SignInToYourAccount.Click();
            AccountOpen.Click();
            return this;
        }
        public TrainpalCancellationOfOrderOfConfirmationPage SearchReservations()
        {
            ReservationItem.Click();
            SelectCancelThisBooking.Click();
            return this;
        }
        public TrainpalCancellationOfOrderOfConfirmationPage CancelReservations()
        {
            SelectCancelReservation.Click();
            return this;
        }
    }
}
