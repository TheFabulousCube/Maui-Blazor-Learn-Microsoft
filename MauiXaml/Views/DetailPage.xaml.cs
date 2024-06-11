using MauiXaml.ViewModel;

namespace MauiXaml.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

}