using CollabHub.Models;
using CollabHub.Models.Chat;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollabHub.Services
{
    class MessageDataStore : IDataStore<Message>
    {
        readonly SQLiteAsyncConnection database = App.Database.Database;

        public async Task<bool> AddItemAsync(Message message)
        {
            return await database.InsertAsync(message) > 0;
        }

        public async Task<bool> DeleteItemAsync(string text)
        {
            var user = database.Table<Message>().FirstOrDefaultAsync(i => i.Text == text);
            return user != null && await database.DeleteAsync(user) > 0;
        }

        public Task<Message> GetItemAsync(string text)
        {
            return database.GetAsync<Message>(text);
        }

        public async Task<IEnumerable<Message>> GetItemsAsync(bool forceRefresh = false)
        {
            return await database.Table<Message>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Message message)
        {
            return await database.UpdateAsync(message) > 0;
        }
    }
}
