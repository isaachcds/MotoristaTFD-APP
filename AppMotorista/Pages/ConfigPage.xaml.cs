using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class ConfigPage : ContentPage
{
    public ConfigPage()
    {
        InitializeComponent();
        BindingContext = new ConfigViewModel();
    }
}