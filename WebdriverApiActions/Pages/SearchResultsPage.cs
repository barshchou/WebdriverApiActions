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
        
        public SearchResultsPage(IWebDriver driver, WebDriverWait wait)
        {
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
        }
    }
}
