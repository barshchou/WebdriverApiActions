using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebdriverApiActions.Helpers
{
    class ActionsHelper
    {
        public Actions action;
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public ActionsHelper(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void Hover(IWebElement webElement)
        {
            WaitForElementClickable(webElement);          
            action = new Actions(driver);
            action.MoveToElement(webElement).Perform();
        }

        
        public void Click(IWebElement webElement)
        {
            WaitForElementClickable(webElement);
            action = new Actions(driver);
            action.Click(webElement).Perform();
        }

        public void SendKeys(IWebElement webElement, string text)
        {
            WaitForElementClickable(webElement);
            action = new Actions(driver);
            action.SendKeys(webElement, text).Perform();
        }

        public void DargAndDrop(IWebElement from, IWebElement to)
        {
            action = new Actions(driver);
            action.ClickAndHold(from).MoveToElement(to).Release(to).Build();
            action.Perform();
        }

        private void WaitForElementClickable(IWebElement webElement)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }
    }
}
