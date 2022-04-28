using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium.Utils
{
    public class Browsers
    {
        public BrowsersList browser;
        public enum BrowsersList
        {
            Chrome,
            Firefox
        }
        public Browsers(BrowsersList browser)
        {
            this.browser = browser;
        }

        public IWebDriver GetDriver()
        {
            if (browser == BrowsersList.Chrome)
            {
                return new ChromeDriver();
            }
            else if (browser == BrowsersList.Firefox)
            {
                return new FirefoxDriver();
            }
            return null;
        }
    }
}
