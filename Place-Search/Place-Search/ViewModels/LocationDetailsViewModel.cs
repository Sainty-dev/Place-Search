using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
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
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");
                var response = await _locationService.GetPlaceDetailsAsync(placeId);
                LocationDetails = response;

                
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.Alert(ex?.Message, "An Error Occurred");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
           
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


