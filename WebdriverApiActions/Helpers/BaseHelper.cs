using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdriverApiActions.Helpers
{
    public class BaseHelper
    {
        public static IWebDriver Driver;
        public static WebDriverWait Wait;       
     

        public void WaitPageLoad()
        {
            Wait.Until(ExpectedConditions.UrlToBe(Driver.Url));
            Wait.Until(ExpectedConditions.UrlToBe("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell"));
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                Wait.Timeout = TimeSpan.FromSeconds(5);
                //driver.FindElement(by);
                Wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
