using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdriverApiActions.Helpers
{
    class JavaScriptRunner
    {
        IWebDriver _driver;

        public JavaScriptRunner(IWebDriver driver)
        {
            this._driver = driver;
        }
        public void RunScript(IWebElement From)
        {
            string script = File.ReadAllText("C:\\drag_and_drop_helper.js");
            string jquery = File.ReadAllText("C:\\jquery.js");

            string from = From.Text;
            
            var js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript(jquery);
            js.ExecuteScript(script + "$('#"+ from +"').simulateDragDrop({ dropTarget: '#bin'});");
        }

        public string GetElementLocatorString(IWebElement webElement)
        {
            return webElement.GetCssValue("id");
        }
    }
}
