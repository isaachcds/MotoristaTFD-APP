using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private bool menuAberto;
    [ObservableProperty] private string nomeMotorista = "Gabriel Almeida";
    [ObservableProperty] private string emailMotorista = "gabriel.almeida@email.com";
    [ObservableProperty] private string resumoDia = "3 viagens programadas • 1 alerta pendente";
    [ObservableProperty] private TripSummaryItem? proximaViagem;

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
            Icone = "clipboard_check_icon.svg",
            Rota = nameof(RecepcaoViagensPage)
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Planejamento de Rotas",
            Descricao = "Organize rotas por data, horário e veículo.",
            Icone = "trip_icon.svg",
            Rota = nameof(PlanejamentoRotasPage)
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Veículos e Motoristas",
            Descricao = "Controle a frota e os motoristas vinculados.",
            Icone = "fleet_icon.svg",
            Rota = nameof(CadastroVeiculosPage)
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Locais de Embarque e Destino",
            Descricao = "Cadastre pontos de embarque e unidades de destino.",
            Icone = "location_icon.svg",
            Rota = nameof(LocaisPage)
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Agrupamento de Pacientes",
            Descricao = "Agrupe pacientes por destino e horário.",
            Icone = "tasklist_icon.svg",
            Rota = nameof(AgrupamentoPacientesPage)
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Equipe de Apoio",
            Descricao = "Associe profissionais de apoio às viagens.",
            Icone = "medical_staff_icon.svg",
            Rota = nameof(EquipeApoioPage)
        });

        Atalhos.Add(new QuickAccessItem
        {
            Titulo = "Alertas e Ocorrências",
            Descricao = "Veja alertas e registre ocorrências da rota.",
            Icone = "bell_pin_icon.svg",
            Rota = "AlertasPage"
        });

        ItensMenu.Add(new SideMenuItem { Titulo = "Início", Icone = "menuhamburguer_icon.svg", Rota = nameof(HomePage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Recepção de Viagens", Icone = "clipboard_check_icon.svg", Rota = nameof(RecepcaoViagensPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Planejamento de Rotas", Icone = "trip_icon.svg", Rota = nameof(PlanejamentoRotasPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Veículos e Motoristas", Icone = "fleet_icon.svg", Rota = nameof(CadastroVeiculosPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Locais de Embarque e Destino", Icone = "location_icon.svg", Rota = nameof(LocaisPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Agrupamento de Pacientes", Icone = "tasklist_icon.svg", Rota = nameof(AgrupamentoPacientesPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Equipe de Apoio", Icone = "medical_staff_icon.svg", Rota = nameof(EquipeApoioPage) });
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
        if (item is null) return;

        if (item.Rota == nameof(RecepcaoViagensPage))
            await Shell.Current.GoToAsync(nameof(RecepcaoViagensPage));
        else if (item.Rota == nameof(PlanejamentoRotasPage))
            await Shell.Current.GoToAsync(nameof(PlanejamentoRotasPage));
        else if (item.Rota == nameof(CadastroVeiculosPage))
            await Shell.Current.GoToAsync(nameof(CadastroVeiculosPage));
        else if (item.Rota == nameof(LocaisPage))
            await Shell.Current.GoToAsync(nameof(LocaisPage));
        else if (item.Rota == nameof(AgrupamentoPacientesPage))
            await Shell.Current.GoToAsync(nameof(AgrupamentoPacientesPage));
        else if (item.Rota == nameof(EquipeApoioPage))
            await Shell.Current.GoToAsync(nameof(EquipeApoioPage));
        else
            await Shell.Current.DisplayAlertAsync("Atalho", $"Abrir: {item.Titulo}", "OK");
    }

    [RelayCommand]
    private async Task AbrirItemMenu(SideMenuItem item)
    {
        if (item is null) return;

        MenuAberto = false;

        if (item.Rota == nameof(HomePage))
            return;

        if (item.Rota == nameof(RecepcaoViagensPage))
            await Shell.Current.GoToAsync(nameof(RecepcaoViagensPage));
        else if (item.Rota == nameof(PlanejamentoRotasPage))
            await Shell.Current.GoToAsync(nameof(PlanejamentoRotasPage));
        else if (item.Rota == nameof(CadastroVeiculosPage))
            await Shell.Current.GoToAsync(nameof(CadastroVeiculosPage));
        else if (item.Rota == nameof(LocaisPage))
            await Shell.Current.GoToAsync(nameof(LocaisPage));
        else if (item.Rota == nameof(AgrupamentoPacientesPage))
            await Shell.Current.GoToAsync(nameof(AgrupamentoPacientesPage));
        else if (item.Rota == nameof(EquipeApoioPage))
            await Shell.Current.GoToAsync(nameof(EquipeApoioPage));
        else
            await Shell.Current.DisplayAlertAsync("Menu", $"Abrir: {item.Titulo}", "OK");
    }

    [RelayCommand]
    private async Task AbrirQrCode()
    {
        await Shell.Current.DisplayAlertAsync("QR Code", "Abrir leitor de QR Code", "OK");
    }

    [RelayCommand]
    private async Task IrInicio()
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }

    [RelayCommand]
    private async Task IrViagens()
    {
        await Shell.Current.GoToAsync(nameof(RecepcaoViagensPage));
    }

    [RelayCommand]
    private async Task IrAlertas()
    {
        await Shell.Current.DisplayAlertAsync("Alertas", "Abrir alertas", "OK");
    }

    [RelayCommand]
    private async Task IrConfig()
    {
        await Shell.Current.DisplayAlertAsync("Configurações", "Abrir configurações", "OK");
    }
}