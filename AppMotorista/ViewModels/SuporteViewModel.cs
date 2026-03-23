using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class SuporteViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Suporte";

    [ObservableProperty]
    private string rodapeTitulo = "Atendimento mockado";

    [ObservableProperty]
    private string rodapeDescricao = "Os canais abaixo são demonstrativos para a apresentação do sistema.";

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task AbrirWhatsapp()
    {
        await Shell.Current.DisplayAlertAsync(
            "WhatsApp do suporte",
            "Canal mockado: (31) 99999-0000",
            "OK");
    }

    [RelayCommand]
    private async Task LigarSuporte()
    {
        await Shell.Current.DisplayAlertAsync(
            "Telefone do suporte",
            "Canal mockado: (31) 3333-0000",
            "OK");
    }

    [RelayCommand]
    private async Task EnviarEmail()
    {
        await Shell.Current.DisplayAlertAsync(
            "E-mail do suporte",
            "Canal mockado: suporte@appmotorista.com",
            "OK");
    }
}