using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverApiActions.Helpers;

namespace WebdriverApiActions.Pages
{
    class SmartphonesPage : BasePage
    {
        private ActionsHelper actionsHelper;
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public SmartphonesPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
        }
        
        public SearchResultsPage GoToSearchResultsPage(string searchText) 
        {
            categories.Click();
            music.Click();
            searchTextField.SendKeys(searchText);
            searchButton.Click();
                        
            return new SearchResultsPage(_driver, _wait);
        }

        public bool CheckPage()
        {
            return title.Displayed;
        }
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-cat']")]
        private IWebElement categories;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-cat']/option[@value='11233']")]
        private IWebElement music;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-ac']")]
        private IWebElement searchTextField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-btn']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='mainTitle'][contains(text(), 'Смартфоны')]")]
        private IWebElement title;
    }
}
