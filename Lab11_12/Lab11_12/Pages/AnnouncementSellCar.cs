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
    internal class AnnouncementSellCar : AbstractPage
    {
        private string baseUrl = "https://av.by/";

        public AnnouncementSellCar(IWebDriver driver):base(driver) { }
        public override AbstractPage openPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return this;
        }

        public void AccountEnter(string phoneNumber, string password)
        {
            var enterBtnNav = driver.FindElement(By.XPath("//span[text() = 'Войти']"));
            enterBtnNav.Click();

            var pNumber = driver.FindElement(By.XPath("(//input[@name = 'phone.number'])[1]"));
            pNumber.SendKeys(phoneNumber);


            var pass = driver.FindElement(By.XPath("(//input[@name = 'password'])[1]"));
            pass.SendKeys(password);

            var enterBtnAcc = driver.FindElement(By.XPath("//button[@class='button button--action' and span[@class='button__text' and text()='Войти']]"));
            enterBtnAcc.Click();

            WriteLog("Enter account");

        }

        public void AddAnnoncement(string name, string model, string year)
        {
            var addBtn = driver.FindElement(By.XPath("//li[@class='nav__item nav__item--add']/button[@class='button button--primary button--block button--small' and @type='button' and @rel='nofollow']"));
            addBtn.Click();

            var carTypeBtn = driver.FindElement(By.XPath("(//div[@class='category-item']/a[@class='category-item__button']/span[@class='category-item__title'])[1]"));
            carTypeBtn.Click();

            var carName = driver.FindElement(By.XPath($"//span[@class='catalog__description-text' and text()='{name}']"));
            carName.Click();

            var carModel = driver.FindElement(By.XPath($"//span[@class='catalog__description-text' and text()='{model}']"));
            carModel.Click();

            var carYear = driver.FindElement(By.XPath($"//span[@class='catalog__description-text' and text()='{year}']"));
            carYear.Click();

            var next = driver.FindElement(By.XPath("//button[@class='button button--primary button--small' and @type='button']/span[@class='button__text' and text()='Далее']"));
            for (var i = 0; i < 6; i++)
            {
                next.Click();
            }

            var acceptBtn = driver.FindElement(By.XPath("(//input[@class='checkbox__input' and @type='checkbox'])[41]"));
            acceptBtn.Click();

            var annouceBtn = driver.FindElement(By.XPath("//button[@class='button button--action button--large' and @type='submit']/span[@class='button__text' and text()='Опубликовать объявление']"));
            annouceBtn.Click();
        }


        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("//div[@class='heading__main']/h1[@class='heading__text']"));
                driver.Quit();
                WriteLog("Success announce");
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("Failed announce");
                return false;
            }
        }
    }
}
