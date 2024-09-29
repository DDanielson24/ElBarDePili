using ElBarDePili.ViewModels.Recetas;

namespace ElBarDePili.Views.Recetas;

public partial class RecetasList : ContentPage
{
	public RecetasList(RecetasViewModel recetasViewModel)
	{
		InitializeComponent();
		BindingContext = recetasViewModel;
	}
}