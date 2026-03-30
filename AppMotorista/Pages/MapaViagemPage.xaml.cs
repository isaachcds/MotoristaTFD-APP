using AppMotorista.ViewModels;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppMotorista.Pages;

public partial class MapaViagemPage : ContentPage
{
    public MapaViagemPage()
    {
        InitializeComponent();
        BindingContext = new MapaViagemViewModel();

        var origem = new Location(-19.9245, -43.9352);
        var parada = new Location(-19.9280, -43.9400);
        var destino = new Location(-19.9325, -43.9455);

        MapaView.Pins.Clear();
        MapaView.MapElements.Clear();

        MapaView.MoveToRegion(
            MapSpan.FromCenterAndRadius(origem, Distance.FromKilometers(3)));

        MapaView.Pins.Add(new Pin
        {
            Label = "Origem",
            Address = "UBS Central",
            Location = origem
        });

        MapaView.Pins.Add(new Pin
        {
            Label = "Parada",
            Address = "Avenida Brasil",
            Location = parada
        });

        MapaView.Pins.Add(new Pin
        {
            Label = "Destino",
            Address = "Hospital Ana Nery",
            Location = destino
        });

        var rota = new Polyline
        {
            StrokeColor = Colors.Blue,
            StrokeWidth = 6
        };

        rota.Geopath.Add(origem);
        rota.Geopath.Add(parada);
        rota.Geopath.Add(destino);

        MapaView.MapElements.Add(rota);
    }
}