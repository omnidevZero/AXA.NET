using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Utils;
using System.Text.RegularExpressions;

namespace Selenium.Pages
{
    public class Maps : Helpers
    {
        private IWebDriver driver;
        public Maps(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SearchFromTo(string from, string to)
        {
            var searchBoxButtons = driver.FindElements(By.CssSelector(SearchBoxButtons));
            searchBoxButtons[searchBoxButtons.Count - 1].Click();
            FillWithTimeout(driver, Mode.CSS, FromInput, from);
            FillWithTimeout(driver, Mode.CSS, ToInput, to);
            FillWithTimeout(driver, Mode.CSS, ToInput, Keys.Enter);
        }

        public void ChangeTravelMode(TravelMode mode)
        {
            driver.FindElement(By.CssSelector($"div[data-travel_mode='{(int)mode}'")).Click();
        }

        public Dictionary<string, double> GetTravelData()
        {
            var timeElement = WaitForElementByCSS(driver, Time);
            var time = timeElement.Text;
            var distance = driver.FindElement(By.CssSelector(Distance)).Text;
            time = time.Split()[0];
            distance = distance.Split()[0];
            //double[] data = new double[] { double.Parse(time), double.Parse(distance) };
            Dictionary<string, double> data = new Dictionary<string, double>();
            data.Add("time", double.Parse(time));
            data.Add("distance", double.Parse(distance));
            return data;
        }

        public void ReverseDirection()
        {
            driver.FindElement(By.CssSelector(ReverseButton)).Click();
        }

        public enum TravelMode
        {
            Cycling = 1,
            Walking = 2
        }

        private static readonly string SearchBoxButtons = "#searchbox button";
        private static readonly string FromInput = "#directions-searchbox-0 input";
        private static readonly string ToInput = "#directions-searchbox-1 input";
        private static readonly string Time = "#section-directions-trip-0 div[jsan]:nth-child(1)";
        private static readonly string Distance = "#section-directions-trip-0 div[jsan]:nth-child(2)";
        private static readonly string ReverseButton = "div.reverse";
    }
}
