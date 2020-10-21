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

        public async Task<bool> AddItemAsync(Alert message)
        {
            return await database.InsertAsync(message) > 0;
        }

        public async Task<bool> DeleteItemAsync(string date)
        {
            var user = database.Table<Alert>().FirstOrDefaultAsync(i => i.Date.ToString("d") == date);
            return user != null && await database.DeleteAsync(user) > 0;
        }

        public Task<Alert> GetItemAsync(string text)
        {
            return database.GetAsync<Alert>(text);
        }

        public async Task<IEnumerable<Alert>> GetItemsAsync(bool forceRefresh = false)
        {
            return await database.Table<Alert>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Alert message)
        {
            return await database.UpdateAsync(message) > 0;
        }
    }
}
