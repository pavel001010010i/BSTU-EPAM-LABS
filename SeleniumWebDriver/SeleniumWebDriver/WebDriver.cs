using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Tests;

namespace SeleniumWebDriver
{
    public class WebDriver : TrainpalWebTests
    {
        /*1. Поиск автомобиля в недоуступных для компании странах.
        Шаги: заходим на главную страницу, в поле pick-up & return, ставим галочку RETURN AT PICK-UP LOCATION,
        ищем страну, например Indonesia, отстальные поля заполнять не обязатеьно, жмем enter.
        Ожидаемый результат: вывод сообщения 'Sorry, but there are no SIXT stations available near Indonesia!' 
        либо подсказки с ближайшими странами/городами, в которых есть автомобили данной компании.*/
        [Test]
        public void TrainpalSearchOfTheCarInTheCountriesInaccessibleToTheCompany()
        {
            IWebElement searchInput = Browser.Element(By.ClassName("SearchInput__isPickupAsReturn"),1);
            searchInput.SendKeys("Indonesia");
            searchInput.Click();
            IWebElement error = Browser.Element(By.ClassName("ErrorMessage__message"),1);
            var isErrorMessageCorrect = error.Text.Equals("Sorry, but there are no SIXT stations available near Indonesia!");
            Assert.IsTrue(error.Displayed && isErrorMessageCorrect);
        }
        /*Отмена заказа с подтверждением.
        Шаги: заходим на сайт, жмем Log in (логинимся под своей учетной записью), жмем на Account;
        В разделе RESERVATIONS видим наш заказ, выбираем, находим кнопку CANEL RESERVATION.
        Ожидаемый результат: подтверждение отмены с помощью меседж бокса (yes/no).*/
        [Test]
        public void TrainpalCancellationOfOrderOfConfirmation()
        {
            Browser.Element(By.ClassName("LoginButton__label"), 1).Click();
            Browser.Element(By.ClassName("floatl__input"), 2).SendKeys("user1.user2@gmail.com" + Keys.Enter);
            Thread.Sleep(2000);
            Browser.Element(By.ClassName("floatl__input"), 3).SendKeys("qwerty123" + Keys.Enter);
            Browser.Element(By.ClassName("LoginButton__circle"), 2).Click();
            Browser.Element(By.ClassName("UserDetails__link"), 1).Click();
            Browser.Element(By.XPath("//div[@class='CustomerLayout__quickLinksWrapper']/ul[@class='QuickLinks__quickLinks']/li[3]/a"), 2).Click();
            Browser.Element(By.ClassName("ReservationItem__optionsLinkLabel"), 1).Click();
            Browser.Element(By.XPath("//ul[@class='ReservationDetailsView__actions']/li[2]"), 2).Click();
            IWebElement ConfirmationOfTheCancellation = Browser.Element(By.ClassName("Button__buttonContent"), 1);
            Assert.IsTrue(ConfirmationOfTheCancellation.Enabled);
        }

    }
}
