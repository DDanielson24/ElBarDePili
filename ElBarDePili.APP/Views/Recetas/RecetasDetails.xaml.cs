using ElBarDePili.Models;
using ElBarDePili.ViewModels.Recetas;

namespace ElBarDePili.Views.Recetas;

public partial class RecetasDetails : ContentPage
{
	private readonly RecetasDetailsViewModel _recetasDetailsViewModel;
	public RecetasDetails(RecetasDetailsViewModel recetasDetailsViewModel)
	{
		InitializeComponent();
        _recetasDetailsViewModel = recetasDetailsViewModel;
        BindingContext = _recetasDetailsViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		bool confirmacion = await DisplayAlert("Eliminar receta", "�Est�s seguro de que quieres eliminar esta receta?", "S�", "No");

		if (confirmacion)
		{
			_recetasDetailsViewModel.DeleteRecetaCommand.Execute(null);
        }
    }
}