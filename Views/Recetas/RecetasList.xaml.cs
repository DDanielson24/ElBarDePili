using ElBarDePili.ViewModels.Recetas;

namespace ElBarDePili.Views.Recetas;

public partial class RecetasList : ContentPage
{
	private readonly RecetasViewModel _recetasViewModel;
	public RecetasList(RecetasViewModel recetasViewModel)
	{
		InitializeComponent();
		_recetasViewModel = recetasViewModel;
		BindingContext = recetasViewModel;
	}

    protected override void OnAppearing()
    {
        _recetasViewModel.GetRecetasCommand.Execute(null);
    }
}