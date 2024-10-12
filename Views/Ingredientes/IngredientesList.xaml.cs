using ElBarDePili.ViewModels;
using ElBarDePili.ViewModels.Ingredientes;

namespace ElBarDePili.Views.Ingredientes;

public partial class IngredientesList : ContentPage
{
    private readonly IngredientesViewModel _ingredientesViewModel;
    public IngredientesList(IngredientesViewModel ingredientesViewModel)
    {
        InitializeComponent();
        _ingredientesViewModel = ingredientesViewModel;
        BindingContext = ingredientesViewModel;
    }

    protected override void OnAppearing()
    {
        _ingredientesViewModel.GetIngredientesCommand.Execute(null);
    }
}