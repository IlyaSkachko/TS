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
    internal class Test8
    {
        private IWebDriver driver;
        private CarAppraisal car;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            car = new CarAppraisal(driver);
        }

        [Test]
        public void Test()
        {
            car.openPage();
            car.GoPageAppraisal();
            car.EnterParam("Fiat", "Ulysse", "1999", "I · Рестайлинг, 1998…2002");
            Assert.IsTrue(car.isFound());

        }
    }
}
