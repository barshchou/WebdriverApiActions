using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebdriverApiActions.Pages
{
    class BaseHelper
    {
        private IWebDriver _driver;
        public Actions action;

        public BaseHelper(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public void WaitForElementPresent(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public void WaitForElementClickable(IWebElement webElement)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        public void Hover(IWebElement webElement)
        {
            action = new Actions(_driver);
            WaitForElementClickable(webElement);
            action.MoveToElement(webElement).Build().Perform();
        }

        public void Click(IWebElement webElement)
        {
            action = new Actions(_driver);
            WaitForElementClickable(webElement);
            action.Click(webElement).Build().Perform();
        }

        public void SendKeys(IWebElement webElement, string text)
        {
            WaitForElementClickable(webElement);
            action = new Actions(_driver);
            action.SendKeys(webElement, text).Perform();
        }

        public void HoverAndClick(IWebElement webElement)
        {
            action = new Actions(_driver);
            WaitForElementClickable(webElement);
            action.MoveToElement(webElement).Click().Build().Perform();
        }

        public void MouseHoverByJavaScript(IWebElement targetElement)
        {
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                                "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                                "arguments[0].dispatchEvent(evObj);";
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            js.ExecuteScript(javaScript, targetElement);
        }
    }
}
