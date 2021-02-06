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
using ReactiveUI.Fody.Helpers;
using CockaIO.Data;
using Avalonia.Controls;

namespace CockaIO.ViewModels
{
    public class UserDirectoryViewModel: ViewModelBase
    {
        public ObservableCollection<Users> Users { get; private set; }


        [Reactive]
        public Users SelectedUser{ get; private set; }

        public UserDirectoryViewModel(IDbContextService dbContext) : base(dbContext)
        {
            //Load Users
            var query = dbContext.GetAllEntities<Users>();
            Users = new ObservableCollection<Users>(query);
            SelectedUser = Users.First();

            //Get the user and use it as a command, will be observed by the main view
            SelectedUserChangedCommand = ReactiveCommand.Create<Users,Users>(x=>x);
            var SelectedUserChanged_ = this.WhenAnyValue(x=>x.SelectedUser).InvokeCommand(SelectedUserChangedCommand);
            
        }

        //Pipe command to get and return the selected user
        public ReactiveCommand<Users, Users> SelectedUserChangedCommand { get; private set; }

    }

    //Design class
    public class dUserDirectoryViewModel : UserDirectoryViewModel
    {
        public dUserDirectoryViewModel() : base(new TestDatabase()) { }
    }
}
