using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace WPFTerje
{
    internal class Clicker
    {
        private int _clicks;
        private Label _label;
        public StackPanel Panel { get; private set; }
        public Clicker()
        {
            var button = new Button
            {
                Content = "Klikk",
                Width = 100
            };
            button.Click += ButtonClick;
            _label = new Label
            {
                Content = "0",
                Width = 150,
                FontSize = 36,
                Background = new SolidColorBrush(Colors.LightBlue),
                Height = 100,
            };
            
            Panel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(5),
            };
            Panel.Children.Add(_label);
            Panel.Children.Add(button);
            
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            _clicks++;
            _label.Content = _clicks;
        }
    }
}
