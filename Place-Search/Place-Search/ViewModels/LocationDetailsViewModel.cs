using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PlaceSearch.Models;
using PlaceSearch.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace PlaceSearch.ViewModels
{
    public class LocationDetailsViewModel : BaseViewModel
    {
        private readonly ILocationService _locationService;
        private string _url;

        public LocationDetailsViewModel(ILocationService locationService)
        {
            _locationService = locationService;
            OpenUrlCommand = new Command(async () => await OpenUrl());
        }
        public ICommand OpenUrlCommand { get; }

        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }
        private LocationDetailsResponse _locationDetails;
        public LocationDetailsResponse LocationDetails
        {
            get => _locationDetails;
            set
            {
                _locationDetails = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadLocationDetailsAsync(string placeId)
        {
            var response = await _locationService.GetPlaceDetailsAsync(placeId);
            LocationDetails = response;
        }
        private async Task OpenUrl()
        {
            if (!string.IsNullOrWhiteSpace(LocationDetails.Data.Url))
            {
                await Browser.OpenAsync(LocationDetails.Data.Url, BrowserLaunchMode.SystemPreferred);
            }
        }
    }
}


