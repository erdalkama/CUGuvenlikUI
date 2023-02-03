using MauiApp1.ViewModel;
using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.ApplicationModel.Communication;
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
        if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
        {
            if (args.Buttons == ButtonsMask.Primary)
            {
                Console.WriteLine("askdjgkasdhlasdj");
                var location = new Location(37.060037, 35.35538);

                var options = new MapLaunchOptions
                {
                    NavigationMode = NavigationMode.Driving

                };

                try
                {
                    await location.OpenMapsAsync(options);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // No map application available to open or placemark can not be located
                }
            }
        }
        if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone)
        {
            Console.WriteLine("askdjgkasdhlasdj");

            var location = new Location(37.060037, 35.35538);

            var options = new MapLaunchOptions
            {
                NavigationMode = NavigationMode.Driving

            };

            try
            {
                await location.OpenMapsAsync(options);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // No map application available to open or placemark can not be located
            }
            //if (PhoneDialer.Default.IsSupported)
            //    PhoneDialer.Default.Open("+905434103862");
        }

    }



}

