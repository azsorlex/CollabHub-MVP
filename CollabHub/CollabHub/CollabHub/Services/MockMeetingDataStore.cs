using CollabHub.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CollabHub.Services
{
    class MockMeetingDataStore : IDataStore<Meeting>
    {
        readonly SQLiteAsyncConnection database = App.Database.Database;

        public async Task<bool> AddItemAsync(Meeting item)
        {
            return await database.InsertAsync(item) > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var meeting = database.Table<Meeting>().FirstOrDefaultAsync(m => m.ID == id);
            return meeting != null && await database.DeleteAsync(meeting) > 0;
        }

        public Task<Meeting> GetItemAsync(string id)
        {
            return database.GetAsync<Meeting>(id);
        }

        public async Task<IEnumerable<Meeting>> GetItemsAsync(bool forceRefresh = false)
        {
            return await database.Table<Meeting>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Meeting item)
        {
            return await database.UpdateAsync(item) > 0;
        }

        public async Task<bool> UpdateAllAsync(ObservableCollection<Meeting> meetings)
        {
            return await database.UpdateAllAsync(meetings) > 0;
        }
    }
}
