using ElBarDePili.ViewModels;
using ElBarDePili.ViewModels.Ingredientes;

namespace ElBarDePili.Views.Ingredientes;

public partial class IngredientesList : ContentPage
{
    public IngredientesList(IngredientesViewModel ingredientesViewModel)
    {
        InitializeComponent();
        BindingContext = ingredientesViewModel;
    }
}