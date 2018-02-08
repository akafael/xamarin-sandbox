using System;

using SQLite;

namespace project04.Models
{
    [Table("Tasks")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public bool isFinished { get; set; }
    }
}
