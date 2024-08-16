using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlaceSearch.Views
{	
	public partial class MainPage : ContentPage
	{	
		public MainPage ()
		{
			InitializeComponent ();
            BindingContext = ViewModelLocator.MainViewModel;
        }
        private async void OnPlaceSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
                return;

            if (e.CurrentSelection[0] is Models.PlaceData place)
            {
                // Navigate to location details page
                await Navigation.PushAsync(new LocationDetailsPage(place.PlaceId));

                // Clear the selection
                if (sender is CollectionView collectionView)
                {
                    collectionView.SelectedItem = null;
                }
            }
        }

    }
}

