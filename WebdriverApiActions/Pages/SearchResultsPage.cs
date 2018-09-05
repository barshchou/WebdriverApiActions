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
        private ActionsHelper actionsHelper;
        private BaseHelper baseHelper;

        public SearchResultsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            PageFactory.InitElements(driver, this);
            baseHelper = new BaseHelper(driver, wait);
            actionsHelper = new ActionsHelper(driver, wait);
        }



    }
}
