using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace WebdriverApiActions.Pages
{
    class HomePage
    {
        //TODO
        //Реализовать возможность выбора браузера через файл проперти

        //IWebDriver driver = new FirefoxDriver();

        IWebDriver driver; //= new ChromeDriver();
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://ebay.com");
        }

        public SmartphonesPage Hover()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(electronics).Perform();
            action.MoveToElement(cellPhones).Perform();
            action.Click().Perform();
            
            //wait.Until(ExpectedConditions.UrlToBe("https://www.ebay.com/rpp/GBH-DCP-Electronics-Cell"));

            return new SmartphonesPage(driver);
        }

        [FindsBy(How = How.LinkText, Using = "Электроника")]
        private IWebElement electronics;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Мобильные телефоны и аксессуары')]")]
        private IWebElement cellPhones;

        



    }
}
