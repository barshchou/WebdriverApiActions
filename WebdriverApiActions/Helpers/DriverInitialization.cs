using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebdriverApiActions.Helpers
{
    public class DriverInitialization
    {
        IWebDriver driver;
        private string browser;
        
        public IWebDriver InitializeDriver()
        {
            browser = ConfigurationManager.AppSettings["browser"];

            switch (browser)
            {
                case "Chrome":
                    string path1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    driver = new ChromeDriver(path1);
                    break;
                case "Firefox":
                    string path2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    
                    //FirefoxOptions options = new FirefoxOptions();
                    //options.BrowserExecutableLocation = path2;
                    driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(path2));
                    break;
                default:
                    throw new Exception($"{browser} driver can not be initialized");
            }

            return driver;
        }
    }
}
