using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Pages;

namespace WebdriverApiActions
{
    class MouseOverTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string browser;
        private string baseURL;

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
                    FirefoxOptions options = new FirefoxOptions();
                    options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    driver = new FirefoxDriver(options);
                    break;
            }
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            baseURL = "https://ebay.com";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void SearchCellPhones()
        {
            HomePage home = new HomePage(driver, wait);
            home.GoToHomePage(baseURL);

            //Navigate to smartphones page
            SmartphonesPage smartphones = home.GoToSmartphonesPage();
            
            //Check IsSmartphonePage
            Assert.IsTrue(smartphones.CheckPage());
            Assert.AreEqual("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell", smartphones.GetUrl());

            //Search
            SearchResultsPage searchResults = smartphones.GoToSearchResultsPage("Скрипка");
            
            //Check items found
            Assert.IsTrue(searchResults.ItemsFound());
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
