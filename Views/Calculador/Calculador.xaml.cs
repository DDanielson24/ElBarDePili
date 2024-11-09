using ElBarDePili.ViewModels.Calculador;

namespace ElBarDePili.Views.Calculador;

public partial class Calculador : ContentPage
{
	private readonly CalculadorViewModel _calculadorViewModel;
    public Calculador(CalculadorViewModel calculadorViewModel)
	{
		InitializeComponent();
        _calculadorViewModel = calculadorViewModel;
        BindingContext = calculadorViewModel;
    }

    protected override void OnAppearing()
    {
        _calculadorViewModel.GetIngredientesCommand.Execute(null);
    }
}