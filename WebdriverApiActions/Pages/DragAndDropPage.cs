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
        private string baseURL;
        private ActionsHelper actionsHelper;
        private IWebDriver _driver;

        public DragAndDropPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
        }

        [FindsBy(How = How.Id, Using = "one")]
        private IWebElement one;

        [FindsBy(How = How.Id, Using = "two")]
        private IWebElement two;
        
        [FindsBy(How = How.Id, Using = "three")]
        private IWebElement three;
        
        [FindsBy(How = How.Id, Using = "four")]
        private IWebElement four;

        [FindsBy(How = How.Id, Using = "five")]
        private IWebElement five;

        [FindsBy(How = How.Id, Using = "bin")]
        private IWebElement placeToDrop;
        

        public DragAndDropPage DragItems()
        {
            actionsHelper.WaitForElementPresent(By.Id("bin"));
            actionsHelper.DragAndDrop(two, placeToDrop);
            actionsHelper.DragAndDrop(five, placeToDrop);
            return this;
        }
        

        public bool CheckDOMTree(int countAfter)
        {
            return (countAfter == _driver.FindElements(By.XPath("//div/p")).Count());
        }

        public int CountItems()//IWebDriver driver
        {
            actionsHelper.WaitForElementPresent(By.Id("bin"));
            int count = _driver.FindElements(By.XPath("//li/a")).Count();

            //for (int i = 0; i < count-1; i++)
            //{
            //    webElements.Add(driver.FindElement(By.TagName("//li[ " + i + "]")));
            //}

            return count;
        }
    }
}
