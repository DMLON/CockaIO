using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CockaIO.Views
{
    public class UserInfoView : UserControl
    {
        public UserInfoView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
