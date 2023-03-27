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
using Path = System.IO.Path;
using System.Drawing.Imaging;
using System.Windows.Forms;

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
            // remember to run Tanvas Engine before running the app, otherwise the initialization won't work
        }

        TanvasTouchViewTracker viewTracker;

        TView myView
        {
            get
            {
                return viewTracker.View;
            }
        }

        /**
         * Captures a screenshot of the screen and saves it in the assets directory
         */
        private void takeScreenshot(object sender, RoutedEventArgs e)
        {
            try
            {
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1024, 768, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will
                //capture our Current Screen
                System.Drawing.Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                //Saving the Image File (I am here Saving it in My E drive).
                captureBitmap.Save(@"C:\Users\lakan\source\repos\TanvasProject\TanvasProject\Assets\Capture.jpg", ImageFormat.Png);
                //Displaying the Successfull Result
                System.Windows.MessageBox.Show("Screen Captured");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        /**
         * Converts an image to grayscale and saves it to the same location in a new file
         */
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
            // creating a haptic sprite
            viewTracker = new TanvasTouchViewTracker(this);

            var uri = new Uri("pack://application:,,/Assets/thingy2.png");
            var mySprite = PNGToTanvasTouch.CreateSpriteFromPNG(uri);

            myView.AddSprite(mySprite);


            // Add a button to the main window
            /*Button convertButton = new Button();
            convertButton.Content = "Convert to Grayscale";
            convertButton.Click += ConvertButton_Click;
            this.Content = convertButton;*/
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            // Call the ConvertToGrayscale function with the input path of your choice
            var inputPath = new Uri("pack://application:,,/Assets/thingy2.png").ToString();
            string outputPath = ConvertToGrayscale(inputPath);
            Console.WriteLine("Grayscale image saved to: " + outputPath);
        }
    }
}
