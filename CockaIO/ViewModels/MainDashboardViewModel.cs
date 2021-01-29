using CockaIO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace CockaIO.ViewModels
{
    public class MainDashboardViewModel : ViewModelBase
    {
        public ObservableCollection<Users> users { get; private set; }
        public MainDashboardViewModel(CockaioContext? dbContext) : base(dbContext)
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            var query = dbContext.Users.Select(x => x);
            users = new ObservableCollection<Users>(query);
        }
        string greetings => "Hello world!";
    }
}
