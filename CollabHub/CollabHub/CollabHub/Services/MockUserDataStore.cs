using CollabHub.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollabHub.Services
{
    class MockUserDataStore : IDataStore<User>
    {
        readonly SQLiteAsyncConnection database = App.Database.Database;

        public async Task<bool> AddItemAsync(User user)
        {
            return await database.InsertAsync(user) > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var user = database.Table<User>().FirstOrDefaultAsync(i => i.Id == id);
            return user != null && await database.DeleteAsync(user) > 0;
        }

        public Task<User> GetItemAsync(string id)
        {
            return database.GetAsync<User>(id);
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await database.Table<User>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(User user)
        {
            return await database.UpdateAsync(user) > 0;
        }
    }
}
