using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using WebdriverApiActions.Pages;

namespace WebdriverApiActions.Helpers
{
    class ActionsHelper : BaseHelper
    {
        public Actions action;
        private IWebDriver driver;

        public ActionsHelper (IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

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
