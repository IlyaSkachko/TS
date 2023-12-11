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
    internal class Bookmark : AbstractPage
    {

        private string baseUrl = "https://cars.av.by/filter";

        public Bookmark(IWebDriver driver) : base(driver) {}
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


        public void Add()
        {
            var markBtn = driver.FindElement(By.XPath("(//button[contains(@class, 'bookmark')])[1]"));
            markBtn.Click();

            WriteLog("bookmark added");
        }

        public void Delete()
        {
            var myMarksBtn = driver.FindElement(By.XPath("//a[@class='nav__link' and @href='https://av.by/profile/bookmarks']"));
            myMarksBtn.Click();

            var delMarkBtn = driver.FindElement(By.XPath("(//button[@aria-busy='false'])[1]"));
            delMarkBtn.Click();

            WriteLog("bookmark deleted");
        }




        public bool isFoundDelete()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("//h1[text()='У вас нет закладок']"));
                driver.Quit();
                WriteLog("bookmark delete founded");

                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("bookmark delete not founded");
                return false;
            }
        }    
        
        public bool isFoundAdd()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("//div[@class='listing-item listing-item--color listing-item--top']"));
                driver.Quit();
                WriteLog("bookmark add founded");
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                WriteLog("bookmark add not founded");
                return false;
            }
        }
    }
}
