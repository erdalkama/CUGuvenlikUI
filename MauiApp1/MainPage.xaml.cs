using MauiApp1.ViewModel;
using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        this.BindingContext = viewModel;
        _viewModel = viewModel;
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetTaskCommand.Execute(null);
        await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }
    public async void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        // Handle the tap
        if (DeviceInfo.Current.Idiom==DeviceIdiom.Desktop)
        {
            if (args.Buttons == ButtonsMask.Primary)
            {
                Console.WriteLine("askdjgkasdhlasdj");
               
            }
        }
        if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone)
        {
            Console.WriteLine("askdjgkasdhlasdj");
            var placemark = new Placemark
            {
                CountryName = "Turkey",   
                Thoroughfare = "Cukurova University",
                Locality = "Adana"
            };
            
            var options = new MapLaunchOptions
            {
                Name = "Çukurova Üniversitesi Rektörlüğü Öğrenci İşleri",
                NavigationMode = NavigationMode.Driving
            };

            try
            {
                await placemark.OpenMapsAsync(options);

            }
            catch (Exception ex)
            {
                // No map application available to open or placemark can not be located
            }
        }

    }



}

