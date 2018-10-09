using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Helpers;
using WebdriverApiActions.Pages;

namespace WebdriverApiActions
{
    class MouseOverTest
    {
        public static IWebDriver Driver { get; set; }
        private WebDriverWait wait;
        private string baseURL;

        [SetUp]
        public void Initialize()
        {
            DriverInitialization driverInitialization = new DriverInitialization();
            Driver = driverInitialization.InitializeDriver();
            Driver.Manage().Window.Maximize();
            baseURL = "https://ebay.com";
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void SearchCellPhones()
        {
            HomePage home = new HomePage(Driver);
            Driver.Navigate().GoToUrl(baseURL); 

            SmartphonesPage smartphones = home.GoToSmartphonesPage();
            
            Assert.AreEqual("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell", Driver.Url);

            SearchResultsPage searchResults = smartphones.PerformSearch("Скрипка");
            
            Assert.IsTrue(searchResults.IsItemFound());
        }
        
        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
