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
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new Application();
            var window = new Window()
            {
                Width = 800,
                Height = 600,
                Title = "Christoffers app",
                Icon = new BitmapImage(new Uri("pack://application:,,,/Icon/boy.png")),
            };
            var clickerA = new Clicker();
            var clickerB = new Clicker();
            var clickerC = new Clicker();

            var panel = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            panel.Children.Add(clickerA.Panel);
            panel.Children.Add(clickerB.Panel);
            panel.Children.Add(clickerC.Panel);

            window.Content = panel;
            app.Run(window);
        }
    }
}
