using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public partial class LocationService
    {
        HttpClient httpClient;
        public LocationService()
        {
            httpClient = new HttpClient();
        }
        List<Location> locations = new();

        public async Task<List<Location>> GetLocationsAsync()
        {
            if (locations?.Count > 0)
                return locations;

            var url = "https://my-json-server.typicode.com/e534e71/mockjson/Locations";
            var response=await httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                locations=await response.Content.ReadFromJsonAsync<List<Location>>(); 
            }
            return locations;
        }
    }
}
