using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Helpers;

namespace WebdriverApiActions.Pages
{
    class HomePage : BaseHelper
    {
        //private IWebDriver driver;
        //private WebDriverWait wait;
        private ActionsHelper actionsHelper;
        private BaseHelper baseHelper;
        private string baseURL;
                
        public HomePage(IWebDriver driver, WebDriverWait wait) : base()
        {           
            PageFactory.InitElements(driver, this);
            baseHelper = new BaseHelper();
            actionsHelper = new ActionsHelper();
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public SmartphonesPage GoToSmartphonesPage(IWebDriver driver)
        {
            actionsHelper.Hover(electronics);
            actionsHelper.Hover(cellPhones);
            actionsHelper.Click(cellPhones);
                                    
            return new SmartphonesPage(driver, wait);
        }

        [FindsBy(How = How.LinkText, Using = "Электроника")]
        private IWebElement electronics;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Мобильные телефоны и аксессуары')]")]
        private IWebElement cellPhones;

        



    }
}
