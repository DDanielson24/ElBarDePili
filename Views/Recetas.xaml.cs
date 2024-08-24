using ElBarDePili.ViewModels;

namespace ElBarDePili.Views;

public partial class Recetas : ContentPage
{
	public Recetas(RecetasViewModel recetasViewModel)
	{
		InitializeComponent();
		BindingContext = recetasViewModel;
	}
}