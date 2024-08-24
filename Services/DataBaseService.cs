using ElBarDePili.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.Services
{
    public class DataBaseService
    {
        public ObservableCollection<Receta> GetRecetas()
        {
            return new ObservableCollection<Receta>()
            {
                new Receta()
                {
                    Nombre = "Potaje de San José"
                },
                new Receta()
                {
                    Nombre = "Gazpacho"
                },
                new Receta()
                {
                    Nombre = "Croquetitas de la chef"
                }
            };
        }
    }
}
