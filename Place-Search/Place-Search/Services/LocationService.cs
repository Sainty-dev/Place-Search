using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlaceSearch.Models;

namespace PlaceSearch.Services
{
	public class LocationService: ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthenticationService _authService;

        public LocationService(HttpClient httpClient, IAuthenticationService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<IEnumerable<Place>> SearchPlacesAsync(string query)
        {
            var token = await _authService.GetTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"/api/v1/locations/places?query={query}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var places = JsonConvert.DeserializeObject<IEnumerable<Place>>(content);
            return places;
        }

        public async Task<LocationDetails> GetLocationDetailsAsync(string placeId)
        {
            var token = await _authService.GetTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"/api/v1/locations/places/{placeId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var details = JsonConvert.DeserializeObject<LocationDetails>(content);
            return details;
        }
    }
}

