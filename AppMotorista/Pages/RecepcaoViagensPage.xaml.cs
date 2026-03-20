using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class RecepcaoViagensPage : ContentPage
{
    public RecepcaoViagensPage()
    {
        InitializeComponent();
        BindingContext = new RecepcaoViagensViewModel();
    }
}