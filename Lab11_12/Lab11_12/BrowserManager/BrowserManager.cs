using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab11_12.Logger.Logger;
using Microsoft.Edge.SeleniumTools;

namespace Lab11_12.BrowserManager
{
    public class BrowserManager
    {


        private static IWebDriver driver = null;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    InitializeDriver();
                }
                return driver;
            }
        }

        public BrowserManager() { } 

        private static void InitializeDriver()
        {
            driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            WriteLog("WebDriver initialized.");
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
                WriteLog("WebDriver quit.");
            }
        }
    }
}
