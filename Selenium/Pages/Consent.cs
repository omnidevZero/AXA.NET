using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Utils;

namespace Selenium.Pages
{
    public class Consent
    {
        private IWebDriver driver;
        public Consent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AcceptTerms()
        {
            driver.FindElement(By.CssSelector(AcceptButton)).Click();
        }

        private static readonly string AcceptButton = "div > form";
    }
}
