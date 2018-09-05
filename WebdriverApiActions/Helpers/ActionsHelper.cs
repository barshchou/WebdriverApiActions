using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using WebdriverApiActions.Pages;
using OpenQA.Selenium.Support.UI;

namespace WebdriverApiActions.Helpers
{
   class ActionsHelper : BaseHelper
    {
        public Actions action;    

        public void Hover(IWebElement webElement)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(webElement));          
            action = new Actions(Driver);
            action.MoveToElement(webElement).Perform();
        }

        public void Click(IWebElement webElement)
        {
            action = new Actions(Driver);
            action.Click(webElement).Perform();
        }

        public void SendKeys(IWebElement webElement, string text)
        {
            action = new Actions(Driver);
            action.SendKeys(webElement, text).Perform();
        }
    }
}
