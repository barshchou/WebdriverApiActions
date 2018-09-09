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
        private string baseURL;
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
        }
        
        
        public SmartphonesPage GoToSmartphonesPage()
        {
            actionsHelper.Hover(electronics);
            actionsHelper.HoverAnClick(cellPhones);
                                    
            return new SmartphonesPage(_driver, _wait);
        }

        [FindsBy(How = How.LinkText, Using = "Электроника")]
        private IWebElement electronics;

        [FindsBy(How = How.CssSelector, Using = "a[title='Электроника - Мобильные телефоны и аксессуары']")]
        private IWebElement cellPhones;
    }
}
