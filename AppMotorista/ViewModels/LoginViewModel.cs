using AppMotorista.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string identificacao = string.Empty;

    [ObservableProperty]
    private string senha = string.Empty;

    [ObservableProperty]
    private bool senhaOculta = true;

    public string IconeSenha => SenhaOculta
        ? "eye_off_icon.svg"
        : "eye_show_icon.svg";

    partial void OnSenhaOcultaChanged(bool value)
    {
        OnPropertyChanged(nameof(IconeSenha));
    }

    [RelayCommand]
    private void AlternarSenha()
    {
        SenhaOculta = !SenhaOculta;
    }

    [RelayCommand]
    private async Task Entrar()
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }
}