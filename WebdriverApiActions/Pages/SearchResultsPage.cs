using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebdriverApiActions.Helpers;

namespace WebdriverApiActions.Pages
{
    class SearchResultsPage : BasePage
    {
        private ActionsHelper actionsHelper;
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public SearchResultsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
        }

        public bool ItemsFound()
        {
            return result.Displayed;
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'esult') and contains(@class, 'clearfix')]/ul/li[1]")]
        private IWebElement result;
    }
}
