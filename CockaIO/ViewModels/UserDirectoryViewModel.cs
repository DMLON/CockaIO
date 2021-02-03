using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using CockaIO.Models;
using System.Data.SqlTypes;
using CockaIO.Services;
using System.Linq;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Diagnostics;
using Avalonia.Interactivity;

namespace CockaIO.ViewModels
{
    public class UserDirectoryViewModel: ViewModelBase
    {
        public class UserView
        {
            public string Name;
            public string Lastname;
        }

        public ObservableCollection<Users> Users { get; private set; }
        

        private Users selectedUser;
        public Users SelectedUser{
            get => selectedUser;
            private set => this.RaiseAndSetIfChanged(ref selectedUser, value);
        }
        public UserDirectoryViewModel(IDbContextService dbContext) : base(dbContext)
        {
            LoadUsers();
            //Get the user and use it as a command, will be observed by the main view
            SelectedUserChangedCommand = ReactiveCommand.Create<Users,Users>(x=>x);
            var SelectedUserChanged_ = this.WhenAnyValue(x=>x.SelectedUser).InvokeCommand(SelectedUserChangedCommand);
            
        }

        public void LoadUsers()
        {
            var query = dbContext.GetAllEntities<Users>();
            Users = new ObservableCollection<Users>(query);
        }

        public ReactiveCommand<Users, Users> SelectedUserChangedCommand { get; private set; }
        //public Users SelectedUserChanged(Users newUser)
        //{
        //    //Change user in the other view
        //    //TODO: Make contact with other view!, show details
        //    return SelectedUser;
        //}

    }
}
