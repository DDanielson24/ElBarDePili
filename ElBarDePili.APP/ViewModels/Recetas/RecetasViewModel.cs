using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Views.Recetas;
using System.Collections.ObjectModel;

namespace ElBarDePili.ViewModels.Recetas
{
    public partial class RecetasViewModel : BaseViewModel
    {        
        [ObservableProperty]
        private ObservableCollection<RecetaViewModel> _recetas = new ();

        public RecetasViewModel()
        {
            Title = "Recetas";
        }

        [RelayCommand]
        private async Task GetRecetasAsync()
        {
            Recetas = new ObservableCollection<RecetaViewModel>();

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }
            try
            {
                using (HttpClient client = new())
                {
                    HttpRequestMessage request = new(HttpMethod.Get, "http://10.0.2.2:5034/Recetas/GetRecetas");
                    var response = client.SendAsync(request).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        [RelayCommand]
        private async Task GoToRecetasDetails(RecetaViewModel receta)
        {
            //if (receta == null)
            //    return;

            //var ingredientes = await _elBarDePiliDatabase.GetAllWithChildrenAsync<Ingrediente>();

            //await Shell.Current.GoToAsync("Recetas/" + nameof(RecetasDetails), true,
            //    new Dictionary<string, object>
            //    {
            //        {"Receta", receta}
            //    });
        }

        [RelayCommand]
        private async Task GoToAniadirReceta()
        {
            await Shell.Current.GoToAsync("Recetas/" + nameof(RecetasEditing), true,
                new Dictionary<string, object>
                {
                    {"Receta", new RecetaViewModel()}
                });
        }
    }
}
