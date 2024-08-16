using System;
using Microsoft.Extensions.DependencyInjection;
using PlaceSearch;
using PlaceSearch.Services;
using PlaceSearch.ViewModels;
using PlaceSearch.Views;
using RestSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Place_Search
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public App ()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Build service provider
            Services = serviceCollection.BuildServiceProvider();

            MainPage = new NavigationPage(new MainPage());
        }
        private void ConfigureServices(IServiceCollection services)
        {


           services.AddSingleton<IRestClient, RestClient>(provider => new RestClient(Constants.BaseUrl));

            services.AddSingleton<AuthenticationService>(provider =>
                new AuthenticationService(provider.GetRequiredService<IRestClient>(), Constants.ClientId, Constants.ApiKey));
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LocationDetailsViewModel>();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

