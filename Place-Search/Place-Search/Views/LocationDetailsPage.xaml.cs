using System;
using System.Collections.Generic;
using PlaceSearch.Models;
using PlaceSearch.ViewModels;
using Xamarin.Forms;
namespace PlaceSearch.Views
{	
	public partial class LocationDetailsPage : ContentPage
	{	
		public LocationDetailsPage (string placeId)
		{
			InitializeComponent ();
            BindingContext = new LocationDetailsViewModel(ViewModelLocator.LocationService);
            (BindingContext as LocationDetailsViewModel)?.LoadLocationDetailsAsync(placeId);
        }
	}
}

