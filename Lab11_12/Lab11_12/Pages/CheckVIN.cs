using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab11_12.Logger.Logger;


namespace Lab11_12.Pages
{
    internal class CheckVIN:AbstractPage
    {
        private string baseUrl = "https://av.by/";

        public CheckVIN(IWebDriver driver) : base(driver) { }
        public override AbstractPage openPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return this;
        }

        public void GoPageVin()
        {
            var vinBtn = driver.FindElement(By.XPath("//li[@class='footer__listitem']/a[@class='footer__link' and @href='https://av.by/vin']"));
            vinBtn.Click();
        }

        
        public void EnterVIN(string vin)
        {
            var inputVin = driver.FindElement(By.XPath("//input[@class='form-control form-control--large' and @type='text' and @maxlength='17' and @placeholder='WBAHU310005E31819' and @value='']"));
            inputVin.SendKeys(vin);
        }

        public void SearchCar()
        {
            var btn = driver.FindElement(By.XPath("//button[@class='button button--primary button--block button--large' and @type='button' and span[@class='button__text' and text()='Проверить VIN']]"));
            btn.Click();
        }

        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("//div[@class='heading__main']/h1[@class='heading__text']"));
                driver.Quit();
                WriteLog("Success search car for vin");
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("Failed vin");
                return false;
            }
        }
    }
}
