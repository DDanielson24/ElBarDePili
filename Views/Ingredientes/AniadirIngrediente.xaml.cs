using ElBarDePili.ViewModels.Ingredientes;
using DevExpress.Maui.Editors;
using ElBarDePili.Models;

namespace ElBarDePili.Views.Ingredientes;

public partial class AniadirIngrediente : ContentPage
{
	public AniadirIngrediente(AniadirIngredienteViewModel aniadirIngredienteViewModel)
	{
		InitializeComponent();
		BindingContext = aniadirIngredienteViewModel;
    }
}