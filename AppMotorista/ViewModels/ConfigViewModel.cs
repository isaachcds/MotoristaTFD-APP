using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class ConfigViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Configurações";
    [ObservableProperty] private string nomeMotorista = "Gabriel Almeida";
    [ObservableProperty] private string emailMotorista = "gabriel.almeida@email.com";
    [ObservableProperty] private bool notificacoesAtivas = true;
    [ObservableProperty] private bool modoSilencioso;
    [ObservableProperty] private bool confirmarSaida = true;
    [ObservableProperty] private string versaoApp = "Versão mockada 1.0.0";

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task AbrirSuporte()
    {
        await Shell.Current.GoToAsync(nameof(Pages.SuportePage));
    }

    [RelayCommand]
    private async Task SobreSistema()
    {
        await Shell.Current.DisplayAlertAsync(
            "Sobre o sistema",
            "Aplicativo de logística de frota e transporte municipal.\n\nAmbiente atual: mockado para demonstração.",
            "OK");
    }
}