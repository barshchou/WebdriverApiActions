using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdriverApiActions.Pages
{
    class SmartphonesPage
    {
        IWebDriver driver;
        private WebDriverWait wait;

        public SmartphonesPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public string GetUrl()
        {
            return driver.Url;
        }

    }
}
