using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PlaceSearch.Models;
using PlaceSearch.Services;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace PlaceSearch.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ILocationService _locationService;
        public ObservableCollection<PlaceData> Places { get; set; } = new ObservableCollection<PlaceData>();

        public MainViewModel(ILocationService locationService)
        {
            _locationService = locationService;
            SearchPlacesCommand = new Command(async () => await SearchPlacesAsync());
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }
       

        public Command SearchPlacesCommand { get; }

        public async Task SearchPlacesAsync()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Searching...");
                Places.Clear(); // clear the list

                if (string.IsNullOrWhiteSpace(SearchQuery))
                {
                    UserDialogs.Instance.Alert("Please enter search criteria.");
                    return; // exit method if no search criteria
                }

                var response = await _locationService.SearchPlacesAsync(SearchQuery);
                if (response.Data.Count == 0)
                {
                    UserDialogs.Instance.Alert("No places found matching your search criteria.");
                }
                else
                {
                    foreach (var place in response.Data)
                    {
                        Places.Add(place);
                    }
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex?.Message, "An Error Occurred");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

    }
}


