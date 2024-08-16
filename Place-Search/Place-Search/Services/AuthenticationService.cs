using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PlaceSearch.Models;
using Newtonsoft.Json;

namespace PlaceSearch.Services
{
	public class AuthenticationService: IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _tokenEndpoint;
        private string _token;

        public AuthenticationService(HttpClient httpClient, string clientId, string clientSecret, string tokenEndpoint)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _tokenEndpoint = tokenEndpoint;
        }

        public async Task<string> GetTokenAsync()
        {
            if (!string.IsNullOrEmpty(_token))
            {
                return _token;
            }

            var clientCredentials = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _clientId },
                { "client_secret", _clientSecret }
            };

            var requestContent = new FormUrlEncodedContent(clientCredentials);
            var response = await _httpClient.PostAsync(_tokenEndpoint, requestContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);
            _token = tokenResponse.AccessToken;

            return _token;
        }
    }
}

