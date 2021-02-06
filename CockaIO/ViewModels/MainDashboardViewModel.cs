using CockaIO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using CockaIO.Services;
using ReactiveUI;
using System.Reactive.Linq;
using ReactiveUI.Fody.Helpers;
using Avalonia.Controls;

namespace CockaIO.ViewModels
{
    public class MainDashboardViewModel : ViewModelBase
    {
        public UserDirectoryViewModel UserDirectoryViewModel { get; set; }
        
        public MainDashboardViewModel(IDbContextService dbContext) : base(dbContext)
        {
            //Left Collapsing panel
            //Users
            //----Add
            //Cars
            //----Add
            //Delete should be in Info, after selecting
            //User should be able to add new cars in a new window in info panel
            Content = UserDirectoryViewModel = new UserDirectoryViewModel(dbContext);
            UserDirectoryViewModel.SelectedUserChangedCommand.Subscribe(SelectedUserChanged);
        }

        [Reactive]
        public ViewModelBase Content { get; private set; }

        public void SelectedUserChanged(Users user)
        {
            if (user != null)
                //Show in other view the user data
                Console.WriteLine($"I got {user.Name}!");
        }

    }
}
