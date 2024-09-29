using ElBarDePili.ViewModels.Recetas;

namespace ElBarDePili.Views;

public partial class RecetasEditing : ContentPage
{
	public RecetasEditing(RecetasEditingViewModel recetasEditingViewModel)
	{
		InitializeComponent();
		BindingContext = recetasEditingViewModel;
	}
}