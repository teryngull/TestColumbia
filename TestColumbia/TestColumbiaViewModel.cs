using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TestColumbia
{
    public class TestColumbiaViewModel : BaseViewModel
    {
        string _searchedLatitude = string.Empty;
        public string SearchedLatitude
        {
            get => _searchedLatitude;
            set { _searchedLatitude = value;
                OnPropertyChanged(); }
        }

        string _searchedLongitude = string.Empty;
        public string SearchedLongitude
        {
            get => _searchedLongitude;
            set
            {
                _searchedLongitude = value;
                OnPropertyChanged();
            }
        }

        string _currentLatitude = string.Empty;
        public string CurrentLatitude
        {
            get => _currentLatitude;
            set
            {
                _currentLatitude = value;
                OnPropertyChanged();
            }
        }

        string _currentLongitude = string.Empty;
        public string CurrentLongitude
        {
            get => _currentLongitude;
            set
            {
                _currentLongitude = value;
                OnPropertyChanged();
            }
        }

        Command _geocoderColumbia;
        public Command GeocoderColumbiaCommand => _geocoderColumbia ??
            (_geocoderColumbia = new Command(async () => await GetLatLongForColumbiaCommand()));

        Command _getCurrentLocation;
        public Command GetCurrentLocationCommand => _getCurrentLocation ??
            (_getCurrentLocation = new Command(async () => await ExecuteGetCurrentLocationCommand()));

        public TestColumbiaViewModel()
        {
        }

        async Task GetLatLongForColumbiaCommand()
        {
            try
            {
                var geoCoder = new Geocoder();

                IEnumerable<Position> locations = await geoCoder.GetPositionsForAddressAsync("Columbia, SC");

                var searchedPosition = locations.FirstOrDefault();

                SearchedLatitude = searchedPosition.Latitude.ToString();
                SearchedLongitude = searchedPosition.Longitude.ToString();
            }
            catch (Exception ex)
            {
                
            }
        }

        async Task ExecuteGetCurrentLocationCommand()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    return;
                }

                var currentLocation = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));

                if (currentLocation == null)
                    return;

                CurrentLatitude = currentLocation.Latitude.ToString();
                CurrentLongitude = currentLocation.Longitude.ToString();
            }
            catch (Exception ex)
            {
                //Display error as we have timed out or can't get location.
            }

        }

    }
}
