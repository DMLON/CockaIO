using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CockaIO.Views
{
    public class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
