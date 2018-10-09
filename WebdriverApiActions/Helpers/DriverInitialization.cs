using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
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
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path2, "geckodriver.exe");
                    FirefoxOptions options = new FirefoxOptions();
                    options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(10));
                    break;
                default:
                    throw new Exception($"{browser} driver can not be initialized");
            }

            return driver;
        }
    }
}
