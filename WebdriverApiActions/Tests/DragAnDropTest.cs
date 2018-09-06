using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public void DragAndDropTest()
        {
            int countBefore = 0;
            int countAfter = 0;

            DragAndDropPage dragAndDropPage = new DragAndDropPage(driver, wait);
            dragAndDropPage.GoToHomePage(driver, baseURL);
            dragAndDropPage.WaitPageLoad(driver, wait);
            countBefore = dragAndDropPage.CountItems();
            dragAndDropPage.DragItems();
            countAfter = dragAndDropPage.CountItems();

            dragAndDropPage.CheckDOMTree(countAfter);

            if ((countBefore - 2) == countAfter)
            {
                return;
            }
        }

        [Test]
        public void DNDtest()
        {
            driver.Navigate().GoToUrl(baseURL);

            String filePath = "C://dnd2.js";
            String source = "a[id='one']";
            String target = "div[id='bin']";
            StringBuilder buffer = new StringBuilder();
            String line;
            StreamReader br = new StreamReader(filePath, Encoding.Default);
            while ((line = br.ReadLine()) != null)
                buffer.Append(line);
            
            String javaScript = buffer.ToString();
            
            javaScript = javaScript + "$('" + source + "').simulateDragDrop({ dropTarget: '" + target + "'});";
            ((IJavaScriptExecutor)driver).ExecuteScript(javaScript);
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
