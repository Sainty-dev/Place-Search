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
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public Command SearchPlacesCommand { get; }

        public async Task SearchPlacesAsync()
        {
            _isLoading = true;
            if (string.IsNullOrWhiteSpace(SearchQuery))
                return;

            var response = await _locationService.SearchPlacesAsync(SearchQuery);

            Places.Clear();
            foreach (var place in response.Data)
            {
                Places.Add(place);
            }
           _isLoading = false;
        }
    }
}


