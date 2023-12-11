using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    abstract class AbstractPage
    {
        protected IWebDriver driver;

        protected AbstractPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public abstract AbstractPage openPage();

    }
}
