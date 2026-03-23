using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class OcorrenciaFormPage : ContentPage
{
    public OcorrenciaFormPage()
    {
        InitializeComponent();
        BindingContext = new OcorrenciaFormViewModel();
    }
}