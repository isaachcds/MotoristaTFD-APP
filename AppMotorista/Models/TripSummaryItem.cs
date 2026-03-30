namespace AppMotorista.Models;

public class TripSummaryItem
{
    public string Titulo { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public string Horario { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public string Veiculo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

    public string ResumoPassageiros { get; set; } = string.Empty;
    public string EquipeApoio { get; set; } = string.Empty;
    public string ResumoRota { get; set; } = string.Empty;
    public bool VeiculoProprio { get; set; }
}