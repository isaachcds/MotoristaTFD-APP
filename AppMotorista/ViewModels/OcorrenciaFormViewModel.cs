using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class OcorrenciaFormViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Nova Ocorrência";
    [ObservableProperty] private string codigoViagem = "VGM-2024-018";
    [ObservableProperty] private string destino = "Hospital Ana Nery";
    [ObservableProperty] private string horarioViagem = "07:40";
    [ObservableProperty] private string dataRegistro = "24/04/2024 • 07:32";

    [ObservableProperty] private string tipoOcorrencia = "Atraso";
    [ObservableProperty] private string prioridade = "Alta";
    [ObservableProperty] private string localOcorrencia = "Trecho próximo à Avenida Brasil";
    [ObservableProperty] private string descricao = "Trânsito intenso com impacto no tempo estimado.";
    [ObservableProperty] private string observacoes = "Motorista comunicou via central.";

    public ObservableCollection<string> TiposOcorrencia { get; } = new();
    public ObservableCollection<string> Prioridades { get; } = new();

    public OcorrenciaFormViewModel()
    {
        TiposOcorrencia.Add("Atraso");
        TiposOcorrencia.Add("Ausência de passageiro");
        TiposOcorrencia.Add("Problema no veículo");
        TiposOcorrencia.Add("Mudança de rota");
        TiposOcorrencia.Add("Ocorrência clínica");
        TiposOcorrencia.Add("Outro");

        Prioridades.Add("Baixa");
        Prioridades.Add("Média");
        Prioridades.Add("Alta");
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task Salvar()
    {
        if (string.IsNullOrWhiteSpace(TipoOcorrencia) ||
            string.IsNullOrWhiteSpace(Prioridade) ||
            string.IsNullOrWhiteSpace(LocalOcorrencia) ||
            string.IsNullOrWhiteSpace(Descricao))
        {
            await Shell.Current.DisplayAlertAsync(
                "Campos obrigatórios",
                "Preencha tipo, prioridade, local e descrição da ocorrência.",
                "OK");
            return;
        }

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