using CommunityToolkit.Mvvm.Input;
using ElBarDePili.ViewModels.Recetas;

namespace ElBarDePili.Views.Recetas;

public partial class RecetasEditing : ContentPage
{
	private readonly RecetasEditingViewModel _recetasEditingViewModel;

    public RecetasEditing(RecetasEditingViewModel recetasEditingViewModel)
	{
		InitializeComponent();
		_recetasEditingViewModel = recetasEditingViewModel;
		BindingContext = _recetasEditingViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		dataForm.Commit();
		_recetasEditingViewModel.SaveEditingCommand.Execute(null);
    }
}