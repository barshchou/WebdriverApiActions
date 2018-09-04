using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebdriverApiActions.Pages;

namespace WebdriverApiActions
{
    class MouseOverTest
    {
        private IWebDriver driver;

        [SetUp]

        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchCellPhones()
        {
            HomePage home = new HomePage(driver);
            home.goToPage();
            SmartphonesPage smartphones = home.Hover();
            
            Assert.AreEqual("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell", smartphones.GetUrl());
        }
        
        [TearDown]
        
        public void TearDown()
        {
            driver.Close();
        }
    }
}
