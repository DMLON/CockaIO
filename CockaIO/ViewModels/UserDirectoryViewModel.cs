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
        //public ReactiveCommand<Unit, Unit> SelectedUserChangedCommand;

        private Users selectedUser;
        public Users SelectedUser{
            get => selectedUser;
            private set => this.RaiseAndSetIfChanged(ref selectedUser, value);
        }
        public UserDirectoryViewModel(IDbContextService? dbContext) : base(dbContext)
        {
            LoadUsers();
            this.WhenAnyValue(x => x.SelectedUser).Subscribe(x=>SelectedUserChanged());

            //SelectedUserChangedCommand = ReactiveCommand.Create(SelectedUserChanged);
        }

        public void LoadUsers()
        {
            var query = dbContext.GetAllEntities<Users>();
            Users = new ObservableCollection<Users>(query);
        }

        public void SelectedUserChanged()
        {
            string a = "a" + "b";
        }

    }
}
