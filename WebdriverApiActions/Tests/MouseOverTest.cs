using System;
using System.Configuration;
using System.IO;
using System.Text;
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
                    driver = new FirefoxDriver();
                    break;
            }
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            baseURL = "https://ebay.com";
        }

        [Test]
        public void SearchCellPhones()
        {
            HomePage home = new HomePage(driver, wait);
            home.GoToHomePage(driver, baseURL);
            SmartphonesPage smartphones = home.GoToSmartphonesPage(driver);
            smartphones.WaitPageLoad(driver, wait);

            Assert.AreEqual("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell", smartphones.GetUrl(driver));

            SearchResultsPage searchResults = smartphones.GoToSearchResultsPage(driver);

            Assert.IsTrue(searchResults.IsElementPresent(driver, By.XPath("//div[contains(@id, 'esult') and contains(@class, 'clearfix')]/ul/li[1]"))); //
        }

        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
