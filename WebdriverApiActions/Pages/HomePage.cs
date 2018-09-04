using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Helpers;

namespace WebdriverApiActions.Pages
{
    class HomePage
    {
        //TODO
        //Реализовать возможность выбора браузера через файл проперти

        //IWebDriver driver = new FirefoxDriver();

        IWebDriver driver;
        private WebDriverWait wait;
        private ActionsHelper actionsHelper;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver);
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://ebay.com");
        }

        public SmartphonesPage GoToSmartphonesPage(IWebDriver driver)
        {
            actionsHelper.Hover(electronics);
            actionsHelper.Hover(cellPhones);
            actionsHelper.Click(cellPhones);

            //wait.Until(ExpectedConditions.UrlToBe("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell"));

            return new SmartphonesPage(driver);
        }

        [FindsBy(How = How.LinkText, Using = "Электроника")]
        private IWebElement electronics;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Мобильные телефоны и аксессуары')]")]
        private IWebElement cellPhones;

        



    }
}
