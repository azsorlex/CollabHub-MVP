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
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false); // Initialise the user table if it doesn't exist
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Message).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Message)).ConfigureAwait(false); // Initialise the message table if it doesn't exist
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Meeting).Name))
                {
                    // This code breaks the application.
                    //await Database.CreateTablesAsync(CreateFlags.None, typeof(Meeting)).ConfigureAwait(false); // Initialise the meeting table if it doesn't exist
                    //await PopulateMeetingTableAsync();
                }
                initialized = true;
            }
        }



        async Task PopulateMeetingTableAsync()
        {
            List<Meeting> Meetings = new List<Meeting>()
            {
                new Meeting() // Alex's sessions
                {
                    UnitCode = "IAB330",
                    Date = new DateTime(2020, 7, 29, 15, 0, 0), // Format: year, month, day, hour, minute, second
                    EndDate = new DateTime(2020, 10, 21), // Precice time isn't necessary here
                    Duration = new KeyValuePair<byte, byte>(2, 0)
                },
                new Meeting()
                {
                    UnitCode = "CAB432",
                    Date = new DateTime(2020, 7, 22, 11, 0, 0),
                    EndDate = new DateTime(2020, 10, 21),
                    Duration = new KeyValuePair<byte, byte>(2, 0)
                },
                
                new Meeting() // Ryan's sessions
                {
                    UnitCode = "CAB240",
                    Date = new DateTime(2020, 7, 20, 10, 30, 0),
                    EndDate = new DateTime(2020, 10, 19),
                    Duration = new KeyValuePair<byte, byte>(1, 30)
                },
                new Meeting()
                {
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 22, 10, 0, 0),
                    EndDate = new DateTime(2020, 10, 21),
                    Duration = new KeyValuePair<byte, byte>(2, 0)
                },
                new Meeting()
                {
                    UnitCode = "IAB206",
                    Date = new DateTime(2020, 7, 22, 12, 30, 0),
                    EndDate = new DateTime(2020, 10, 21),
                    Duration = new KeyValuePair<byte, byte>(1, 30)
                },

                new Meeting() // Noah's sessions
                {
                    UnitCode = "IFB295",
                    Date = new DateTime(2020, 7, 28, 9, 0, 0),
                    EndDate = new DateTime(2020, 10, 20),
                    Duration = new KeyValuePair<byte, byte>(2, 0)
                },
                new Meeting()
                {
                    UnitCode = "EGB339",
                    Date = new DateTime(2020, 7, 29, 11, 0, 0),
                    EndDate = new DateTime(2020, 10, 21),
                    Duration = new KeyValuePair<byte, byte>(2, 0)
                },
                new Meeting()
                {
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 23, 9, 0, 0),
                    EndDate = new DateTime(2020, 10, 22),
                    Duration = new KeyValuePair<byte, byte>(2, 0)
                },
                new Meeting()
                {
                    UnitCode = "EGB339",
                    Date = new DateTime(2020, 7, 30, 11, 0, 0),
                    EndDate = new DateTime(2020, 10, 22),
                    Duration = new KeyValuePair<byte, byte>(1, 0)
                },

                new Meeting() // Peter's sessions
                {
                    UnitCode = "CAB303",
                    Date = new DateTime(2020, 7, 23, 15, 0, 0),
                    EndDate = new DateTime(2020, 10, 22),
                    Duration = new KeyValuePair<byte, byte>(2, 0)
                }
            };

            await Database.InsertAllAsync(Meetings);
        }
    }
}
