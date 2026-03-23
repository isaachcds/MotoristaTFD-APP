using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class AlertasViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Alertas e Ocorrências";

    [ObservableProperty]
    private string resumo = "4 alertas ativos • 2 ocorrências pendentes";

    public ObservableCollection<AlertaItem> Alertas { get; } = new();

    public AlertasViewModel()
    {
        Alertas.Add(new AlertaItem
        {
            Titulo = "Viagem atrasada",
            Descricao = "A saída para Hospital Ana Nery está com 18 minutos de atraso.",
            DataHora = "24/04/2024 • 07:58",
            Severidade = "Alta",
            CorFundo = "#FDECEC",
            CorTexto = "#C62828",
            Origem = "Recepção de Viagens"
        });

        Alertas.Add(new AlertaItem
        {
            Titulo = "Trava de faturamento ativa",
            Descricao = "Veículo próprio vinculado à viagem 08:20 precisa de validação.",
            DataHora = "24/04/2024 • 08:05",
            Severidade = "Média",
            CorFundo = "#FFF4E5",
            CorTexto = "#B96A00",
            Origem = "Cadastro de Veículos"
        });

        Alertas.Add(new AlertaItem
        {
            Titulo = "Local com endereço incompleto",
            Descricao = "O ponto de embarque UBS Central precisa de complemento.",
            DataHora = "23/04/2024 • 17:30",
            Severidade = "Baixa",
            CorFundo = "#EAF2FF",
            CorTexto = "#2357C6",
            Origem = "Locais"
        });

        Alertas.Add(new AlertaItem
        {
            Titulo = "Ocorrência registrada na rota",
            Descricao = "Motorista informou interdição parcial no trajeto da Policlínica Oeste.",
            DataHora = "24/04/2024 • 08:12",
            Severidade = "Alta",
            CorFundo = "#FDECEC",
            CorTexto = "#C62828",
            Origem = "Planejamento de Rotas"
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task AbrirAlerta(AlertaItem item)
    {
        if (item is null) return;

        await Shell.Current.DisplayAlert(
            item.Titulo,
            $"{item.Descricao}\n\nOrigem: {item.Origem}\nNível: {item.Severidade}\nData: {item.DataHora}",
            "OK");
    }

    [RelayCommand]
    private async Task NovaOcorrencia()
    {
        await Shell.Current.GoToAsync(nameof(Pages.OcorrenciaFormPage));
    }
}