using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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
                    driver = new FirefoxDriver();
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
            dragAndDropPage.GoToHomePage(driver,baseURL);
            dragAndDropPage.WaitForElementPresent(driver, wait, By.CssSelector("#bin"));

            IList elementsBefore = dragAndDropPage.GetElementsList();
            
            dragAndDropPage.DragItems(dragAndDropPage.one);
            //Check text is moved into box
            dragAndDropPage.CheckDOMTree();

            dragAndDropPage.DragItems(dragAndDropPage.three);
            //Check text is moved into box
            dragAndDropPage.CheckDOMTree();

            IList elementsAfter = dragAndDropPage.GetElementsList();

            Assert.AreEqual(elementsBefore.Count - 2, elementsAfter.Count);

            

            Thread.Sleep(5000);
        }
        





        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
