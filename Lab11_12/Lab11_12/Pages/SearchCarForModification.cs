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
    internal class SearchCarForModification : AbstractPage
    {
        private string baseUrl = "https://av.by/catalog";

        public SearchCarForModification(IWebDriver driver):base(driver) { }


        public override AbstractPage openPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return this;
        }



        public void SearchCar(string carName, string carModel, string carBody, string carEngine)
        {
            var name = driver.FindElement(By.XPath($"//a[@title ='{carName}']"));
            name.Click();

            var model = driver.FindElement(By.XPath($"//a[@title = '{carModel}']"));
            model.Click();

            var body = driver.FindElement(By.XPath($"//div[text() = '{carBody}']"));
            body.Click();

            var engine = driver.FindElement(By.XPath($"//a[@title = '{carEngine}']"));
            engine.Click();
            
        }


        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.ClassName("modification"));
                driver.Quit();
                WriteLog("Car modification is founded");
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("Car modification is not founded");
                return false;
            }
        }


    }
}
