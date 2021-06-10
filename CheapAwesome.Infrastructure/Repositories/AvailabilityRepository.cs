using CheapAwesome.Core.Entities;
using CheapAwesome.Core.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheapAwesome.Infrastructure.Repositories
{
    public class AvailabilityRepository: IAvailabilityRepository
    {
        public async Task<IEnumerable<Availability>> GetAvailability(string url, int timeout)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            client.Timeout = TimeSpan.FromMilliseconds(timeout);
            HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                Log.Information("Got response successfully");
                var responseString = await response.Content.ReadAsStringAsync();

                List<Availability> availability = DeserializeResponse(responseString);

                return availability;
            }
            else
            {
                Log.Error("An error happened getting the response");
                throw new Exception();
            }
        }

        private List<Availability> DeserializeResponse(string response)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                return JsonSerializer.Deserialize<List<Availability>>(response, options).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("An error happened when deserializing the response. {ex}", ex);
                return new List<Availability>();
            }
        }
    }
}
