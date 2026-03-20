using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class LocaisPage : ContentPage
{
    public LocaisPage()
    {
        InitializeComponent();
        BindingContext = new LocaisViewModel();
    }
}