using CollabHub.Extensions;
using CollabHub.Models;
using CollabHub.Models.Chat;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabHub.Services
{
    public class AppDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        public SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public AppDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false); // Initialise the user table if it doesn't exist
                await Database.CreateTablesAsync(CreateFlags.None, typeof(Message)).ConfigureAwait(false); // Initialise the message table if it doesn't exist
                try
                {
                    await Database.Table<Meeting>().CountAsync(); // Determine if the table exists
                } 
                catch // If an exception is caught, the table doesn't exist
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Meeting)).ConfigureAwait(false);
                    await PopulateMeetingTableAsync();
                }
                initialized = true;
            }
        }



        async Task PopulateMeetingTableAsync()
        {
            var Meetings = new List<Meeting>()
            {
                new Meeting() // Alex's sessions
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "IAB330",
                    Date = new DateTime(2020, 7, 29, 15, 0, 0), // Format: year, month, day, hour, minute, second
                    EndDate = new DateTime(2020, 10, 21), // Precice time isn't necessary here
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB432",
                    Date = new DateTime(2020, 7, 22, 11, 0, 0),
                    EndDate = new DateTime(2020, 10, 21),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                
                new Meeting() // Ryan's sessions
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB240",
                    Date = new DateTime(2020, 7, 20, 10, 30, 0),
                    EndDate = new DateTime(2020, 10, 19),
                    DurationHours = 1,
                    DurationMinutes = 30
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 22, 10, 0, 0),
                    EndDate = new DateTime(2020, 10, 21),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "IAB206",
                    Date = new DateTime(2020, 7, 22, 12, 30, 0),
                    EndDate = new DateTime(2020, 10, 21),
                    DurationHours = 1,
                    DurationMinutes = 30
                },

                new Meeting() // Noah's sessions
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "IFB295",
                    Date = new DateTime(2020, 7, 28, 9, 0, 0),
                    EndDate = new DateTime(2020, 10, 20),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "EGB339",
                    Date = new DateTime(2020, 7, 29, 11, 0, 0),
                    EndDate = new DateTime(2020, 10, 21),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 23, 9, 0, 0),
                    EndDate = new DateTime(2020, 10, 22),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "EGB339",
                    Date = new DateTime(2020, 7, 30, 11, 0, 0),
                    EndDate = new DateTime(2020, 10, 22),
                    DurationHours = 1,
                    DurationMinutes = 0
                },

                new Meeting() // Peter's sessions
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 23, 15, 0, 0),
                    EndDate = new DateTime(2020, 10, 22),
                    DurationHours = 2,
                    DurationMinutes = 0
                }
            };

            await Database.InsertAllAsync(Meetings);
        }
    }
}
