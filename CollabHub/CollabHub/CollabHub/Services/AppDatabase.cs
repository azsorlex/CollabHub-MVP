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
                await Database.CreateTablesAsync(CreateFlags.None, typeof(Message)).ConfigureAwait(false);
                await Database.CreateTablesAsync(CreateFlags.None, typeof(Alert)).ConfigureAwait(false); 
                try
                {
                    await Database.Table<Meeting>().CountAsync(); // Determine if the table exists
                } 
                catch // If an exception is caught, the table doesn't exist
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Meeting)).ConfigureAwait(false);
                    await PopulateMeetingTableAsync(); // Add some default data to the table
                }

                try
                {
                    //await Database.Table<Alert>().CountAsync(); // Determine if the table exists
                    if(await Database.Table<Alert>().CountAsync() == 0)
                    {
                        PopulateAlertTableAsync();
                    }
                }
                catch // If an exception is caught, the table doesn't exist
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Alert)).ConfigureAwait(false);
                    await PopulateAlertTableAsync(); // Add some default data to the table
                }
                //await Database.DropTableAsync<Meeting>();
                //await PopulateAlertTableAsync();
                initialized = true;
            }
        }

        async Task PopulateAlertTableAsync()
        {
            var Alerts = new List<Alert>()
            {
            SingletonAlertStore.ConvertAlert(new Calendar_Alert("Final Exam",new DateTime(2020,1,7),"12:00","One Time","CAB123",true)),
            SingletonAlertStore.ConvertAlert(new Calendar_Alert("Assignment 2",new DateTime(2020,2,6),"03:00","One Time","IFB999",true)),
            SingletonAlertStore.ConvertAlert(new Calendar_Alert("Monthly Meeting",new DateTime(2020,1,9),"11:59","Monthly","EGB101",true))

        };
            await Database.InsertAllAsync(Alerts);
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
                    EndDate = new DateTime(2020, 11, 11), // Precice time isn't necessary here
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB432",
                    Date = new DateTime(2020, 7, 22, 11, 0, 0),
                    EndDate = new DateTime(2020, 11, 11),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                
                new Meeting() // Ryan's sessions
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB240",
                    Date = new DateTime(2020, 7, 20, 10, 30, 0),
                    EndDate = new DateTime(2020, 11, 9),
                    DurationHours = 1,
                    DurationMinutes = 30
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 22, 10, 0, 0),
                    EndDate = new DateTime(2020, 11, 11),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "IAB206",
                    Date = new DateTime(2020, 7, 22, 12, 30, 0),
                    EndDate = new DateTime(2020, 11, 11),
                    DurationHours = 1,
                    DurationMinutes = 30
                },

                new Meeting() // Noah's sessions
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "IFB295",
                    Date = new DateTime(2020, 7, 28, 9, 0, 0),
                    EndDate = new DateTime(2020, 11, 10),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "EGB339",
                    Date = new DateTime(2020, 7, 29, 11, 0, 0),
                    EndDate = new DateTime(2020, 11, 11),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 23, 9, 0, 0),
                    EndDate = new DateTime(2020, 11, 12),
                    DurationHours = 2,
                    DurationMinutes = 0
                },
                new Meeting()
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "EGB339",
                    Date = new DateTime(2020, 7, 30, 11, 0, 0),
                    EndDate = new DateTime(2020, 11, 12),
                    DurationHours = 1,
                    DurationMinutes = 0
                },

                new Meeting() // Peter's sessions
                {
                    ID = Guid.NewGuid().ToString(),
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 23, 15, 0, 0),
                    EndDate = new DateTime(2020, 11, 12),
                    DurationHours = 2,
                    DurationMinutes = 0
                }
            };

            await Database.InsertAllAsync(Meetings);
        }
    }
}
