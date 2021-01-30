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

namespace CockaIO.ViewModels
{
    public class MainDashboardViewModel : ViewModelBase
    {
        ViewModelBase content;
        public UserDirectoryViewModel UserDirectoryViewModel { get; set; }
        
        public MainDashboardViewModel(IDbContextService? dbContext) : base(dbContext)
        {
            Content = UserDirectoryViewModel = new UserDirectoryViewModel(dbContext);
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

    }
}
