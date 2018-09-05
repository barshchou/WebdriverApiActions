using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdriverApiActions.Helpers
{
    class BaseHelper
    {
        
        public BaseHelper(IWebDriver driver, WebDriverWait wait)
        {
            
        }

        public void WaitPageLoad(IWebDriver driver, WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.UrlToBe(driver.Url));
            wait.Until(ExpectedConditions.UrlToBe("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell"));
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                wait.Timeout = TimeSpan.FromSeconds(5);
                //driver.FindElement(by);
                wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
