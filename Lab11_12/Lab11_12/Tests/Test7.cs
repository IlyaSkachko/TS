using Lab11_12.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Tests
{
    internal class Test7
    {

        private IWebDriver driver;
        private CheckVIN vin;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            vin = new CheckVIN(driver);
        }

        [Test]
        public void Test()
        {
            vin.openPage();
            vin.GoPageVin();
            vin.EnterVIN("XW8AN2XXXF1143422");
            vin.SearchCar();
            Assert.IsTrue(vin.isFound());

        }
    }
}
