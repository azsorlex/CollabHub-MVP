using CollabHub.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CollabHub.Services
{
    class MeetingDataStore : IDataStore<Meeting>
    {
        readonly SQLiteAsyncConnection database = App.Database.Database;

        public async Task<bool> AddItemAsync(Meeting item)
        {
            return await database.InsertAsync(item) > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await database.DeleteAsync(await GetItemAsync(id)) > 0;
        }

        public async Task<Meeting> GetItemAsync(string id)
        {
            return await database.GetAsync<Meeting>(id);
        }

        public async Task<IEnumerable<Meeting>> GetItemsAsync(bool forceRefresh = false)
        {
            return await (from m in database.Table<Meeting>() orderby m.Date select m).ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Meeting item)
        {
            return await database.UpdateAsync(item) > 0;
        }
    }
}
