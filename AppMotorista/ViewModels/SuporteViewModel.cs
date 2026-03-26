using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class SuporteViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Suporte";
    [ObservableProperty] private string resumo = "Canais rápidos para apoio ao motorista";
    [ObservableProperty] private string telefone = "(31) 3333-0000";
    [ObservableProperty] private string whatsapp = "(31) 99999-0000";
    [ObservableProperty] private string email = "suporte@appmotorista.com";

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task AbrirWhatsapp()
    {
        await Shell.Current.DisplayAlertAsync(
            "WhatsApp",
            $"Canal mockado: {Whatsapp}",
            "OK");
    }

    [RelayCommand]
    private async Task Ligar()
    {
        await Shell.Current.DisplayAlertAsync(
            "Telefone",
            $"Canal mockado: {Telefone}",
            "OK");
    }

    [RelayCommand]
    private async Task EnviarEmail()
    {
        await Shell.Current.DisplayAlertAsync(
            "E-mail",
            $"Canal mockado: {Email}",
            "OK");
    }
}