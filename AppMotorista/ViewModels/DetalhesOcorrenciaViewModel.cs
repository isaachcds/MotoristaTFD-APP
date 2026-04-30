using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class DetalhesOcorrenciaViewModel : ObservableObject
{
    [ObservableProperty]
    private string status = "EM ANÁLISE";

    [ObservableProperty]
    private string statusCorFundo = "#FFF4D8";

    [ObservableProperty]
    private string statusCorTexto = "#B7791F";

    [ObservableProperty]
    private string dataHora = "15 Out, 09:42";

    [ObservableProperty]
    private string tipoOcorrencia = "Pneu furado";

    [ObservableProperty]
    private string prioridade = "Alta";

    [ObservableProperty]
    private string localizacao = "Rodovia BR-101, KM 245 - Próximo ao Posto de Combustível Estrela";

    [ObservableProperty]
    private string descricaoFatos =
        "Durante o trajeto de retorno com os pacientes da hemodiálise, o pneu traseiro direito estourou ao passar por um detrito na pista. O veículo foi parado com segurança no acostamento. Todos os pacientes estão bem e aguardando no interior do veículo.";

    [ObservableProperty]
    private string fotoOcorrencia = "pneu_ocorrencia.png";

    [ObservableProperty]
    private string observacoesMotorista =
        "Já solicitei o suporte da central e aguardo o veículo reserva para transbordo dos pacientes, visando não atrasar o cronograma de retorno.";

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task AdicionarFoto()
    {
        await Shell.Current.DisplayAlertAsync(
            "Adicionar foto",
            "Funcionalidade de adicionar foto ainda será implementada.",
            "OK");
    }
}