using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebdriverApiActions.Pages;

namespace WebdriverApiActions
{
    class MouseOverTest
    {
        private IWebDriver driver;
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
                    //FirefoxOptions options = new FirefoxOptions();
                    //options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox61\firefox.exe";
                    //options.UseLegacyImplementation = true;
                    //driver = new FirefoxDriver(options);
                    driver = new FirefoxDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchCellPhones()
        {
            HomePage home = new HomePage(driver);
            home.GoToPage();
            SmartphonesPage smartphones = home.GoToSmartphonesPage(driver);
            smartphones.IsPageloaded();
            Assert.AreEqual("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell", smartphones.GetUrl());

            smartphones.GoToSearchResultsPage(driver);

            Assert.IsTrue(smartphones.IsElementPresent(By.Id("ResultSetItems")));

        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
