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
            var acceptButton = driver.FindElements(By.CssSelector(AcceptButton));
            if (acceptButton.Count() > 0)
            {
                acceptButton[0].Click();
            }
        }

        private static readonly string AcceptButton = "#change-me-when-google-adds-consent-page-back";
    }
}