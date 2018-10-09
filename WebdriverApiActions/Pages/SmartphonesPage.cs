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
    class SmartphonesPage : BaseHelper
    {
        private IWebDriver _driver;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-cat']")]
        private IWebElement categories;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-cat']/option[@value='11233']")]
        private IWebElement music;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-ac']")]
        private IWebElement searchTextField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-btn']")]
        private IWebElement searchButton;
        
        public SmartphonesPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public SearchResultsPage PerformSearch(string searchText)
        {
            Click(categories);
            Click(music);
            SendKeys(searchTextField, searchText);
            Click(searchButton);

            return new SearchResultsPage(_driver);
        }
    }
}
