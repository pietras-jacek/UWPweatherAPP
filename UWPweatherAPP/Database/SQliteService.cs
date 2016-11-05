using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPweatherAPP.Database
{
    class SQliteService
    {
        public static SQLiteConnection conn;

        public static void LoadDatabase()
        {
            // Get a reference to the SQLite database
            conn = new SQLiteConnection("SQLiteWeather.db");

            // NOTE - The Id character is actually a GUID which is 36 characters long.
            // Here we speacify it as VARCHAR(36) - but actually SQLite does not impose a length
            // limit on columns, nor rigidly enforce data types. 
            // Could have specified CHARACTER(10), VARCHAR(255), TEXT - all would work for a GUID.
            // SQLite just stores these as 'TEXT' - see http://www.sqlite.org/datatype3.html#expraff
            string sql = @"CREATE TABLE IF NOT EXISTS
                            WeatherInfo (Id      VARCHAR( 36 ) PRIMARY KEY NOT NULL,
                            DueDate              DATETIME,
                            City                 VARCHAR( 140 ),
                            WeatherConditions    VARCHAR( 140 ),
 
                            );";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}

