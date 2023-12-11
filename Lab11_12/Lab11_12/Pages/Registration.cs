using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab11_12.Logger.Logger;

namespace Lab11_12.Pages
{
    internal class Registration : AbstractPage
    {

        private string baseUrl = "https://cars.av.by/filter";

        public Registration(IWebDriver driver):base(driver) { }

        public override AbstractPage openPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return this;
        }

        public void Registrate(string name, string phone, string password)
        {
            var enterBtnNav = driver.FindElement(By.XPath("//span[text() = 'Войти']"));
            enterBtnNav.Click();


            var enterRegBtn = driver.FindElement(By.XPath("//button[@class='drawer__slide-toggle' and span[text()='Регистрация']]"));
            enterRegBtn.Click();

            var inputName = driver.FindElement(By.XPath("(//input[@class='form-control form-control--large' and @type='text' and @name='name'])[1]"));
            inputName.SendKeys(name);

            var inputPhone = driver.FindElement(By.XPath("(//input[@class='form-control form-control--large' and @type='text' and @name='phone.number'])[1]"));
            inputPhone.SendKeys(phone);

            var inputPassword = driver.FindElement(By.XPath("(//input[@class='form-control form-control--large' and @type='password' and @name='password'])[1]"));
            inputPassword.SendKeys(password);

            var acceptData = driver.FindElement(By.XPath("(//label[@class='checkbox' and span/span/a[text()='правилами обработки персональных данных']])[1]"));
            acceptData.Click();

            var regBtn = driver.FindElement(By.XPath("(//button[@class='button button--primary' and span[@class='button__text' and text()='Зарегистрироваться']])[1]"));
            regBtn.Click();
        }

        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("(//div[@class='auth__title'])[3]"));
                driver.Quit();
                WriteLog("Regestration is success");

                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("Regestration is less");
                return false;
            }
        }
    }
}
