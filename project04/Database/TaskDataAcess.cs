
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using project04.Models;
using Xamarin.Forms;

namespace project04.Database
{
    public class TaskDataAcess
    {
        private SQLiteConnection _database;

        public TaskDataAcess()
        {
            _database = DependencyService.Get<IDatabase>().GetConnection();
            _database.CreateTable<Task>();
        }

        public List<Task> GetTasks()
        {
            return _database.Table<Task>().ToList();
        }

        public void SaveTask(Task mTask)
        {
            _database.Insert(mTask); 
        }

        public void DeleteTask(Task mTask)
        {
            _database.Delete(mTask);
        }

        public void UpdateTask(Task mTask)
        {
            _database.Update(mTask);
        }
    }
}

