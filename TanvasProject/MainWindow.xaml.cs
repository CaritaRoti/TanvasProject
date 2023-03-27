using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
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
using Internal;

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

        public static string ConvertToGrayscale(string inputPath)
        {
            // Load the input image
            Bitmap originalImage = new Bitmap(inputPath);

            // Convert the image to grayscale
            Bitmap grayscaleImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    System.Drawing.Color color = originalImage.GetPixel(x, y);
                    int grayValue = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    grayscaleImage.SetPixel(x, y, System.Drawing.Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }

            // Save the grayscale image
            string outputDirectory = Path.GetDirectoryName(inputPath);
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_grayscale.png";
            string outputPath = Path.Combine(outputDirectory, outputFileName);
            grayscaleImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);

            // Return the path of the converted image
            return outputPath;
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewTracker = new TanvasTouchViewTracker(this);

            var uri = new Uri("pack://application:,,/Assets/thingy.png");
            var mySprite = PNGToTanvasTouch.CreateSpriteFromPNG(uri);

            myView.AddSprite(mySprite);
            Console.WriteLine("uwu");

            // Add a button to the main window
            Button convertButton = new Button();
            convertButton.Content = "Convert to Grayscale";
            convertButton.Click += ConvertButton_Click;
            this.Content = convertButton;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            // Call the ConvertToGrayscale function with the input path of your choice
            //string inputPath = @"C:\path\to\your\input\file.png";
            string outputPath = ConvertToGrayscale(inputPath);
            Console.WriteLine("Grayscale image saved to: " + outputPath);
        }
    }
}
