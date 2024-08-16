using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PlaceSearch.Models;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Shapes;

namespace PlaceSearch.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRestClient _client;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public AuthenticationService(IRestClient client, string clientId, string clientSecret)
        {
            _client = client;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }
        /// <summary>
        /// Get the access token
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccessTokenAsync()
        {
            var request = new RestRequest(Constants.AuthUrl, Method.Post);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", "eos.common.fullaccess"); 
            request.AddParameter("client_id", _clientId);
            request.AddParameter("client_secret", _clientSecret);

            var response = await _client.ExecuteAsync<TokenResponse>(request);
            return response.IsSuccessful ? response.Data.AccessToken: null;
        }



        
    }
}

