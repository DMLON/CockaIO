using CockaIO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using CockaIO.Services;

namespace CockaIO.ViewModels
{
    public class MainDashboardViewModel : ViewModelBase
    {
        public class UserView
        {
            public string Name { get; set; }
            public string Lastname { get; set; }
        }
        public UserDirectoryViewModel UserDirectoryViewModel;
        public ObservableCollection<UserView> users { get; private set; }
        public MainDashboardViewModel(IDbContextService? dbContext) : base(dbContext)
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            var query = dbContext.GetAllEntities<Users>().Select(x => new UserView{
                Name=x.Name,
                Lastname=x.Lastname 
            });
            users = new ObservableCollection<UserView>(query);
        }
       
    }
}
