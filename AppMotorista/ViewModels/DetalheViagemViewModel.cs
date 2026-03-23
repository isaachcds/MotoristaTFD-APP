using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class DetalheViagemViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Detalhe da Viagem";

    [ObservableProperty]
    private string codigoViagem = "VGM-2024-018";

    [ObservableProperty]
    private string status = "Confirmada";

    [ObservableProperty]
    private string statusCorFundo = "#E8F5E9";

    [ObservableProperty]
    private string statusCorTexto = "#2E7D32";

    [ObservableProperty]
    private string data = "24/04/2024";

    [ObservableProperty]
    private string horario = "07:40";

    [ObservableProperty]
    private string origem = "UBS Central";

    [ObservableProperty]
    private string destino = "Hospital Ana Nery";

    [ObservableProperty]
    private string veiculo = "Citroën Jumpy - QWE-1234";

    [ObservableProperty]
    private string motorista = "Gabriel Almeida";

    [ObservableProperty]
    private string apoio = "Enfermagem - Juliana Costa";

    [ObservableProperty]
    private string pacientes = "3 pacientes vinculados";

    [ObservableProperty]
    private string observacoes = "Viagem programada com embarque prioritário. Necessário confirmar presença antes da saída.";

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task EditarViagem()
    {
        await Shell.Current.DisplayAlertAsync(
            "Editar viagem",
            "Tela de edição mockada será conectada na próxima etapa.",
            "OK");
    }

    [RelayCommand]
    private async Task RegistrarOcorrencia()
    {
        await Shell.Current.GoToAsync(nameof(Pages.OcorrenciaFormPage));
    }

    [RelayCommand]
    private async Task ConfirmarSaida()
    {
        await Shell.Current.DisplayAlertAsync(
            "Saída confirmada",
            "A viagem foi marcada como iniciada no fluxo mockado.",
            "OK");
    }
}