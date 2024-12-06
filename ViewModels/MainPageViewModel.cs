using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using ElBarDePili.Views;
using ElBarDePili.Views.Ingredientes;
using ElBarDePili.Views.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;

        public MainPageViewModel(ElBarDePiliDatabase elBarDePiliDatabase) 
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
        }
    }
}
