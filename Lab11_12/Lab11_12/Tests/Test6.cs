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
    internal class Test6
    {
        private IWebDriver driver;
        private RepairParts rep;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            rep = new RepairParts(driver);
        }

        [Test]
        public void Test()
        {
            rep.openPage();
            rep.GoPageRepairParts();
            Assert.IsTrue(rep.isFound());

        }
    }
}
