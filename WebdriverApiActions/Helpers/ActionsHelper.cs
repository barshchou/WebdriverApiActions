using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace WebdriverApiActions.Helpers
{
    class ActionsHelper
    {
        private IWebDriver driver;

        Actions action;
        
        public void Hover(IWebElement webElement)
        {
            action = new Actions(driver);
            action.MoveToElement(webElement).Perform();
        }

        public void Click(IWebElement webElement)
        {
            action = new Actions(driver);
            action.Click(webElement).Perform();
        }

        public void SendKeys(IWebElement webElement, string text)
        {
            action = new Actions(driver);
            action.SendKeys(webElement, text).Perform();
        }


    }
}
