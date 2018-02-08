using System;
using System.IO;
using project04.iOS;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(Database_ios))]
namespace project04.iOS
{
    public class Database_ios:IDatabase
    {

        public SQLiteConnection GetConnection()
        {
            var nameDB = "project04.db3";
            var personalFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            string pathDB = Path.Combine(libraryFolder, nameDB);

            return new SQLiteConnection(pathDB);
        }
    }
}
