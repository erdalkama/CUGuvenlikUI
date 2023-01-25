using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel _viewModel;

	public MainPage(MainPageViewModel viewModel)
	{
		this.BindingContext= viewModel;
		_viewModel= viewModel;
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetTaskCommand.Execute(null);
    }


}

