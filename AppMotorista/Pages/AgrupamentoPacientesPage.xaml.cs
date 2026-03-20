using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class AgrupamentoPacientesPage : ContentPage
{
    public AgrupamentoPacientesPage()
    {
        InitializeComponent();
        BindingContext = new AgrupamentoPacientesViewModel();
    }
}