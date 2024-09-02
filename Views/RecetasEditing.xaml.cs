using ElBarDePili.ViewModels;

namespace ElBarDePili.Views;

public partial class RecetasEditing : ContentPage
{
	public RecetasEditing(RecetasEditingViewModel recetasEditingViewModel)
	{
		InitializeComponent();
		BindingContext = recetasEditingViewModel;
	}
}