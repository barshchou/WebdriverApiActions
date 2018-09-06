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
    class DragAndDropPage : BasePage
    {
        private string baseURL = "https://html5demos.com/drag/";
        private ActionsHelper actionsHelper;

        public DragAndDropPage(IWebDriver driver, WebDriverWait wait)
        {
            PageFactory.InitElements(driver, this);
            actionsHelper = new ActionsHelper(driver, wait);
        }

        [FindsBy(How = How.Id, Using = "one")]
        private IWebElement one;

        [FindsBy(How = How.Id, Using = "two")]
        private IWebElement two;
        
        [FindsBy(How = How.Id, Using = "three")]
        private IWebElement three;
        
        [FindsBy(How = How.Id, Using = "four")]
        private IWebElement four;

        [FindsBy(How = How.Id, Using = "five")]
        private IWebElement five;

        [FindsBy(How = How.Id, Using = "bin")]
        private IWebElement placeToDrop;
    }
}
