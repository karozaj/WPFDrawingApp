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
    /// 
    //draw styles:
    // 1-dowolne
    // 2-punkty
    // 3-linie
    // 4-edycja linii
    //
    // 11-kwadrat
    // 12- wielokat
    // 13-elipsa
    // 14-okrag
    // 15-trojkat
    // 16-plus
    // 17-gwiazda
    // 18-romb
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
            {//point
                Ellipse ellipse=new Ellipse();
                ellipse.Width = 6;
                ellipse.Height = 6;
                Canvas.SetTop(ellipse, e.GetPosition(this).Y - ellipse.Height / 2);
                Canvas.SetLeft(ellipse, e.GetPosition(this).X - ellipse.Width / 2);
                ellipse.Fill= SystemColors.WindowFrameBrush;
                paintSurface.Children.Add(ellipse);

            }
            else if(drawStyle==3)
            {//line
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
            else if(drawStyle==11)
            {//rectangle
                Rectangle rect= new Rectangle();
                rect.Width = 60;
                rect.Height = 60;

                Canvas.SetTop(rect, e.GetPosition(this).Y-rect.Height/2);
                Canvas.SetLeft(rect, e.GetPosition(this).X - rect.Width / 2);

                Brush brushColor = new SolidColorBrush(Colors.Green);

                rect.Stroke = brushColor;
                //rect.Fill = SystemColors.WindowFrameBrush;
                paintSurface.Children.Add(rect);
            }
            else if(drawStyle==12)
            {//polygon
                Polygon poly=new Polygon();
                double mouseX=e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;
                double polySize = 20;

                Point point1 = new Point(mouseX-polySize,mouseY+2*polySize);
                Point point2 = new Point(mouseX+polySize,mouseY+2*polySize);
                Point point3 = new Point(mouseX + 2 * polySize, mouseY + 0); ;
                Point point4=new Point(mouseX+polySize,mouseY-2*polySize);
                Point point5 = new Point(mouseX - polySize,mouseY-2*polySize);
                Point point6 = new Point(mouseX-2*polySize, mouseY+0);

                PointCollection polyPoints = new PointCollection();
                polyPoints.Add(point1);
                polyPoints.Add(point2);
                polyPoints.Add(point3);
                polyPoints.Add(point4);
                polyPoints.Add(point5);
                polyPoints.Add(point6);
                poly.Points=polyPoints;

                Brush brushColor = new SolidColorBrush(Colors.Magenta);
                poly.Stroke = brushColor;
                paintSurface.Children.Add(poly);
            }
            else if(drawStyle==13)
            {
                Ellipse elip = new Ellipse();
                elip.Height = 80;
                elip.Width= 50;
                Canvas.SetTop(elip, e.GetPosition(this).Y - elip.Height / 2);
                Canvas.SetLeft(elip, e.GetPosition(this).X - elip.Width / 2);

                Brush brushColor = new SolidColorBrush(Colors.DarkTurquoise);

                elip.Stroke = brushColor;
                //rect.Fill = SystemColors.WindowFrameBrush;
                paintSurface.Children.Add(elip);
            }
            else if (drawStyle == 14)
            {
                Ellipse circ = new Ellipse();
                circ.Height = 60;
                circ.Width = 60;
                Canvas.SetTop(circ, e.GetPosition(this).Y - circ.Height / 2);
                Canvas.SetLeft(circ, e.GetPosition(this).X - circ.Width / 2);

                Brush brushColor = new SolidColorBrush(Colors.OrangeRed);

                circ.Stroke = brushColor;
                //rect.Fill = SystemColors.WindowFrameBrush;
                paintSurface.Children.Add(circ);
            }
        }

        private void paintSurface_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(this);
            }
        }

        private void drawSegment_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 3;
        }

        private void editSegment_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 4;
        }

        private void drawRectangle_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 11;
        }

        private void drawPolygon_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 12;
        }

        private void drawEllipse_Click(object sender, RoutedEventArgs e)
        {
            drawStyle=13;
        }

        private void drawCircle_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 14;
        }

        private void drawCustomShape1_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 15;
        }

        private void drawCustomShape2_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 16;
        }

        private void drawCustomShape3_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 17;
        }

        private void drawCustomShape4_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 18;
        }
    }
}
