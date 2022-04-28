using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Utils
{
    public class Helpers
    {
        public static IWebElement? GetFirstVisibleElement(IReadOnlyCollection<IWebElement> elements)
        {
            foreach(IWebElement element in elements)
            {
                if (element.Displayed)
                {
                    return element;
                }
            }
            return null;
        }

        public static void ClickFirstVisibleElement(IReadOnlyCollection<IWebElement> elements)
        {
            var element = GetFirstVisibleElement(elements);
            if (element != null)
            {
                element.Click();
            }
            else
            {
                throw new Exception("No visible elements found");
            }
        }

        public static void ClickWithTimeout(IWebDriver driver, Mode mode, string selector)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IWebElement? element = null;

            if (mode == Mode.CSS)
            {
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(selector)));
            }
            else if (mode == Mode.XPath)
            {
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(selector)));
                
            }

            element?.Click();
        }
        
        public static void ClickWithTimeout(IWebDriver driver, IWebElement element)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public static void FillWithTimeout(IWebDriver driver, Mode mode, string selector, string keys)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IWebElement? element = null;

            if (mode == Mode.CSS)
            {
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(selector)));
            }
            else if (mode == Mode.XPath)
            {
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(selector)));

            }

            element?.SendKeys(keys);
        }

        public static IWebElement WaitForElementByCSS(IWebDriver driver, string selector, int timeout = 30)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(selector)));
        }

        public enum Mode
        {
            CSS,
            XPath
        }
    }
}
