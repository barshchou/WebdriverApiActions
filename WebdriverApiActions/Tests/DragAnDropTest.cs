using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Configuration;
using WebdriverApiActions.Pages;

namespace WebdriverApiActions.Tests
{
    class DragAnDropTest
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        private string browser;
        public static string baseURL;

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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            baseURL = "https://html5demos.com/drag/";
        }
                       
        [Test]
        public void TestHTML5DragNDrop()
        {
            DragAndDropPage dragAndDropPage = new DragAndDropPage(driver, wait);
            dragAndDropPage.GoToHomePage(baseURL);
           
            IList elementsBefore = dragAndDropPage.GetElementsList();
            
            dragAndDropPage.DragItems(dragAndDropPage.one);
            dragAndDropPage.DragItems(dragAndDropPage.three);
            
            IList elementsAfter = dragAndDropPage.GetElementsList();

            Assert.AreEqual(elementsBefore.Count - 2, elementsAfter.Count);

            for (int i = 0; i < elementsBefore.Count-elementsAfter.Count; i++)
            {
                Assert.IsTrue(dragAndDropPage.CheckDOMTree(i + 1));
            }
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
