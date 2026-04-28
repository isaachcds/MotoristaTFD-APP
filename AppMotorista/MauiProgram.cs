using AppMotorista.Pages;
using AppMotorista.ViewModels;
using CommunityToolkit.Maui;
using DevExpress.Maui;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace AppMotorista
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiMaps()
                .UseDevExpress()
                .UseDevExpressControls()
                .UseDevExpressCollectionView()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // ViewModels
            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<MinhasViagensViewModel>();
            builder.Services.AddTransient<PlanejamentoRotasViewModel>();
            builder.Services.AddTransient<CadastroVeiculosViewModel>();
            builder.Services.AddTransient<LocaisViewModel>();
            builder.Services.AddTransient<AgrupamentoPacientesViewModel>();
            builder.Services.AddTransient<EquipeApoioViewModel>();
            builder.Services.AddTransient<AlertasViewModel>();
            builder.Services.AddTransient<ConfigViewModel>();
            builder.Services.AddTransient<SuporteViewModel>();
            builder.Services.AddTransient<OcorrenciaFormViewModel>();
            builder.Services.AddTransient<DetalheViagemViewModel>();
            builder.Services.AddTransient<MapaViagemViewModel>();
            builder.Services.AddTransient<EmbarqueViewModel>();
            builder.Services.AddTransient<QrCodeScannerViewModel>();

            // Pages
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<MinhasViagensPage>();
            builder.Services.AddTransient<PlanejamentoRotasPage>();
            builder.Services.AddTransient<CadastroVeiculosPage>();
            builder.Services.AddTransient<LocaisPage>();
            builder.Services.AddTransient<AgrupamentoPacientesPage>();
            builder.Services.AddTransient<EquipeApoioPage>();
            builder.Services.AddTransient<AlertasPage>();
            builder.Services.AddTransient<ConfigPage>();
            builder.Services.AddTransient<SuportePage>();
            builder.Services.AddTransient<OcorrenciaFormPage>();
            builder.Services.AddTransient<DetalheViagemPage>();
            builder.Services.AddTransient<MapaViagemPage>();
            builder.Services.AddTransient<EmbarquePage>();
            builder.Services.AddTransient<QrCodeScannerPage>();
            return builder.Build();
        }
    }
}