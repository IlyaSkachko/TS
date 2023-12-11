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
    internal class RepairParts : AbstractPage
    {
        private string baseUrl = "https://av.by/";

        public RepairParts(IWebDriver driver) : base(driver) { }    
        public override AbstractPage openPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return this;
        }

        public void GoPageRepairParts()
        {
            var repairBtn = driver.FindElement(By.XPath("(//a[@class='nav__link']/span[@class='nav__link-text'])[2]"));
            repairBtn.Click();
        }

        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("//h1[@class='heading__text']"));
                driver.Quit();
                WriteLog("Success tab");
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("Failed tab");
                return false;
            }
        }
    }
}
