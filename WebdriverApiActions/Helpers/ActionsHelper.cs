using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebdriverApiActions.Helpers
{
    class ActionsHelper
    {
        public Actions action;
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        public ActionsHelper(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
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

        public void HoverAnClick(IWebElement webElement)
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

        public void SendKeys(IWebElement webElement, string text)
        {
            WaitForElementClickable(webElement);
            action = new Actions(_driver);
            action.SendKeys(webElement, text).Perform();
        }
        
        public void WaitForElementPresent(By by)
        {
            _wait.Until(ExpectedConditions.ElementExists(by));
        }
        
        public IWebElement WaitForElementClickable(IWebElement webElement)
        {
            _wait.Until(
                ExpectedConditions.ElementIsVisible(
                    By.CssSelector("a[title='Электроника - Мобильные телефоны и аксессуары']")));
            //_wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            return webElement;
        }
    }
}
