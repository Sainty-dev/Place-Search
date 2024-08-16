using System;
using System.Threading.Tasks;

namespace PlaceSearch.Services
{
	public interface IAuthenticationService
	{
        Task<string> GetAccessTokenAsync();
    }
}

