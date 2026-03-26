using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace AppMotorista.ViewModels;

public partial class MapaViagemViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Mapa da Viagem";
    [ObservableProperty] private string resumoMapa = "Rota prevista com origem, parada e destino";
    [ObservableProperty] private string origem = "UBS Central";
    [ObservableProperty] private string destino = "Hospital Ana Nery";
    [ObservableProperty] private string proximoPonto = "Avenida Brasil";
    [ObservableProperty] private string statusRota = "Em deslocamento";

    [RelayCommand]
    private async Task Voltar()
    {
        try
        {
            await Shell.Current.Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync(
                "Erro ao voltar",
                ex.Message,
                "OK");
        }
    }

    [RelayCommand]
    private async Task AbrirMapaExterno()
    {
        var destinoLocation = new Location(-19.9325, -43.9455);

        var options = new MapLaunchOptions
        {
            Name = Destino,
            NavigationMode = NavigationMode.Driving
        };

        var abriu = await Map.Default.TryOpenAsync(destinoLocation, options);

        if (!abriu)
        {
            await Shell.Current.DisplayAlertAsync(
                "Mapa",
                "Não foi possível abrir o aplicativo de mapas.",
                "OK");
        }
    }
}