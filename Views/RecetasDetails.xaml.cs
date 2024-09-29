using ElBarDePili.Models;
using ElBarDePili.ViewModels.Recetas;

namespace ElBarDePili.Views;

public partial class RecetasDetails : ContentPage
{
	public RecetasDetails(RecetasDetailsViewModel recetasDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = recetasDetailsViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}