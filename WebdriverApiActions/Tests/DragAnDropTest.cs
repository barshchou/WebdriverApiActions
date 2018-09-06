using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverApiActions.Pages;

namespace WebdriverApiActions.Tests
{
    class DragAnDropTest
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
            baseURL = "https://html5demos.com/drag/";
        }

        [Test]
        public void DragAndDropTest()
        {
            int countBefore = 0;
            int countAfter = 0;

            DragAndDropPage dragAndDropPage = new DragAndDropPage(driver, wait);

            dragAndDropPage.JavascriptFindElement(driver, "bin");

            //countBefore = dragAndDropPage.CountItems(driver);
            //dragAndDropPage.DragItems(driver);
            //countAfter = dragAndDropPage.CountItems(driver);

            //Assert.AreEqual(countAfter, countBefore - 2);
            
            //dragAndDropPage.CheckDOMTree(driver, countAfter);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
