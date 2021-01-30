using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using CockaIO.Models;
using System.Data.SqlTypes;
using CockaIO.Services;

namespace CockaIO.ViewModels
{
    public class UserDirectoryViewModel : ViewModelBase
    {
        ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public UserDirectoryViewModel(IDbContextService? dbContext) : base(dbContext)
        {
            content = new MainDashboardViewModel(dbContext);
        }

    }
}
