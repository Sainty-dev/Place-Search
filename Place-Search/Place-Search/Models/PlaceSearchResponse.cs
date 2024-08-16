using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PlaceSearch.Models
{
    public class PlaceSearchResponse
    {
        [JsonPropertyName("data")]
        public List<PlaceData> Data { get; set; }

        [JsonPropertyName("meta")]
        public MetaData Meta { get; set; }
    }
    public class PlaceData
    {
        [JsonPropertyName("placeId")]
        public string PlaceId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("mainText")]
        public string MainText { get; set; }

        [JsonPropertyName("secondaryText")]
        public string SecondaryText { get; set; }

        [JsonPropertyName("terms")]
        public List<Term> Terms { get; set; }

        [JsonPropertyName("types")]
        public List<int> Types { get; set; }
    }
    public class Term
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("offset")]
        public string Offset { get; set; }
    }
    public class MetaData
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}

