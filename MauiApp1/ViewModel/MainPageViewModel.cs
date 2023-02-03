using CommunityToolkit.Mvvm.Input;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public partial class MainPageViewModel
    {
        public ObservableCollection<Model.Location> Locations { get; set; } = new();
        readonly IConnectivity connectivity;
        readonly LocationService locationService;

        public MainPageViewModel(IConnectivity connectivity, LocationService locationService)
        {
            this.connectivity = connectivity;
            this.locationService = locationService;
        }

        [RelayCommand]
        async Task GetTaskAsync()
        {
             if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("İnternet bağlantısı yok", "Lütfen bağlantınızı kontrol edin", "Tamam");
                return;
            }
            try
            {
                var location = await locationService.GetLocationsAsync();
                if (Locations.Count != 0) Locations.Clear();
                location.ForEach(location => Locations.Add(location));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Veri okunamadı", ex.Message, "Tamam");
            }
        }
      
    }
}
