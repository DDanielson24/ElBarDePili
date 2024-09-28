using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElBarDePili.Models;

namespace ElBarDePili.Database
{
    public class ElBarDePiliDatabase
    {
        SQLiteAsyncConnection Database;

        public ElBarDePiliDatabase()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            Init();
        }

        private async Task Init()
        {
            await Database.DropTableAsync<Receta>();
            await Database.CreateTableAsync<Receta>();

            await Database.DropTableAsync<Ingrediente>();
            await Database.CreateTableAsync<Ingrediente>();

            await Database.InsertAsync(new Ingrediente()
            {
                Nombre = "Jamón"
            });

            await Database.InsertAsync(new Ingrediente()
            {
                Nombre = "Pimiento"
            });

            await Database.InsertAsync(new Receta()
            {
                Nombre = "Tortilla"
            });

            await Database.InsertAsync(new Receta()
            {
                Nombre = "Huevos revueltos"
            });
        }

        public async Task<int> Add(object o)
        {
            await Init();

            var n = await Database.InsertAsync(o);
            return n;
        }

        public async Task<List<Receta>> GetRecetas()
        {
            await Init();

            return await Database.Table<Receta>().ToListAsync();
        }
        
        public async Task<List<Ingrediente>> GetIngredientes()
        {
            await Init();

            return await Database.Table<Ingrediente>().ToListAsync();
        }
    }
}
