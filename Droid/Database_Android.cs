using System;
using System.IO;
using SQLite;
using project04.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Database_Android))]
namespace project04.Droid
{
    public class Database_Android:IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nameDB = "project04.db3";

            var pathDB = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), nameDB);

            return new SQLiteConnection(pathDB);
        }
    }
}
