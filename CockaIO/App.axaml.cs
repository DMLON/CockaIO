using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CockaIO.ViewModels;
using CockaIO.Views;
using CockaIO.Data;
using System;
using Avalonia.Controls;
using CockaIO.Services;

namespace CockaIO
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {

                IDbContextService database;
                if (Design.IsDesignMode)
                    database = new TestDatabase();
                else
                    database = new CockaioContext();

                //var database = new TestDatabase();
                if (database == null)
                    throw new Exception("Error getting database context!");

                desktop.MainWindow = new MainWindowView
                {
                    DataContext = new MainWindowViewModel(database),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
