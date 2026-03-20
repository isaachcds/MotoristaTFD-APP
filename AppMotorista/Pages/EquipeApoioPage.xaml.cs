using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class EquipeApoioPage : ContentPage
{
    public EquipeApoioPage()
    {
        InitializeComponent();
        BindingContext = new EquipeApoioViewModel();
    }
}