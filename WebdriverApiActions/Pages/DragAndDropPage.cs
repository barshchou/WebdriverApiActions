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
using System.Collections;

namespace WebdriverApiActions.Pages
{
    class DragAndDropPage : BasePage
    {
        private string baseURL;
        private ActionsHelper actionsHelper;
        private JavaScriptRunner scriptRunner;
        private IWebDriver _driver;

        public DragAndDropPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
            scriptRunner = new JavaScriptRunner(driver);
        }

        [FindsBy(How = How.CssSelector, Using = "#one")]
        public IWebElement one;

        [FindsBy(How = How.CssSelector, Using = "#two")]
        public IWebElement two;
        
        [FindsBy(How = How.CssSelector, Using = "#three")]
        public IWebElement three;
        
        [FindsBy(How = How.CssSelector, Using = "#four")]
        public IWebElement four;

        [FindsBy(How = How.CssSelector, Using = "#five")]
        public IWebElement five;

        [FindsBy(How = How.CssSelector, Using = "#bin")]
        public IWebElement placeToDrop;
        

        public void DragItems(IWebElement webElement)
        {
            actionsHelper.WaitForElementPresent(By.XPath("//li/a"));
            scriptRunner.RunScript(webElement);
        }

        public bool CheckDOMTree(int i)
        {
            return IsElementPresent(By.CssSelector("#bin p:nth-of-type("+i+")")); 
        }

        public IList GetElementsList()
        {
            return _driver.FindElements(By.XPath("//li/a"));
        }
    }
}
