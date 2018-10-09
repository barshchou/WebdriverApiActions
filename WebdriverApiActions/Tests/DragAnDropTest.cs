using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Configuration;
using WebdriverApiActions.Helpers;
using WebdriverApiActions.Pages;

namespace WebdriverApiActions.Tests
{
    class DragAnDropTest
    {
        public static IWebDriver Driver { get; set; }
        public static WebDriverWait wait;
        public static string baseURL;

        [SetUp]
        public void Initialize()
        {
            DriverInitialization driverInitialization = new DriverInitialization();
            Driver = driverInitialization.InitializeDriver();
            Driver.Manage().Window.Maximize();
            baseURL = "https://html5demos.com/drag/";
        }
                       
        [Test]
        public void TestHTML5DragNDrop()
        {
            DragAndDropPage dragAndDropPage = new DragAndDropPage(Driver);
            Driver.Navigate().GoToUrl(baseURL);
            
            IList itemsToDropBefore = dragAndDropPage.GetItemsToDropAvailableList();
            
            dragAndDropPage.DragAndDropItemToBin(dragAndDropPage.one);
            dragAndDropPage.DragAndDropItemToBin(dragAndDropPage.three);

            IList itemsToDropAfter = dragAndDropPage.GetItemsToDropAvailableList();

            Assert.AreEqual(itemsToDropBefore.Count - 2, itemsToDropAfter.Count);
            
            for (int i = 0; i < itemsToDropBefore.Count- itemsToDropAfter.Count; i++)
            {
                Assert.IsTrue(dragAndDropPage.CheckItemMovedCorrectly(i + 1));
            }
        }
        
        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
