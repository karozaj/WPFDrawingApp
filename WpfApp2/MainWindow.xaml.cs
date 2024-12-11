using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        Color selectedColor = Color.FromRgb(255, 0, 0);
        Rectangle pickedLineP3;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void paintSurface_MouseMove(object sender, MouseEventArgs e)
        {
            drawingManager.MouseMoveAction(sender, e, this, paintSurface, selectedColor);
        }

        private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            drawingManager.MouseLeftButtonDownAction(sender,e,this,paintSurface,selectedColor);

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
            drawingManager.MouseRightButtonDownAction(sender, e, this, paintSurface, selectedColor);
        }

        private void colorPicker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colorPickerWindow == null)
            {
                colorPickerWindow = new ColorPickerWindow(selectedColor);
                colorPickerWindow.Show();
            }
        }

    }
}
