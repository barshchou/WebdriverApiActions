using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            string path1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Scripts\drag_and_drop_helper.js");
            string path2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Scripts\jquery.js");
            string script = File.ReadAllText(path1);
            string jquery = File.ReadAllText(path2);

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
