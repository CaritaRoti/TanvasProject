using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tanvas.TanvasTouch.Resources;
using Tanvas.TanvasTouch.WpfUtilities;
using Path = System.IO.Path;
using Point = System.Windows.Point;
using Button = System.Windows.Controls.Button;
using Brush = System.Drawing.Brush;
using System.Drawing.Imaging;

namespace TanvasProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        int button_status = 0;

        public MainWindow()
        {
            InitializeComponent();
            Tanvas.TanvasTouch.API.Initialize(); // remember to run Tanvas Engine before running the app, otherwise the initialization won't work
            WindowState = WindowState.Maximized; // Maximise the screen on start

            //Declaring the elements on the screen globally
            slider.Visibility = Visibility.Collapsed;
            vup.Visibility = Visibility.Collapsed;
            vdown.Visibility = Visibility.Collapsed;
            volume.Visibility = Visibility.Collapsed;
            volume_b.Visibility = Visibility.Collapsed;
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
                Window window = Application.Current.Windows.OfType<Window>().Single(x => x.IsActive);

                // Render the current control (window) with specified parameters of: Width, Height, horizontal DPI
                // of the bitmap, vertical DPI of the bitmap, The format of the bitmap
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)window.ActualWidth-16,
                                                                               (int)window.ActualHeight-39,
                                                                               96, 96, 
                                                                               PixelFormats.Pbgra32);
                renderTargetBitmap.Render(window);

                // Encoding the rendered bitmap
                PngBitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                
                // Save the image
                string screenshotPath = @"..\Assets\appScreenshot.png";
                using (Stream stm = File.Create(screenshotPath))
                {
                    png.Save(stm);
                    stm.Close();
                }

                ConvertToGrayscale(screenshotPath);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void deleteAllSprites(object sender, RoutedEventArgs e)
        {
            myView.RemoveAllSprites();
        }
        /**
         * Button click event handler to create a haptic map from the current screen
         */
        private void createHapticImage(object sender, RoutedEventArgs e)
        {
            drawHapticImage(mainGrid);
            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            using (var stream = new FileStream(@"..\Assets\appHapticSprite.png", FileMode.Open))
            {
                var uri = new Uri(stream.Name);
                stream.Close(); //added close to make sure the resourses are released. Still the issue is there
                var mySprite = PNGToTanvasTouch.CreateSpriteFromPNG(uri);                
                // To combat random sprite offset, setting coordinates
                mySprite.X = 350;
                myView.RemoveAllSprites();
                Console.WriteLine(myView.GetAllSprites());
                myView.AddSprite(mySprite);
                
            }

           

            
        }

        //private void updateHapticImage(RoutedEventArgs e)
        //{
        //    Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
        //    Window_Loaded(window, e);


        //}

        /**
         * Draws the haptics image for the given grid and saves it in the assets directory
         */
        private void drawHapticImage(Grid grid)
        {
            try
            {
                Window window = Application.Current.Windows.OfType<Window>().Single(w => w.IsActive);

                Bitmap hapticsSpriteImg = new Bitmap((int)window.ActualWidth - 16, (int)window.ActualHeight - 39);
                Graphics hapticsMap = Graphics.FromImage(hapticsSpriteImg);
                Brush brush = new SolidBrush(System.Drawing.Color.Black);

                // Adding a white bg to the haptics map
                hapticsMap.Clear(System.Drawing.Color.White);

                // Draw each Button from the given grid into the haptics sprite image
                grid.Children.OfType<Button>().ToList().ForEach(
                    btn => drawButtonHaptics(btn, hapticsMap, brush));

                // Draw each Button from the given grid into the haptics sprite image
                grid.Children.OfType<Slider>().ToList().ForEach(
                    sldr => drawSliderHaptics(sldr, hapticsMap, brush, 5, 30, 1.1f));

                // Save the sprite img
                string spriteImgPath = @"..\Assets\appHapticSprite.png";

                if (File.Exists(spriteImgPath))
                {
                    using (var stream = new FileStream(spriteImgPath, FileMode.Create))
                    {
                        hapticsSpriteImg.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        stream.Close(); //added close to make sure the resourses are released. Still the issue is there
                    }
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        /**
         * Draws a single rectangular Button's footprint into the given graphic
         */
        private Graphics drawButtonHaptics(Button btn, Graphics graphic, Brush brush)
        {
            float width = (float)btn.RenderSize.Width;
            float height = (float)btn.RenderSize.Height;
            Point coords = btn.TransformToAncestor(this).Transform(new Point());
            float x = (float)coords.X;
            float y = (float)coords.Y;

            graphic.FillRectangle(brush, x, y, width, height);
            //graphic.Dispose();

            return graphic;
        }


        /**
         * Draws a slider footprint into the given graphic with space in the middle.
         */
        private Graphics drawSliderHaptics(Slider sldr, Graphics existingImage, Brush brush, float minboxWidth, float gapSize, float boxIncrement)
        {
            if (existingImage is null)
            {
                throw new ArgumentNullException(nameof(existingImage));
            }

            if (sldr is null)
            {
                throw new ArgumentNullException(nameof(sldr));
            }
            // Get the dimensions of the HTML element
            var width = (float)sldr.RenderSize.Width;
            var height = (float)sldr.RenderSize.Height;
            Point coords = sldr.TransformToAncestor(this).Transform(new Point());
            float sliderX = (float)coords.X;
            float sliderY = (float)coords.Y;

            float boxWidth = minboxWidth;
            float startX = sliderX;
            float prevX = startX;
            float sliderEndX = sliderX + width;

            //existingImage.FillRectangle(new SolidBrush(System.Drawing.Color.Yellow), sliderX, sliderY, width, height);

            // drawing rectangles until out of space
            while (startX < sliderEndX)
            {
                prevX = startX;
                existingImage.FillRectangle(brush, startX, sliderY, boxWidth, height);
                boxWidth = (float) (boxWidth * boxIncrement);
                startX = startX + boxWidth + gapSize;
            }

            // redrawing the last rectangle so it reaches the right end of the slider
            existingImage.FillRectangle(brush, prevX, sliderY, sliderEndX-prevX, height);
            existingImage.Dispose();


            return existingImage;
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

            // for some reason whether or not this line is here does not matter, the sprite
            // always uses the image that already exists in the file directory when the program boots up

            //creating the file
            //File path
            string path = @"..\Assets\appHapticSprite.png";

            //check if the file exist
            if (File.Exists(path))
            {
                File.Delete(path);                
            }
            //create a new bitmap with white background
            var bmp = new Bitmap(1200, 800);
            using(var g= Graphics.FromImage(bmp))
            {
                g.Clear(System.Drawing.Color.White);
                g.Dispose();
            }

            //save the bitmap as png
            bmp.Save(path, ImageFormat.Png);

            //dispose the bitmp object
            bmp.Dispose();
            

            using (var stream = new FileStream(path, FileMode.Open))
            {                
                var uri = new Uri(stream.Name);
                stream.Close();
                var mySprite = PNGToTanvasTouch.CreateSpriteFromPNG(uri);
                // To combat random sprite offset, setting coordinates
                mySprite.X = 350;
                myView.AddSprite(mySprite);
            }
        }


        //follwoing buttons are to control the element layout of the application. Make them hide or visible
        private void Button_Click_Slider(object sender, RoutedEventArgs e)
        {
            button_status = 1;
        }

        private void Button_Click_Button(object sender, RoutedEventArgs e)
        {
            button_status = 2;
        }

        private void volume_control_Click(object sender, RoutedEventArgs e)
        {
            if (button_status == 1)
            {
                vup.Visibility = Visibility.Collapsed;
                vdown.Visibility = Visibility.Collapsed;
                slider.Visibility = Visibility.Visible;
                volume.Visibility = Visibility.Visible;
                volume_b.Visibility = Visibility.Collapsed;
                button_status = 0;
            }
            else if (button_status == 2)
            {
                slider.Visibility = Visibility.Collapsed;
                vup.Visibility = Visibility.Visible;
                vdown.Visibility = Visibility.Visible;
                volume.Visibility = Visibility.Collapsed;
                volume_b.Visibility = Visibility.Visible;
                button_status = 0;
            }
            else
            {
                slider.Visibility = Visibility.Collapsed;
                vup.Visibility = Visibility.Collapsed;
                vdown.Visibility = Visibility.Collapsed;
                volume.Visibility = Visibility.Collapsed;
                volume_b.Visibility = Visibility.Collapsed;
            }
        }
    }
}
