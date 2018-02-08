using System;
using SQLite;

namespace project04
{
    public interface IDatabase
    {
        SQLiteConnection GetConnection();
    }
}
