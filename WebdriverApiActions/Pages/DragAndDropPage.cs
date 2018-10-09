using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebdriverApiActions.Helpers;
using System.Collections;

namespace WebdriverApiActions.Pages
{
    class DragAndDropPage : BaseHelper
    {
        private const string ITEMS = "//li/a";
        private string baseURL;
        private JavaScriptRunner scriptRunner;
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "#one")]
        public IWebElement one;

        [FindsBy(How = How.CssSelector, Using = "#two")]
        public IWebElement two;

        [FindsBy(How = How.CssSelector, Using = "#three")]
        public IWebElement three;

        [FindsBy(How = How.CssSelector, Using = "#four")]
        public IWebElement four;

        [FindsBy(How = How.CssSelector, Using = "#five")]
        public IWebElement five;

        [FindsBy(How = How.CssSelector, Using = "#bin")]
        public IWebElement placeToDrop;

        public DragAndDropPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            scriptRunner = new JavaScriptRunner(driver);
        }
        
        public void DragAndDropItemToBin(IWebElement webElement)
        {
            WaitForElementPresent(By.XPath(ITEMS));
            scriptRunner.DragAndDropItemToBin_Script(webElement);
        }

        public bool CheckItemMovedCorrectly(int i)
        {
            return IsElementPresent(By.CssSelector("#bin p:nth-of-type("+i+")")); 
        }

        public IList GetItemsToDropAvailableList()
        {
            return _driver.FindElements(By.XPath(ITEMS));
        }
    }
}
