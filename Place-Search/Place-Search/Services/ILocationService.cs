using System;
using PlaceSearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaceSearch.Services
{
	public interface ILocationService
	{
        Task<PlaceSearchResponse> SearchPlacesAsync(string query);
        Task<LocationDetailsResponse> GetPlaceDetailsAsync(string placeId);
    }
}

