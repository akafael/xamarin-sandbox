using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using project04.Models;
using project04.Views;
using project04.Database;

namespace project04.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public Task selectedTask { get; set; }
        public ObservableCollection<Task> tasks { get; set; }
        public Command saveCommand { get; set; }
        public Command editCommand { get; set; }
        public Command deleteCommand { get; set; }
        public Command tougleStatusCommand { get; set; }

        public TaskViewModel()
        {
            selectedTask = new Task();
            tasks = new ObservableCollection<Task>(new TaskDataAcess().GetTasks());
            saveCommand = new Command(SaveTask);
            editCommand = new Command<Task>(EditTask);
            deleteCommand = new Command<Task>(DeleteTask);
            tougleStatusCommand = new Command<Task>(TougleStatusTask);
        }

        private void SaveTask()
        {
            if(selectedTask.id == 0)
            {
                selectedTask.isFinished = false;
                tasks.Add(selectedTask);
                new TaskDataAcess().SaveTask(selectedTask);
            }
            else
            {
                var db = new TaskDataAcess();
                db.UpdateTask(selectedTask);
                tasks = new ObservableCollection<Task>(db.GetTasks());
                OnPropertyChanged("tasks");
            }

            selectedTask = new Task();
            OnPropertyChanged("selectedTask");
        }

        private void EditTask(Task task)
        {
            selectedTask = task;

            OnPropertyChanged("selectedTask");
        }

        private void DeleteTask(Task task)
        {
            var db = new TaskDataAcess();
            db.DeleteTask(task);
            tasks.Remove(task);
        }

        private void TougleStatusTask(Task task)
        {
            var db = new TaskDataAcess();
            task.isFinished = !task.isFinished;
            db.UpdateTask(task);
            tasks = new ObservableCollection<Task>(db.GetTasks());
            OnPropertyChanged("tasks");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
