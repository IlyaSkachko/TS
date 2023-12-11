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
    internal class Test4
    {
        private IWebDriver driver;
        private Registration reg;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            reg = new Registration(driver);
        }

        [Test]
        public void Test()
        {
            reg.openPage();
            reg.Registrate("Илья", "375293236547", "qwerty15900");
            Assert.IsTrue(reg.isFound());
           
        }
    }
}
