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
        private ObservableCollection<Receta> recetas = new ObservableCollection<Receta>()
        {
                new Receta()
                {
                    Nombre = "Potaje de San José",
                    Descripcion = "De la abuela Juana",
                    Imagen = "potajesanjose.jpg",
                    Duracion = TimeSpan.FromMinutes(60),
                    Dificultad = 9
                },
                new Receta()
                {
                    Nombre = "Gazpacho",
                    Descripcion = "Andaluza",
                    Imagen = "gazpacho.png",
                    Duracion = TimeSpan.FromMinutes(25),
                    Dificultad = 7
                },
                new Receta()
                {
                    Nombre = "Croquetitas de la chef",
                    Descripcion = "Española",
                    Imagen = "croquetas.png",
                    Duracion = TimeSpan.FromMinutes(45),
                    Dificultad = 6
                }
        };

        private ObservableCollection<Ingrediente> ingredientes = new ObservableCollection<Ingrediente>()
        {
            new Ingrediente()
                {
                    Nombre = "Pan"
                },
                new Ingrediente()
                {
                    Nombre = "Tomate"
                },
                new Ingrediente()
                {
                    Nombre = "Pimiento"
                },
                new Ingrediente()
                {
                    Nombre = "Jamón"
                }
        };

        public ObservableCollection<Receta> GetRecetas()
        {
            return recetas;
        }

        public ObservableCollection<Ingrediente> GetIngredientes()
        {
            return ingredientes;
        }

        public void SaveReceta(Receta receta)
        {
            if (receta == null)
                return;

            var prevReceta = recetas.Where(x => x.Id == receta.Id).FirstOrDefault();

            if (prevReceta != null)
            {
                var index = recetas.IndexOf(prevReceta);
                recetas[index] = receta;
            }
            else
                recetas.Add(receta);
        }
    }
}
