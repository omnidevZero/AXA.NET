using Newtonsoft.Json.Linq;

namespace SWAPI.src
{
    public class PeopleData
    {
        public static async Task<JObject> GetDataById(int id)
        {
            var data = await HttpRequests.Get($"{HttpRequests.PeopleEndpoint}{id}");
            var json = JObject.Parse(data);
            return json;
        }

        public static async Task<JObject> GetHomeworldByUrl(string url)
        {
            var data = await HttpRequests.Get(url);
            var json = JObject.Parse(data);
            return json;
        }
    }
}
