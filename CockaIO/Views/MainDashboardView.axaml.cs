using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CockaIO.Views
{
    public class MainDashboardView : UserControl
    {
        public MainDashboardView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
