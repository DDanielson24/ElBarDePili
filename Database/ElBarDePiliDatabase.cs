using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
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

            Database.DropTableAsync<Ingrediente>().Wait();
            Database.CreateTableAsync<Ingrediente>().Wait();

            Database.DropTableAsync<Receta>().Wait();  
            Database.CreateTableAsync<Receta>().Wait();

            Database.DropTableAsync<RecetaIngrediente>().Wait();
            Database.CreateTableAsync<RecetaIngrediente>().Wait();
        }

        public Task<int> SaveAsync<T>(T item)
        {
            return Database.InsertAsync(item);
        }

        public Task SaveWithChildrenAsync<T>(T item)
        {
            return Database.InsertOrReplaceWithChildrenAsync(item, true);
        }

        public Task<T> GetAsync<T>(Guid id) where T : new()
        {
            return Database.GetAsync<T>(id);
        }

        public Task<T> GetWithChildrenAsync<T>(Guid id) where T : new()
        {
            return Database.GetWithChildrenAsync<T>(id);
        }

        public Task<List<T>> GetAllWithChildrenAsync<T>() where T : new()
        {
            return Database.GetAllWithChildrenAsync<T>();
        }

        public Task<int> UpdateAsync<T>(T item)
        {
            return Database.UpdateAsync(item);
        }

        public Task UpdateWithChildrenAsync<T>(T item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }

        public Task<int> DeleteAsync<T>(T item)
        {
            return Database.DeleteAsync(item);
        }

        public Task DeleteWithChildrenAsync<T>(T item)
        {
            return Database.DeleteAsync(item, true);
        }        
    }
}
