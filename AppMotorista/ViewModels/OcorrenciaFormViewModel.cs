using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class OcorrenciaFormViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Nova Ocorrência";
    [ObservableProperty] private string codigoViagem = "VGM-2024-018";
    [ObservableProperty] private string destino = "Hospital Ana Nery";
    [ObservableProperty] private string tipoOcorrencia = "Atraso";
    [ObservableProperty] private string prioridade = "Alta";
    [ObservableProperty] private string localOcorrencia = "Trecho próximo à Avenida Brasil";
    [ObservableProperty] private string descricao = "Trânsito intenso com impacto no tempo estimado.";
    [ObservableProperty] private string observacoes = "Motorista comunicou via central.";

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task Salvar()
    {
        await Shell.Current.DisplayAlertAsync(
            "Ocorrência registrada",
            "A ocorrência foi registrada no fluxo mockado.",
            "OK");

        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task Cancelar()
    {
        await Shell.Current.Navigation.PopAsync();
    }
}