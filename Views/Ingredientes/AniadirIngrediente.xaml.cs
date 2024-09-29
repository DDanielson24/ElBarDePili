using ElBarDePili.ViewModels.Ingredientes;

namespace ElBarDePili.Views.Ingredientes;

public partial class AniadirIngrediente : ContentPage
{
	public AniadirIngrediente(AniadirIngredienteViewModel aniadirIngredienteViewModel)
	{
		InitializeComponent();
		BindingContext = aniadirIngredienteViewModel;
    }
}