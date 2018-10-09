using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Helpers;

namespace WebdriverApiActions.Pages
{
    class HomePage : BaseHelper
    {
        private string baseURL;
        private IWebDriver _driver;
        
        [FindsBy(How = How.XPath, Using = "//tr/td[@role='listitem'][4]")]
        private IWebElement electronics;

        [FindsBy(How = How.XPath, Using = "//li/a[span[@class='icon cpa']]")]
        private IWebElement cellPhones;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public SmartphonesPage GoToSmartphonesPage()
        {
            MouseHoverByJavaScript(electronics);
            MouseHoverByJavaScript(cellPhones);
            Click(cellPhones);

            return new SmartphonesPage(_driver);
        }
    }
}
