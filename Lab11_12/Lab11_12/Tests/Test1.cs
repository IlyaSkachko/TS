using Lab11_12.Pages;
using OpenQA.Selenium;
using Lab11_12.BrowserManager;
using OpenQA.Selenium.Edge;

namespace Lab11_12.Tests
{
    public class Test1
    {
        private IWebDriver driver;
        private Bookmark pageMark;


        [SetUp]
        public void Setup()
        {
            this.driver = new EdgeDriver("D:\\Data\\edgedriver_win64");
            pageMark = new Bookmark(driver);
        }

        [Test]
        public void Test()
        {
            pageMark.openPage();
            pageMark.AccountEnter("333320927", "bestman2003");
            pageMark.Add();
            Assert.IsTrue(pageMark.isFoundAdd());
        }
    }
}