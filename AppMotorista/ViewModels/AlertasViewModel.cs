using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class AlertasViewModel : ObservableObject
{
    [ObservableProperty]
    private bool menuAberto;

    [ObservableProperty]
    private string tituloPagina = "Alertas e Ocorrências";

    [ObservableProperty]
    private string resumo = "2 alertas ativos • 2 ocorrências registradas";

    [ObservableProperty]
    private string nomeMotorista = "João Silva";

    [ObservableProperty]
    private string idMotorista = "ID 482910";

    [ObservableProperty]
    private string emailMotorista = "joao.silva@email.com";

    public ObservableCollection<AlertaItem> AlertasAtivos { get; } = new();

    public ObservableCollection<AlertaItem> OcorrenciasRecentes { get; } = new();

    public ObservableCollection<SideMenuItem> ItensMenu { get; } = new();

    public AlertasViewModel()
    {
        PopularAlertas();
        PopularMenu();
    }

    private void PopularAlertas()
    {
        AlertasAtivos.Clear();
        OcorrenciasRecentes.Clear();

        AlertasAtivos.Add(new AlertaItem
        {
            Titulo = "",
            Descricao = "Interdição na via principal para o Hospital das Clínicas. Use a rota alternativa via Av. Industrial.",
            DataHora = "Hoje, 08:20",
            Severidade = "URGENTE",
            CorFundo = "#FDECEC",
            CorTexto = "#D32F2F",
            Origem = "Mapa da viagem",
            IconeTexto = "⚠"
        });

        AlertasAtivos.Add(new AlertaItem
        {
            Titulo = "",
            Descricao = "Atenção: Chuva forte na região sul, redobre o cuidado.",
            DataHora = "Hoje, 08:45",
            Severidade = "URGENTE",
            CorFundo = "#FDECEC",
            CorTexto = "#D32F2F",
            Origem = "Operação",
            IconeTexto = "⚠"
        });

        OcorrenciasRecentes.Add(new AlertaItem
        {
            Titulo = "Pneu furado",
            Descricao = "Ocorrência resolvida pela equipe de apoio.",
            DataHora = "Hoje, 09:15",
            Severidade = "RESOLVIDO",
            CorFundo = "#E8F6EC",
            CorTexto = "#20A96B",
            Origem = "Veículo",
            IconeTexto = "🛠"
        });

        OcorrenciasRecentes.Add(new AlertaItem
        {
            Titulo = "Atraso na saída",
            Descricao = "Ocorrência em análise pela central.",
            DataHora = "Ontem, 14:30",
            Severidade = "EM ANÁLISE",
            CorFundo = "#FFF4D8",
            CorTexto = "#B7791F",
            Origem = "Viagem",
            IconeTexto = "◷"
        });
    }
    private void PopularMenu()
    {
        ItensMenu.Clear();

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Início",
            Icone = "home_icon.svg",
            Rota = nameof(HomePage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Minhas Viagens",
            Icone = "clipboard_check_icon.svg",
            Rota = nameof(MinhasViagensPage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Alertas e Ocorrências",
            Icone = "menunavbar_alertas_ativo_icon.svg",
            Rota = nameof(AlertasPage),
            Ativo = true
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Planejamento de Rotas",
            Icone = "trip_icon.svg",
            Rota = nameof(PlanejamentoRotasPage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Localizações",
            Icone = "location_icon.svg",
            Rota = nameof(LocaisPage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Suporte",
            Icone = "support_icon.svg",
            Rota = nameof(SuportePage)
        });
    }

    [RelayCommand]
    private void AlternarMenu()
    {
        MenuAberto = !MenuAberto;
    }

    [RelayCommand]
    private void FecharMenu()
    {
        MenuAberto = false;
    }

    [RelayCommand]
    private async Task NovaOcorrencia()
    {
        await Shell.Current.GoToAsync(nameof(OcorrenciaFormPage));
    }

    [RelayCommand]
    private async Task AbrirItem(AlertaItem item)
    {
        if (item is null)
            return;

        await Shell.Current.GoToAsync(nameof(DetalhesOcorrenciaPage));
    }

    [RelayCommand]
    private async Task AbrirItemMenu(SideMenuItem item)
    {
        if (item is null || string.IsNullOrWhiteSpace(item.Rota))
            return;

        MenuAberto = false;

        if (item.Rota == nameof(AlertasPage))
            return;

        await NavegarOuMostrarPlaceholder(item.Rota, item.Titulo);
    }

    [RelayCommand]
    private async Task IrInicio()
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }

    [RelayCommand]
    private async Task IrViagens()
    {
        await Shell.Current.GoToAsync(nameof(MinhasViagensPage));
    }

    [RelayCommand]
    private Task IrAlertas()
    {
        return Task.CompletedTask;
    }

    [RelayCommand]
    private async Task IrSuporte()
    {
        await NavegarOuMostrarPlaceholder(nameof(SuportePage), "Suporte");
    }

    [RelayCommand]
    private async Task Sair()
    {
        MenuAberto = false;

        await Shell.Current.GoToAsync("//LoginPage");
    }

    private static readonly HashSet<string> RotasImplementadas = new()
    {
        nameof(HomePage),
        nameof(MinhasViagensPage),
        nameof(DetalheViagemPage),
        nameof(PlanejamentoRotasPage),
        nameof(MapaViagemPage),
        nameof(LocaisPage),
        nameof(EmbarquePage),
        nameof(AlertasPage),
        nameof(OcorrenciaFormPage),
        nameof(ConfigPage),
        nameof(SuportePage),
        nameof(CadastroVeiculosPage),
        nameof(QrCodeScannerPage)
    };

    private static async Task NavegarOuMostrarPlaceholder(string rota, string titulo)
    {
        if (RotasImplementadas.Contains(rota))
        {
            await Shell.Current.GoToAsync(rota);
            return;
        }

        await Shell.Current.DisplayAlertAsync(
            titulo,
            "Essa tela será criada na próxima etapa.",
            "OK");
    }
}