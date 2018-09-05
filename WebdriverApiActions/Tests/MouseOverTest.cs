using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Pages;

using WebdriverApiActions.Helpers;
namespace WebdriverApiActions
{
    class MouseOverTest
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
            BaseHelper.Driver = driver;
            BaseHelper.Wait = wait;
        }

        [Test]
        public void SearchCellPhones()
        {
            HomePage home = new HomePage(driver, wait);
            home.GoToPage();
            SmartphonesPage smartphones = home.GoToSmartphonesPage(driver);
            
            smartphones.WaitPageLoad();

            Assert.AreEqual("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell", smartphones.GetUrl());

            //smartphones.GoToSearchResultsPage(driver);

            Assert.IsTrue(smartphones.GoToSearchResultsPage(driver).IsElementPresent(By.Id("ResultSetItems")));

        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
