using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class ConfigViewModel : ObservableObject
{
    [ObservableProperty]
    private bool menuAberto;

    [ObservableProperty]
    private string tituloPagina = "Perfil do Motorista";

    [ObservableProperty]
    private string nomeMotorista = "João Silva";

    [ObservableProperty]
    private string emailMotorista = "joao.silva@email.com";

    [ObservableProperty]
    private string idMotorista = "ID: 45829-X";

    [ObservableProperty]
    private string categoriaMotorista = "CATEGORIA D";

    [ObservableProperty]
    private string validadeCnh = "15/05/2028";

    [ObservableProperty]
    private string fotoMotorista = "motorista_perfil.png";

    [ObservableProperty]
    private bool notificacoesAtivas = true;

    [ObservableProperty]
    private bool modoSilencioso;

    [ObservableProperty]
    private bool confirmarSaida = true;

    [ObservableProperty]
    private string versaoApp = "Versão mockada 1.0.0";

    public ObservableCollection<SideMenuItem> ItensMenu { get; } = new();

    public ConfigViewModel()
    {
        PopularMenu();
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
            Icone = "menunavbar_alertas_inativo_icon.svg",
            Rota = nameof(AlertasPage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Perfil do Motorista",
            Icone = "menunavbar_perfil_ativo_icon.svg",
            Rota = nameof(ConfigPage),
            Ativo = true
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
    private async Task DadosPessoais()
    {
        await Shell.Current.DisplayAlertAsync(
            "Dados pessoais",
            "Tela de dados pessoais ainda será implementada.",
            "OK");
    }

    [RelayCommand]
    private async Task AlterarSenha()
    {
        await Shell.Current.DisplayAlertAsync(
            "Alterar senha",
            "Tela de alteração de senha ainda será implementada.",
            "OK");
    }

    [RelayCommand]
    private async Task Notificacoes()
    {
        await Shell.Current.DisplayAlertAsync(
            "Notificações",
            "Preferências de notificações ainda serão implementadas.",
            "OK");
    }

    [RelayCommand]
    private async Task Preferencias()
    {
        await Shell.Current.DisplayAlertAsync(
            "Preferências do App",
            "Preferências do aplicativo ainda serão implementadas.",
            "OK");
    }

    [RelayCommand]
    private async Task AbrirSuporte()
    {
        await Shell.Current.GoToAsync(nameof(SuportePage));
    }

    [RelayCommand]
    private async Task SobreSistema()
    {
        await Shell.Current.DisplayAlertAsync(
            "Sobre o sistema",
            "Aplicativo de logística de frota e transporte municipal.\n\nAmbiente atual: mockado para demonstração.",
            "OK");
    }

    [RelayCommand]
    private async Task AbrirItemMenu(SideMenuItem item)
    {
        if (item is null || string.IsNullOrWhiteSpace(item.Rota))
            return;

        MenuAberto = false;

        if (item.Rota == nameof(ConfigPage))
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
    private async Task IrAlertas()
    {
        await Shell.Current.GoToAsync(nameof(AlertasPage));
    }

    [RelayCommand]
    private Task IrPerfil()
    {
        return Task.CompletedTask;
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