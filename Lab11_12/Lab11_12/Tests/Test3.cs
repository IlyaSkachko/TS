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
    internal class Test3
    {
        private IWebDriver driver;
        private SearchCarForModification modification;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            modification = new SearchCarForModification(driver);
        }

        [Test]
        public void Test()
        {
            modification.openPage();
            modification.SearchCar("BMW", "M5", "E39, 1998...2003", "4.9 MT (400 л.с.)");
            Assert.IsTrue(modification.isFound());
        }
    }
}
