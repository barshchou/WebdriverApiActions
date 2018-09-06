using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverApiActions.Helpers;

namespace WebdriverApiActions.Pages
{
    class DragAndDropPage : BasePage
    {
        //private string baseURL;
        private ActionsHelper actionsHelper;

        public DragAndDropPage(IWebDriver driver, WebDriverWait wait)
        {
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
        }

        [FindsBy(How = How.Id, Using = "one")]
        private IWebElement one;

        [FindsBy(How = How.XPath, Using = "//li[@id='two']")]
        private IWebElement two;
        
        [FindsBy(How = How.Id, Using = "three")]
        private IWebElement three;
        
        [FindsBy(How = How.Id, Using = "four")]
        private IWebElement four;

        [FindsBy(How = How.Id, Using = "five")]
        private IWebElement five;

        [FindsBy(How = How.XPath, Using = "//div[@id='bin']")]
        private IWebElement placeToDrop;

        public IWebElement JavascriptFindElement(IWebDriver driver, String element)
        {
            IWebElement webElement;// = driver.FindElement(By.XPath(element));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            webElement = (IWebElement)js.ExecuteScript("return document.getElementById("+element+")", element);
            return webElement;
        }

        public void /*DragAndDropPage*/ DragItems(IWebDriver driver)
        {
            actionsHelper.DragAndDrop(two, placeToDrop);
            actionsHelper.DragAndDrop(four, placeToDrop);

            //return new DragAndDropPage(driver, wait);
        }
        
        internal bool CheckDOMTree(IWebDriver driver, int countAfter)
        {
            return (countAfter == driver.FindElements(By.XPath("//div/p")).Count());
        }

        public int CountItems(IWebDriver driver)
        {
            int count = driver.FindElements(By.XPath("//li/a")).Count();

            //for (int i = 0; i < count-1; i++)
            //{
            //    webElements.Add(driver.FindElement(By.TagName("//li[ " + i + "]")));
            //}

            return count;
        }
    }
}
