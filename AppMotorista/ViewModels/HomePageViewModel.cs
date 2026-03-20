using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty]
    private bool menuAberto;

    [ObservableProperty]
    private string nomeMotorista = "Gabriel Almeida";

    [ObservableProperty]
    private string emailMotorista = "gabriel.almeida@email.com";

    [ObservableProperty]
    private string resumoDia = "3 viagens programadas • 1 alerta pendente";

    [ObservableProperty]
    private TripSummaryItem? proximaViagem;

    public ObservableCollection<QuickAccessItem> Atalhos { get; } = new();
    public ObservableCollection<SideMenuItem> ItensMenu { get; } = new();

    public HomePageViewModel()
    {
        ProximaViagem = new TripSummaryItem
        {
            Titulo = "Próxima Viagem",
            Data = "24/04/2024",
            Horario = "07:40",
            Destino = "Hospital Ana Nery",
            Veiculo = "Citroën Jumpy - Placa QWE-1234",
            Status = "Confirmada"
        };

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Recepção de Viagens",
            Descricao = "Gerencie viagens programadas e confirmadas.",
            Icone = "bell_pin_icon.svg",
            Rota = "RecepcaoViagensPage"
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Planejamento de Rotas",
            Descricao = "Organize rotas por data, horário e veículo.",
            Icone = "qrcode_icon.svg",
            Rota = "PlanejamentoRotasPage"
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Veículos e Motoristas",
            Descricao = "Controle a frota e os motoristas vinculados.",
            Icone = "menuhamburguer_icon.svg",
            Rota = "CadastroVeiculosPage"
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Locais de Embarque e Destino",
            Descricao = "Cadastre pontos de embarque e unidades de destino.",
            Icone = "support_icon.svg",
            Rota = "LocaisPage"
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Agrupamento de Pacientes",
            Descricao = "Agrupe pacientes por destino e horário.",
            Icone = "bell_icon.svg",
            Rota = "AgrupamentoPage"
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Equipe de Apoio",
            Descricao = "Associe profissionais de apoio às viagens.",
            Icone = "config_icon.svg",
            Rota = "EquipeApoioPage"
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Alertas e Ocorrências",
            Descricao = "Veja alertas e registre ocorrências da rota.",
            Icone = "bell_pin_icon.svg",
            Rota = "AlertasPage"
        });

        ItensMenu.Add(new SideMenuItem { Titulo = "Início", Icone = "menuhamburguer_icon.svg", Rota = "HomePage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Recepção de Viagens", Icone = "bell_pin_icon.svg", Rota = "RecepcaoViagensPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Planejamento de Rotas", Icone = "qrcode_icon.svg", Rota = "PlanejamentoRotasPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Veículos e Motoristas", Icone = "menuhamburguer_icon.svg", Rota = "CadastroVeiculosPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Locais de Embarque e Destino", Icone = "support_icon.svg", Rota = "LocaisPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Agrupamento de Pacientes", Icone = "bell_icon.svg", Rota = "AgrupamentoPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Equipe de Apoio", Icone = "config_icon.svg", Rota = "EquipeApoioPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Configurações", Icone = "config_icon.svg", Rota = "ConfigPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Suporte", Icone = "support_icon.svg", Rota = "SuportePage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Sair", Icone = "power_icon.svg", Rota = "Sair" });
    }

    [RelayCommand]
    private void AlternarMenu() => MenuAberto = !MenuAberto;

    [RelayCommand]
    private void FecharMenu() => MenuAberto = false;

    [RelayCommand]
    private async Task AbrirAtalho(QuickAccessItem item)
    {
        if (item == null) return;

        if (item.Rota == "RecepcaoViagensPage")
        {
            await Shell.Current.GoToAsync(nameof(Pages.RecepcaoViagensPage));
            return;
        }

        await Shell.Current.DisplayAlert("Atalho", $"Abrir: {item.Titulo}", "OK");
    }

    [RelayCommand]
    private async Task AbrirItemMenu(SideMenuItem item)
    {
        if (item == null) return;

        MenuAberto = false;
        await Shell.Current.DisplayAlert("Menu", $"Abrir: {item.Titulo}", "OK");
    }

    [RelayCommand]
    private async Task AbrirQrCode()
    {
        await Shell.Current.DisplayAlert("QR Code", "Abrir leitor de QR Code", "OK");
    }

    [RelayCommand]
    private async Task IrInicio()
    {
        await Shell.Current.DisplayAlert("Bottom Bar", "Início", "OK");
    }

    [RelayCommand]
    private async Task IrViagens()
    {
        await Shell.Current.GoToAsync(nameof(Pages.RecepcaoViagensPage));
    }

    [RelayCommand]
    private async Task IrAlertas()
    {
        await Shell.Current.DisplayAlert("Bottom Bar", "Alertas", "OK");
    }

    [RelayCommand]
    private async Task IrConfig()
    {
        await Shell.Current.DisplayAlert("Bottom Bar", "Configurações", "OK");
    }
}