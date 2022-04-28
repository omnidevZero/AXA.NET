using OpenQA.Selenium;
using Selenium.Utils;
using System.Configuration;

namespace Selenium.Tests
{
    public class TestBase : IDisposable
    {
        public IWebDriver driver;

        public TestBase()
        {
            var currentConfigBrowser = ConfigurationManager.AppSettings["Browser"];
            Browsers browsers = new Browsers((Browsers.BrowsersList)Enum.Parse(typeof(Browsers.BrowsersList), currentConfigBrowser));
            driver = browsers.GetDriver();
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
