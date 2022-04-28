using System.Net.Http.Json;

namespace SWAPI
{
    public class HttpRequests
    {
        public static async Task<string> Get(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(url);
            return response;
        }

        public static readonly string PeopleEndpoint = "https://swapi.dev/api/people/";
        public static readonly string PlanetsEndpoint = "https://swapi.dev/api/planets/";
    }
}