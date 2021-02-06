using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using CockaIO.Models;
using System.Data.SqlTypes;
using CockaIO.Services;
using ReactiveUI.Fody.Helpers;

namespace CockaIO.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //ViewModelBase content;

        [Reactive]
        public ViewModelBase Content { get; private set; }

        public MainWindowViewModel(IDbContextService dbContext) : base(dbContext)
        {
            Content = new MainDashboardViewModel(dbContext);
        }

    }
}
