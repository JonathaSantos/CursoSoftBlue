using ImcMauiApp.Mvvm.ViewModels;

namespace ImcMauiApp.Mvvm.Views;

public partial class ImcView : ContentPage
{
	public ImcView()
	{
		InitializeComponent();
		BindingContext = new ImcViewModel();
	}
}