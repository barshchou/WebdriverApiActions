using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebdriverApiActions.Pages
{
    class BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void WaitPageLoad() 
        {
            _wait.Until(ExpectedConditions.UrlToBe(_driver.Url));
        }

        public void WaitForElementPresent(By by)
        {
            _wait.Until(ExpectedConditions.ElementExists(by));
        }

        public void GoToHomePage(string baseURL)
        {
            _driver.Navigate().GoToUrl(baseURL);
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

        public string GetUrl()
        {
            return _driver.Url;
        }
    }
}
