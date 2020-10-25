using CollabHub.Models;
using CollabHub.Models.Chat;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollabHub.Services
{
    class AlertDataStore : IDataStore<Alert>
    {
        readonly SQLiteAsyncConnection database = App.Database.Database;

        public async Task<bool> AddItemAsync(Alert alert)
        {
            return await database.InsertAsync(alert) > 0;
        }

        public async Task<bool> DeleteItemAsync(string name)
        {
            var alert = database.Table<Alert>().FirstOrDefaultAsync(i => i.Name == name);
            return alert != null && await database.DeleteAsync(alert) > 0;
        }

        public Task<Alert> GetItemAsync(string name)
        {
            return database.GetAsync<Alert>(name);
        }

        public async Task<IEnumerable<Alert>> GetItemsAsync(bool forceRefresh = false)
        {
            return await database.Table<Alert>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Alert alert)
        {
            return await database.UpdateAsync(alert) > 0;
        }
    }
}
