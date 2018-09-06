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

        public void DragAndDrop(IWebElement from, IWebElement to)
        {
            //action = new Actions(driver);
            //action.DragAndDrop(from, to).Build().Perform();
            
            action = new Actions(driver);
            var dragAndDrop = action.ClickAndHold(from)
                //.MoveByOffset(-1, -1)
                .MoveToElement(to)
                .Release(to)
                .Build();
            dragAndDrop.Perform();
        }

        public void WaitForElementPresent(By by)
        {
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public void WaitForElementClickable(IWebElement webElement)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }
    }
}
