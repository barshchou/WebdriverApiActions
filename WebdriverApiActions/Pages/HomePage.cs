using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Helpers;

namespace WebdriverApiActions.Pages
{
    class HomePage : BasePage
    {
        private ActionsHelper actionsHelper;
        private string baseURL;// = "https://ebay.com";

        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
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
