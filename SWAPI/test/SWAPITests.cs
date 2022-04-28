using Newtonsoft.Json.Linq;
using SWAPI.src;
using Xunit;

namespace SWAPI.test
{
    public class SWAPITests
    {
        [Fact]
        public async void CheckIfLukeIsFromTatooine()
        {
            const int LukeId = 1;
            var data = await PeopleData.GetDataById(LukeId);
            var name = data["name"]?.ToString();
            var homeworldUrl = data["homeworld"]?.ToString();
            var homeworldData = await PeopleData.GetHomeworldByUrl(homeworldUrl);
            var homeworldName = homeworldData["name"]?.ToString();

            Assert.Equal("Luke Skywalker", name);
            Assert.Equal("Tatooine", homeworldName);
        }
    }
}