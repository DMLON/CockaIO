using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CockaIO.ViewModels;
using CockaIO.Views;
using CockaIO.Data;

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
                var database = new CockaioContext();
                desktop.MainWindow = new MainWindowView
                {
                    DataContext = new MainWindowViewModel(database),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
