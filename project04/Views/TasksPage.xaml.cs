using System;
using Xamarin.Forms;

using project04.Database;
using project04.ViewModels;
using project04.Models;

namespace project04.Views
{
    public partial class TasksPage : ContentPage
    {
        public TasksPage()
        {
            InitializeComponent();

            BindingContext = new TaskViewModel();
        }
    }
}
