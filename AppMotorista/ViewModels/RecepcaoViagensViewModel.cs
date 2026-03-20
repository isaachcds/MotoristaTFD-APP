using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class RecepcaoViagensViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Recepção de Viagens";

    public ObservableCollection<ReceptionTripItem> Viagens { get; } = new();

    public RecepcaoViagensViewModel()
    {
        Viagens.Add(new ReceptionTripItem
        {
            Data = "24/04/2024",
            Horario = "07:40",
            Destino = "Hospital Ana Nery",
            Veiculo = "Citroën Jumpy",
            Motorista = "Gabriel Almeida",
            Status = "Confirmada",
            TravaFaturamentoAtiva = true
        });

        Viagens.Add(new ReceptionTripItem
        {
            Data = "24/04/2024",
            Horario = "08:20",
            Destino = "Policlínica Regional Oeste",
            Veiculo = "Renault Master",
            Motorista = "João Carlos",
            Status = "Pendente",
            TravaFaturamentoAtiva = false
        });

        Viagens.Add(new ReceptionTripItem
        {
            Data = "24/04/2024",
            Horario = "09:10",
            Destino = "Unidade Básica São José",
            Veiculo = "Ford Transit",
            Motorista = "Marcos Silva",
            Status = "Recebida",
            TravaFaturamentoAtiva = true
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task AbrirDetalhe(ReceptionTripItem item)
    {
        if (item == null) return;

        await Shell.Current.DisplayAlert(
            "Viagem",
            $"Destino: {item.Destino}\nMotorista: {item.Motorista}\nStatus: {item.Status}",
            "OK");
    }
}