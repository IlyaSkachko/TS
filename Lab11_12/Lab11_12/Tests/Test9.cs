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
    internal class Test9
    {
        private IWebDriver driver;
        private AnnouncementSellCar car;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            car = new AnnouncementSellCar(driver);
        }

        [Test]
        public void Test()
        {
            car.openPage();
            car.AccountEnter("333320927", "bestman2003");
            car.AddAnnoncement("BMW", "8 серия", "2022");
            Assert.IsTrue(car.isFound());

        }
    }
}
