using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace WPFTerje
{
    class OldProgram
    {
        private static int _clicks;
        private static Label _label;

        [STAThread]
        public static void MainX(string[] args)
        {
            var app = new Application();
            var window = new Window()
            {
                Width = 800,
                Height = 600,
                Title = "Christoffers app",
                Icon = new BitmapImage(new Uri("pack://application:,,,/Icon/boy.png"))
            };
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
                FontSize = 24,
                Background = new SolidColorBrush(Colors.LightBlue)
            };
            var panel = new StackPanel();
            panel.Children.Add(_label);
            panel.Children.Add(button);
            window.Content = panel;
            app.Run(window);
        }

        private static void ButtonClick(object sender, RoutedEventArgs e)
        {
            _clicks++;
            _label.Content = _clicks;
        }
    }
}
