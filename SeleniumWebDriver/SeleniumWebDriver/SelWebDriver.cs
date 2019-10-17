using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class TrainpalWebTests
        {
            IWebDriver Browser;

            [SetUp]
            public void StartBrowserChrome()
            {
                Browser = new ChromeDriver(@"b:\5_SEMESTR\EPAM\");
                Browser.Manage().Window.Maximize();
                Browser.Navigate().GoToUrl("https://www.sixt.com/#/");
                Thread.Sleep(2000);
            }

            [Test]
            public void TrainpalSearchOfTheCarInTheCountriesInaccessibleToTheCompany()
            {
                IWebElement searchInput = Browser.FindElement(By.ClassName("SearchInput__isPickupAsReturn"));
                searchInput.SendKeys("Indonesia");
                Thread.Sleep(2000);
                searchInput.Click();
                Thread.Sleep(5000);
                IWebElement error = Browser.FindElement(By.ClassName("ErrorMessage__message"));
                var isErrorMessageCorrect = error.Text.Equals("Sorry, but there are no SIXT stations available near Indonesia!");
                Assert.IsTrue(error.Displayed && isErrorMessageCorrect);
            }

            [Test]
            public void TrainpalCancellationOfOrderOfConfirmation()
            {
                Browser.FindElement(By.ClassName("LoginButton__label")).Click(); 
                Thread.Sleep(2000);
                Browser.FindElement(By.ClassName("floatl__input")).SendKeys("user1.user2@gmail.com"+ Keys.Enter); 
                Thread.Sleep(2000);
                Browser.FindElement(By.ClassName("floatl__input")).SendKeys("qwerty123" + Keys.Enter);
                Thread.Sleep(4000); 
                Browser.FindElement(By.ClassName("LoginButton__circle")).Click();
                Thread.Sleep(2000);
                Browser.FindElement(By.ClassName("UserDetails__link")).Click();
                Thread.Sleep(2000);
                Browser.FindElement(By.XPath("/html/body/div/div/div/div/div/ul/li[3]/a")).Click();
                Thread.Sleep(2000);
                Browser.FindElement(By.ClassName("ReservationItem__optionsLinkLabel")).Click();
                Thread.Sleep(2000);
                Browser.FindElement(By.XPath("/html/body/div/div/div/div/section[@class='ReservationDetailsView__reservationDetailsWrapper']/div/div/div/div/ul/li[2]")).Click();
                Thread.Sleep(2000);
                IWebElement ConfirmationOfTheCancellation = Browser.FindElement(By.ClassName("Button__buttonContent"));
                Assert.IsTrue(ConfirmationOfTheCancellation.Enabled);
            }

            [TearDown]
            public void QuitDriver()
            {
                Browser.Quit();
            }
        }
    }
}