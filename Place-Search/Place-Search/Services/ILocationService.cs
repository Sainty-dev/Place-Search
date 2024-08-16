using System;
using PlaceSearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaceSearch.Services
{
	public interface ILocationService
	{
        Task<IEnumerable<Place>> SearchPlacesAsync(string query);
        Task<LocationDetails> GetLocationDetailsAsync(string placeId);
    }
}

