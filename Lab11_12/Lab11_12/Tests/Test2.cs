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
    public class Test2
    {

        private IWebDriver driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
        private Bookmark pageMark;


        [SetUp]
        public void Setup()
        {
            pageMark = new Bookmark(driver);
        }

        [Test]
        public void Test1()
        {
            pageMark.openPage();
            pageMark.AccountEnter("333320927", "bestman2003");
            pageMark.Delete();
            Assert.IsTrue(pageMark.isFoundDelete());
        }
    }
}
