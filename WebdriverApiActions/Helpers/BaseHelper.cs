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
        IWebDriver driver;
        private WebDriverWait wait;

        public BaseHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void IsPageloaded()
        {
            wait.Until(ExpectedConditions.UrlToBe(driver.Url));
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
