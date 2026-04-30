using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class DetalhesOcorrenciaPage : ContentPage
{
    public DetalhesOcorrenciaPage(DetalhesOcorrenciaViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}