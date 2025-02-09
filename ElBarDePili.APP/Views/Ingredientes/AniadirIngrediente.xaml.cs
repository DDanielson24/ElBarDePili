using ElBarDePili.ViewModels.Ingredientes;

namespace ElBarDePili.Views.Ingredientes;

public partial class AniadirIngrediente : ContentPage
{
    private readonly AniadirIngredienteViewModel _aniadirIngredienteViewModel;
    public AniadirIngrediente(AniadirIngredienteViewModel aniadirIngredienteViewModel)
	{
		InitializeComponent();
        _aniadirIngredienteViewModel = aniadirIngredienteViewModel;
		BindingContext = _aniadirIngredienteViewModel;
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        dataForm.Commit();
        _aniadirIngredienteViewModel.SaveIngredienteCommand.Execute(null);
    }
}