using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Pages;
using System.Reflection;
using Xunit;

namespace Selenium.test
{
    public class GoogleMapsTests
    {
        private string gmapsUrl = "https://www.google.pl/maps/";

        [Fact]
        public void CheckDistance()
        {
            using IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(gmapsUrl);

            Consent consent = new Consent(driver);
            consent.AcceptTerms();

            Maps maps = new Maps(driver);
            maps.SearchFromTo("Plac Defilad 1", "Chłodna 51");
            maps.ChangeTravelMode(Maps.TravelMode.Walking);
            var walkingTravelData = maps.GetTravelData();
            maps.ChangeTravelMode(Maps.TravelMode.Cycling);
            var cyclingTravelData = maps.GetTravelData();
            maps.ReverseDirection();
            maps.ChangeTravelMode(Maps.TravelMode.Walking);
            var walkingTravelDataReversed = maps.GetTravelData();
            maps.ChangeTravelMode(Maps.TravelMode.Cycling);
            var cyclingTravelDataReversed = maps.GetTravelData();

            Assert.True(
                walkingTravelData["time"] < 40 &&
                walkingTravelData["distance"] < 3 &&
                cyclingTravelData["time"] < 15 &&
                cyclingTravelData["distance"] < 3 &&
                walkingTravelDataReversed["time"] < 40 &&
                walkingTravelDataReversed["distance"] < 3 &&
                cyclingTravelDataReversed["time"] < 15 &&
                cyclingTravelDataReversed["distance"] < 3
            );
        }
    }
}