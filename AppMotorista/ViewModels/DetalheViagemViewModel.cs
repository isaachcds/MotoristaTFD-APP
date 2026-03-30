using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class DetalheViagemViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Detalhe da Viagem";
    [ObservableProperty] private string codigoViagem = "VGM-2024-018";

    [ObservableProperty] private string status = "Confirmada";
    [ObservableProperty] private string statusCorFundo = "#E8F6EC";
    [ObservableProperty] private string statusCorTexto = "#239B56";

    [ObservableProperty] private string data = "24/04/2024";
    [ObservableProperty] private string horario = "07:40";

    [ObservableProperty] private string origem = "UBS Central";
    [ObservableProperty] private string destino = "Hospital Ana Nery";

    [ObservableProperty] private string veiculo = "Citroën Jumpy - QWE-1234";
    [ObservableProperty] private string modeloVeiculo = "Citroën Jumpy";
    [ObservableProperty] private string placaVeiculo = "QWE-1234";
    [ObservableProperty] private string capacidadeVeiculo = "4 passageiros";
    [ObservableProperty] private string tipoCombustivel = "Diesel";
    [ObservableProperty] private bool veiculoProprio = true;
    [ObservableProperty] private string textoVeiculoProprio = "Veículo próprio";

    [ObservableProperty] private string motorista = "Gabriel Almeida";
    [ObservableProperty] private string cnhMotorista = "CNH: 01234567890";
    [ObservableProperty] private string contatoMotorista = "(31) 99999-0000";

    [ObservableProperty] private string equipeApoio = "Juliana Costa • Técnica de Enfermagem";
    [ObservableProperty] private string observacoes = "Viagem com embarque prioritário. Confirmar presença antes da saída.";

    [ObservableProperty] private string resumoPassageiros = "3 passageiros vinculados";
    [ObservableProperty] private string ocupacaoResumo = "Ocupação prevista: 3 de 4 lugares";
    [ObservableProperty] private string avisoOperacionalTitulo = "Aviso operacional";
    [ObservableProperty] private string avisoOperacionalDescricao = "Veículo próprio em uso. Conferir passageiros antes do início da viagem.";

    public bool ExibirAvisoVeiculoProprio => VeiculoProprio;

    public ObservableCollection<string> PontosDaRota { get; } = new();
    public ObservableCollection<string> Passageiros { get; } = new();

    public DetalheViagemViewModel()
    {
        PontosDaRota.Add("UBS Central");
        PontosDaRota.Add("Ponto de apoio - Avenida Brasil");
        PontosDaRota.Add("Hospital Ana Nery");

        Passageiros.Add("Maria Aparecida");
        Passageiros.Add("José Carlos");
        Passageiros.Add("Ana Luiza");
    }

    partial void OnVeiculoProprioChanged(bool value)
    {
        OnPropertyChanged(nameof(ExibirAvisoVeiculoProprio));
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task IniciarViagem()
    {
        Status = "Em andamento";
        StatusCorFundo = "#E8F1FF";
        StatusCorTexto = "#2357C6";

        await Shell.Current.DisplayAlertAsync(
            "Viagem iniciada",
            "A viagem foi iniciada no fluxo mockado.",
            "OK");
    }

    [RelayCommand]
    private async Task AbrirMapa()
    {
        await Shell.Current.GoToAsync(nameof(MapaViagemPage));
    }

    [RelayCommand]
    private async Task RegistrarOcorrencia()
    {
        await Shell.Current.GoToAsync(nameof(OcorrenciaFormPage));
    }

    [RelayCommand]
    private async Task AbrirEmbarque()
    {
        await Shell.Current.GoToAsync(nameof(EmbarquePage));
    }
}