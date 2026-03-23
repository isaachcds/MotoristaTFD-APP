using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class AlertasPage : ContentPage
{
	public AlertasPage()
	{
		InitializeComponent();
        BindingContext = new AlertasViewModel();
    }
}