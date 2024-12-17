using Emgu.CV;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    //draw styles:
    // 1-dowolne
    // 2-punkty
    // 3-linie
    // 4-edycja linii
    // 41-edycja punktu linii
    //
    // 11-kwadrat
    // 12- wielokat
    // 13-elipsa
    // 14-okrag
    // 15-trojkat
    // 16-plus
    // 17-gwiazda
    // 18-rownoleglobok
    // 19-krzywa lamana
    public partial class MainWindow : Window
    {
        DrawingManager drawingManager=new DrawingManager();
        ColorPickerWindow colorPickerWindow;
        OpenFileDialog openFileDialog;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void paintSurface_MouseMove(object sender, MouseEventArgs e)
        {
            drawingManager.MouseMoveAction(sender, e, this, paintSurface);
        }

        private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            drawingManager.MouseLeftButtonDownAction(sender,e,this,paintSurface);

        }

        private void paintSurface_MouseDown(object sender, MouseButtonEventArgs e)
        {
            drawingManager.MouseDownAction(sender, e, this, paintSurface);
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {//draw freely
            drawingManager.DrawingStyle = 1;
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {//draw point
            drawingManager.DrawingStyle = 2;
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {//draw line
            //drawStyle = 3;
            drawingManager.DrawingStyle = 3;
        }


        private void drawSegment_Click(object sender, RoutedEventArgs e)
        {//draw line
            drawingManager.DrawingStyle = 3;
        }

        private void editSegment_Click(object sender, RoutedEventArgs e)
        {//edit line
            drawingManager.DrawingStyle = 4;
            //drawStyle = 4;
            //isFirstLinePointSet = false;
        }

        private void drawRectangle_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 11;
        }

        private void drawPolygon_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 12;
        }

        private void drawEllipse_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 13;
        }

        private void drawCircle_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 14;
        }

        private void drawCustomShape1_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 15;
        }

        private void drawCustomShape2_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 16;
        }

        private void drawCustomShape3_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 17;
        }

        private void drawCustomShape4_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 18;
        }

        private void drawPolyLine_Click(object sender, RoutedEventArgs e)
        {
            drawingManager.DrawingStyle = 19;
        }


        private void paintSurface_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            drawingManager.MouseRightButtonDownAction(sender, e, this, paintSurface);
        }

        private void colorPicker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowCollection windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window.Equals(colorPickerWindow))
                    return;
            }
            colorPickerWindow = new ColorPickerWindow(drawingManager.CurrentColor, switchColor);
            colorPickerWindow.Show();
        }

        private void switchColor(Color newColor)
        {
            drawingManager.CurrentColor = newColor;
            colorPicker.Fill=new SolidColorBrush(newColor);
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog=new OpenFileDialog();
            openFileDialog.Filter= "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            openFileDialog.RestoreDirectory= true;
            if(openFileDialog.ShowDialog(this)==true)
            {
                // Create the image element.
                Image simpleImage = new Image();
                simpleImage.Width = 200;
                simpleImage.Margin = new Thickness(5);

                // Create source.
                BitmapImage bi = new BitmapImage();
                using(var fileStream=File.OpenRead(openFileDialog.FileName))
                {
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = fileStream;

                    bi.EndInit();
                }

                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                //bi.BeginInit();
                //bi.UriSource = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                //bi.EndInit();
                //// Set the image source.
                //simpleImage.Source = bi;

                paintSurface.Width = bi.Width;
                paintSurface.Height = bi.Height;
                //paintSurface.Children.Add(simpleImage);
                ////Canvas.SetTop(simpleImage, 100);
                ////Canvas.SetLeft(simpleImage, 100);
                paintSurface.Background = new ImageBrush(bi);
            }
        }
    }
}
