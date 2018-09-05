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
        public IWebDriver driver;
        public WebDriverWait wait;
        public string baseURL = "https://ebay.com";
        
        public void WaitPageLoad(IWebDriver driver, WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.UrlToBe(driver.Url));
        }

        public void GoToHomePage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public bool IsElementPresent(IWebDriver driver, By by)
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

        public string GetUrl(IWebDriver driver)
        {
            return driver.Url;
        }

    }
}
