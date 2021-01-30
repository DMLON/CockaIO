using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CockaIO.Views
{
    public class UserDirectoryView : UserControl
    {
        public UserDirectoryView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
