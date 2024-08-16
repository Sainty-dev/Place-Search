using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlaceSearch.Models;
using RestSharp;

namespace PlaceSearch.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRestClient _client;
        private readonly AuthenticationService _authService;

        public LocationService(IRestClient client, AuthenticationService authService)
        {
            _client = client;
            _authService = authService;
        }

        /// <summary>
        /// This method sets the Authorization header of the RestRequest with a Bearer token.
        /// It retrieves the token asynchronously using the _authService.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task SetAuthHeaderAsync(RestRequest request)
        {
            try
            {
                var token = await _authService.GetAccessTokenAsync();
                if (!string.IsNullOrEmpty(token))
                {
                    request.AddHeader("Authorization", $"Bearer {token}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting auth header: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// This method performs a search for places using a given query.
        /// It sets up the request, adds the query parameter, and executes the request.
        /// If successful, it returns the deserialized PlaceSearchResponse, otherwise returns a new empty response.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>PlaceSearchResponse</returns>
        public async Task<PlaceSearchResponse> SearchPlacesAsync(string query)
        {
            var request = new RestRequest("api/v1/locations/places", Method.Get);
            request.AddParameter("criteria", query);

            try
            {
                await SetAuthHeaderAsync(request);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var placeSearchResponse = JsonConvert.DeserializeObject<PlaceSearchResponse>(response.Content);
                    return placeSearchResponse;
                }
                else
                {
                    return new PlaceSearchResponse();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching places: {ex.Message}");
                return new PlaceSearchResponse();
            }
        }

        /// <summary>
        /// This method retrieves detailed information for a specific place using its ID.
        /// It sets up the request and executes it. If successful, it returns the deserialized LocationDetailsResponse.
        /// Otherwise, it returns a new empty response.
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns>LocationDetailsResponse</returns>
        public async Task<LocationDetailsResponse> GetPlaceDetailsAsync(string placeId)
        {
            var request = new RestRequest($"api/v1/locations/places/{placeId}", Method.Get);

            try
            {
                await SetAuthHeaderAsync(request);
                var response = await _client.ExecuteAsync<LocationDetailsResponse>(request);

                return response.IsSuccessful ? response.Data : new LocationDetailsResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting place details: {ex.Message}");
                return new LocationDetailsResponse();
            }
        }

    }
}

