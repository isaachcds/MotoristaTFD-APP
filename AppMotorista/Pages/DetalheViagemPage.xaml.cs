using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class DetalheViagemPage : ContentPage
{
    public DetalheViagemPage()
    {
        InitializeComponent();
        BindingContext = new DetalheViagemViewModel();
    }
}