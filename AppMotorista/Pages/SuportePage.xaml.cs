using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class SuportePage : ContentPage
{
	public SuportePage()
	{
		InitializeComponent();
		BindingContext = new SuporteViewModel();
	}
}