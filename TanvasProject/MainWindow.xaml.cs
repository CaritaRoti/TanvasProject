using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tanvas.TanvasTouch.Resources;
using Tanvas.TanvasTouch.WpfUtilities;

namespace TanvasProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tanvas.TanvasTouch.API.Initialize();
            // ^ uncomment this and add Loaded="Window_Loaded" to the last row of the Window element in MainWindow.xaml
            // currently throws error seemingly because the output needs to be read by the Tanvas tablet
        }

        TanvasTouchViewTracker viewTracker;

        TView myView
        {
            get
            {
                return viewTracker.View;
            }
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewTracker = new TanvasTouchViewTracker(this);

            var uri = new Uri("pack://application:,,/Assets/thingy.png");
            var mySprite = PNGToTanvasTouch.CreateSpriteFromPNG(uri);

            myView.AddSprite(mySprite);
            Console.WriteLine("uwu");
        }
    }
}
