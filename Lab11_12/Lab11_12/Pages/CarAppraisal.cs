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
    internal class CarAppraisal : AbstractPage
    {
        private string baseUrl = "https://av.by/";

        public CarAppraisal(IWebDriver driver) : base(driver) { }
        public override AbstractPage openPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return this;
        }

        public void GoPageAppraisal()
        {
            var vinBtn = driver.FindElement(By.XPath("//li[@class='footer__listitem']/a[@class='footer__link' and @href='https://av.by/ocenka-avto']"));
            vinBtn.Click();
        }


        public void EnterParam(string name, string model, string year, string generation)
        {
            var carName = driver.FindElement(By.XPath($"//span[@class='catalog__description-text' and text()='{name}']"));
            carName.Click();     
            
            var carModel = driver.FindElement(By.XPath($"//span[@class='catalog__description-text' and text()='{model}']"));
            carModel.Click();

            var carYear = driver.FindElement(By.XPath($"//span[@class='catalog__description-text' and text()='{year}']"));
            carYear.Click();           
            
            var carGen = driver.FindElement(By.XPath($"//div[@class='generations__title' and text()='{generation}']"));
            carGen.Click();



        }
        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("//div[@class='heading__main']/h1[@class='heading__text']"));
                driver.Quit();
                WriteLog("Success appreisal");
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("Failed appreisal");
                return false;
            }
        }
    }
}
