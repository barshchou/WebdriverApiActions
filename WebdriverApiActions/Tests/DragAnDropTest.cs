using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdriverApiActions.Tests
{
    class DragAnDropTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string browser;

        [SetUp]
        public void Initialize()
        {
            browser = ConfigurationManager.AppSettings["browser"];

            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
            }
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void SearchCellPhones()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
