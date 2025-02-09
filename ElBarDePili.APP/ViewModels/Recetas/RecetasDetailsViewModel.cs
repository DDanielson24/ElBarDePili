using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Views.Recetas;

namespace ElBarDePili.ViewModels.Recetas
{
    [QueryProperty(nameof(Receta), "Receta")]
    public partial class RecetasDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private RecetaViewModel? _receta;

        public RecetasDetailsViewModel()
        {
        }

        [RelayCommand]
        private void GoToRecetasEditing()
        {
            if (Receta == null)
                return;

            Shell.Current.GoToAsync("Recetas/" + nameof(RecetasEditing), true,
                new Dictionary<string, object>
                {
                    {"Receta", Receta}
                });
        }

        [RelayCommand]
        private async Task DeleteReceta()
        {
            if (Receta == null)
                return;

            //await _elBarDePiliDatabase.DeleteWithChildrenAsync<Receta>(Receta);

            await Shell.Current.Navigation.PopAsync();
        }
    }
}
