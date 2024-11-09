﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using ElBarDePili.Views;
using ElBarDePili.Views.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Recetas
{
    //[QueryProperty(nameof(Receta), "Receta")]
    public partial class RecetasEditingViewModel : ObservableObject
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;
        private readonly RecetasViewModel _recetasViewModel;

        [ObservableProperty]
        private Receta _receta = new();

        [ObservableProperty]
        private List<SeleccionIngredientes> _ingredientes = new();

        [ObservableProperty]
        private ImageSource _selectedImage = "croquetas.png";
        [ObservableProperty]
        private string _selectedImagePath;

        public RecetasEditingViewModel(ElBarDePiliDatabase elBarDePiliDatabase, RecetasViewModel recetasViewModel)
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
            _recetasViewModel = recetasViewModel;

            Receta = new Receta()
            {
                Nombre = "esto es una prueba"
            };

            GetIngredientesAsync();
        }

        public async void GetIngredientesAsync()
        {
            List<Ingrediente> ingredientes = await _elBarDePiliDatabase.GetAllWithChildrenAsync<Ingrediente>();
            foreach (var ingrediente in ingredientes)
            {
                if (ingrediente.Recetas != null)
                    Ingredientes.Add(new SeleccionIngredientes
                    {
                        Ingrediente = ingrediente,
                        Seleccionado = ingrediente.Recetas.Any(x => x.Id == Receta.Id)
                    });
                else
                    Ingredientes.Add(new SeleccionIngredientes
                    {
                        Ingrediente = ingrediente,
                        Seleccionado = false
                    });
            }
        }

        [RelayCommand]
        private async Task SaveEditing()
        {
            if (Receta == null)
                return;

            List<Ingrediente>? ingredientesSeleccionados = Ingredientes?.Where(x => x.Seleccionado).Select(x => x.Ingrediente).ToList();
            if (ingredientesSeleccionados != null)
            {
                Receta.Ingredientes = ingredientesSeleccionados;
            }

            var recetas = await _elBarDePiliDatabase.GetAllWithChildrenAsync<Receta>();

            if (recetas.Where(x => x.Id.Equals(Receta.Id)).Any())
            {
                await _elBarDePiliDatabase.UpdateWithChildrenAsync(Receta);
            }
            else
            {
                await _elBarDePiliDatabase.SaveWithChildrenAsync(Receta);
                _recetasViewModel.Recetas.Add(Receta);
            }

            //IMAGEN
            try
            {
                if (!string.IsNullOrEmpty(SelectedImagePath))
                {
                    var fileName = Path.GetFileName(SelectedImagePath);
                    var destinationPath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                    using (var sourceStream = File.OpenRead(SelectedImagePath))
                    using (var destinationStream = File.Create(destinationPath))
                    {
                        await sourceStream.CopyToAsync(destinationStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            var editingPage = Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 1];
            var detailsPage = Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2];

            await Shell.Current.GoToAsync(nameof(RecetasDetails), true,
                new Dictionary<string, object>
                {
                    {"Receta", Receta}
                });

            if (editingPage != null) Shell.Current.Navigation.RemovePage(editingPage);
            if (detailsPage != null) Shell.Current.Navigation.RemovePage(detailsPage);
        }

        [RelayCommand]
        private async void SelectImage()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions()
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Selecciona una imagen"
                });

                if (result != null)
                {
                    // Abrir el flujo de la imagen y mantenerlo abierto mientras se utiliza
                    var stream = await result.OpenReadAsync();
                    SelectedImage = ImageSource.FromStream(() => stream);
                    SelectedImagePath = result.FullPath;
                    Receta.Imagen = Path.Combine(FileSystem.AppDataDirectory, Path.GetFileName(result.FullPath));
                }
            }
            catch { }
        }
    }

    public class SeleccionIngredientes
    {
        public Ingrediente Ingrediente { get; set; }
        public bool Seleccionado { get; set; }
    }
}
