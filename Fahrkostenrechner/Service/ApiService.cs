using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fahrkostenrechner.Model1;
using Newtonsoft.Json;
namespace Fahrkostenrechner.Service
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<ApiResponse> GetStationsAsync(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                return apiResponse;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<Station> GetFirstStationAsync(string apiUrl)
        {
            ApiResponse apiResponse = await GetStationsAsync(apiUrl);
            if (apiResponse != null && apiResponse.Ok && apiResponse.Stations != null && apiResponse.Stations.Count > 0)
            {
                return apiResponse.Stations.First();
            }
            return null;
        }
    }
}
