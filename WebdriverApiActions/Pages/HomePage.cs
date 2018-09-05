using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Helpers;

namespace WebdriverApiActions.Pages
{
    class HomePage : BaseHelper
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private ActionsHelper actionsHelper;
                
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver);
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://ebay.com");
        }

        public SmartphonesPage GoToSmartphonesPage(IWebDriver driver)
        {
            actionsHelper.Hover(electronics);
            actionsHelper.Hover(cellPhones);
            actionsHelper.Click(cellPhones);
                                    
            return new SmartphonesPage(driver);
        }

        //public void IsPageloaded()
        //{
        //    wait.Until(ExpectedConditions.UrlToBe(driver.Url));
        //}

        //public bool IsElementPresent(By by)
        //{
        //    try
        //    {
        //        driver.FindElement(by);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        [FindsBy(How = How.LinkText, Using = "Электроника")]
        private IWebElement electronics;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Мобильные телефоны и аксессуары')]")]
        private IWebElement cellPhones;

        



    }
}
