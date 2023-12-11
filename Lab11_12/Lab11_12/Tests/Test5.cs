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
    internal class Test5
    {
        private IWebDriver driver;
        private SearchCarForParameters car;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            car = new SearchCarForParameters(driver);
        }

        [Test]
        public void Test()
        {
            car.openPage();
            car.EnterParameters("Audi", "4500");
            car.Search();
            Assert.IsTrue(car.isFound());
        }
    }
}
