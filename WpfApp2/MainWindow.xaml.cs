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

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int drawStyle = 1;
        Point currentPoint=new Point();
        Line currentLine;
        bool isFirstLinePointSet = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 1;
            isFirstLinePointSet = false;
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 2;
            isFirstLinePointSet = false;
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 3;
        }

        private void paintSurface_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton==MouseButtonState.Pressed && drawStyle==1)
            {
                Line line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1=currentPoint.X;
                line.Y1=currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint=e.GetPosition(this);

                paintSurface.Children.Add(line);

            }
        }

        private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(drawStyle==2)
            {
                Ellipse ellipse=new Ellipse();
                ellipse.Width = 6;
                ellipse.Height = 6;
                Canvas.SetTop(ellipse, e.GetPosition(this).Y - ellipse.Height / 2);
                Canvas.SetLeft(ellipse, e.GetPosition(this).X - ellipse.Width / 2);
                ellipse.Fill= SystemColors.WindowFrameBrush;
                paintSurface.Children.Add(ellipse);

            }
            else if(drawStyle==3)
            {
                if (isFirstLinePointSet == false)
                {
                    currentLine = new Line();
                    currentLine.Stroke = SystemColors.WindowFrameBrush;
                    currentLine.X1 = e.GetPosition(this).X;
                    currentLine.Y1 = e.GetPosition(this).Y;
                    isFirstLinePointSet = true;
                }
                else if(isFirstLinePointSet == true && currentLine!=null)
                {
                    currentLine.X2 = e.GetPosition(this).X;
                    currentLine.Y2 = e.GetPosition(this).Y;
                    paintSurface.Children.Add(currentLine);
                    isFirstLinePointSet = false;
                }
            }
        }

        private void paintSurface_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(this);
            }
        }
    }
}
