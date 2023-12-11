using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.Network;
using OpenQA.Selenium.DevTools.V120.Emulation;
using OpenQA.Selenium.Support.UI;
using static Lab11_12.Logger.Logger;

namespace Lab11_12.Pages
{
    internal class SearchCarForParameters:AbstractPage
    {
        public SearchCarForParameters(IWebDriver driver):base(driver) { }

        private string baseUrl = "https://av.by/";

        public override AbstractPage openPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return this;
        }

        public void EnterParameters(string carName, string priceTo)
        {
            var nameBtn = driver.FindElement(By.XPath("//button[@class='dropdown__control dropdown-floatlabel' and contains(span[@class='dropdown-floatlabel__box']/span[@class='dropdown-floatlabel__label'], 'Марка')]"));
            nameBtn.Click();

            var searchNameInput = driver.FindElement(By.XPath($"//li[@class='dropdown__listitem' and button[text()='{carName}']]"));
            searchNameInput.Click();
            
            var priceInput = driver.FindElement(By.XPath("(//input[@maxlength='6' and @data-property-label='Цена' and @data-property-name='price_usd' and @id='p-9-price_usd' and @name='p-9-price_usd' and @class='richinput-control__value' and @type='text' and @value=''])[2]"));
            priceInput.SendKeys(priceTo);
    
        }

        public void Search()
        {
            var searchBtn = driver.FindElement(By.XPath("//a[@class='button button--secondary button--block']"));
            searchBtn.Click();
        }

        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("//h1[@class='heading__text']"));
                driver.Quit();
                WriteLog("Car is founded");
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("Car not founded");
                return false;
            }
        }
    }
}
