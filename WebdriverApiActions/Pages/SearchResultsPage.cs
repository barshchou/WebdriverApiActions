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
    class SearchResultsPage : BaseHelper
    {
        
        private IWebDriver _driver;
        
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'esult') and contains(@class, 'clearfix')]/ul/li[1]")]
        private IWebElement result;

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool IsItemFound()
        {
            return result.Displayed;
        }
    }
}
