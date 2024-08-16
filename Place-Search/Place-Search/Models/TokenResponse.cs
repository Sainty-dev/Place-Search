using System;
using Newtonsoft.Json;

namespace PlaceSearch.Models
{
	public class TokenResponse
	{
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}

