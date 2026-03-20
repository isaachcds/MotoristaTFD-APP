using AppMotorista.Pages;

namespace AppMotorista
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(RecepcaoViagensPage), typeof(RecepcaoViagensPage));
            Routing.RegisterRoute(nameof(PlanejamentoRotasPage), typeof(PlanejamentoRotasPage));
            Routing.RegisterRoute(nameof(CadastroVeiculosPage), typeof(CadastroVeiculosPage));
            Routing.RegisterRoute(nameof(LocaisPage), typeof(LocaisPage));
            Routing.RegisterRoute(nameof(AgrupamentoPacientesPage), typeof(AgrupamentoPacientesPage));
            Routing.RegisterRoute(nameof(EquipeApoioPage), typeof(EquipeApoioPage));
        }
    }
}