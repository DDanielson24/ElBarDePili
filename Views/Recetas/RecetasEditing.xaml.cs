using ElBarDePili.ViewModels.Recetas;

namespace ElBarDePili.Views.Recetas;

public partial class RecetasEditing : ContentPage
{
	public RecetasEditing(RecetasEditingViewModel recetasEditingViewModel)
	{
		InitializeComponent();
		BindingContext = recetasEditingViewModel;
	}
}