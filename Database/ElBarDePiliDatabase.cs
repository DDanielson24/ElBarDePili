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

            Database.CreateTableAsync<Receta>();
            Database.CreateTableAsync<Ingrediente>();
        }

        public async Task<int> Add(object o)
        {
            var n = await Database.InsertAsync(o);
            return n;
        }

        public async Task<int> Update(object o)
        {
            var n = await Database.UpdateAsync(o);
            return n;
        }

        public async Task<int> UpdateAll(IEnumerable<object> o)
        {
            var n = await Database.UpdateAllAsync(o);
            return n;
        }

        public async Task<List<Receta>> GetRecetas()
        {
            return await Database.Table<Receta>().ToListAsync();
        }
        
        public async Task<List<Ingrediente>> GetIngredientes()
        {
            return await Database.Table<Ingrediente>().OrderBy(x => x.Nombre).ToListAsync();
        }
    }
}
