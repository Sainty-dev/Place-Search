using System;
using Place_Search;
using PlaceSearch.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using PlaceSearch.Services;

namespace PlaceSearch
{
	public class ViewModelLocator
	{
        public static MainViewModel MainViewModel => App.Services.GetService<MainViewModel>();
        public static LocationDetailsViewModel LocationDetailsViewModel => App.Services.GetService<LocationDetailsViewModel>();
        public static ILocationService LocationService => App.Services.GetService<ILocationService>();
        public static AuthenticationService AuthenticationService => App.Services.GetService<AuthenticationService>();
    }
}

