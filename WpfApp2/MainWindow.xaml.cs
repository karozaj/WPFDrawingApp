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
    public partial class MainWindow : Window
    {
        private int drawstyle = 1;
        public int drawStyle
        { 
            get { return drawstyle; }
            set {
                drawstyle = value;
                isFirstLinePointSet = false;
                linePointPicked = false;
                paintSurface.Children.Remove(pickedLineP1);
                paintSurface.Children.Remove(pickedLineP2);
            }
        }

        Point currentPoint=new Point();
        Line currentLine;
        bool isFirstLinePointSet = false;

        bool linePointPicked = false;
        bool linePoint1Picked = false;
        Line pickedLine;
        Ellipse pickedLineP1;
        Ellipse pickedLineP2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {//draw freely
            drawStyle = 1;
            isFirstLinePointSet = false;
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {//draw point
            drawStyle = 2;
            isFirstLinePointSet = false;
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {//draw line
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
            else if (drawStyle == 41)
            {
                if (linePoint1Picked == true)
                {
                    pickedLine.X1 = e.GetPosition(this).X;
                    pickedLine.Y1 = e.GetPosition(this).Y;
                    linePointPicked = false;
                }
                else
                {
                    pickedLine.X2 = e.GetPosition(this).X;
                    pickedLine.Y2 = e.GetPosition(this).Y;
                    linePointPicked = false;
                }


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
                    currentLine.MouseDown += delegate (object mouseSender, MouseButtonEventArgs mouseE)
                    {
                        if (drawStyle == 4)//if drawStyle is line edit, select line
                        {
                            paintSurface.Children.Remove(pickedLineP1);
                            paintSurface.Children.Remove(pickedLineP2);
                            pickedLine = (Line)mouseSender;

                            pickedLineP1 = new Ellipse();

                            pickedLineP1.Width = 6;
                            pickedLineP1.Height = 6;
                            Canvas.SetTop(pickedLineP1, pickedLine.Y1 - pickedLineP1.Height / 2);
                            Canvas.SetLeft(pickedLineP1, pickedLine.X1 - pickedLineP1.Width / 2);
                            pickedLineP1.Fill = new SolidColorBrush(Colors.Red);
                            pickedLineP1.MouseDown += pickedLinePointSelected;
                            paintSurface.Children.Add(pickedLineP1);

                            pickedLineP2 = new Ellipse();

                            pickedLineP2.Width = 6;
                            pickedLineP2.Height = 6;
                            Canvas.SetTop(pickedLineP2, pickedLine.Y2 - pickedLineP2.Height / 2);
                            Canvas.SetLeft(pickedLineP2, pickedLine.X2 - pickedLineP2.Width / 2);
                            pickedLineP2.Fill = new SolidColorBrush(Colors.Red);
                            pickedLineP2.MouseDown += pickedLinePointSelected;
                            paintSurface.Children.Add(pickedLineP2);

                        }
                    };

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
            {//ellipse
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
            {//circle
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
            else if (drawStyle == 15)
            {//triangle
                Polygon triangle = new Polygon();
                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;
                double polySize = 20;

                Point point1 = new Point(mouseX - polySize, mouseY + polySize);
                Point point2 = new Point(mouseX + polySize, mouseY + polySize);
                Point point3 = new Point(mouseX, mouseY - polySize);

                PointCollection polyPoints = new PointCollection();
                polyPoints.Add(point1);
                polyPoints.Add(point2);
                polyPoints.Add(point3);
                triangle.Points = polyPoints;

                Brush brushColor = new SolidColorBrush(Colors.ForestGreen);
                triangle.Stroke = brushColor;
                paintSurface.Children.Add(triangle);
            }
            else if (drawStyle == 16)
            {//plus
                Polygon plus = new Polygon();
                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;
                double polySize = 20;

                Point point1 = new Point(mouseX - polySize, mouseY + polySize);
                Point point2 = new Point(mouseX + polySize, mouseY + polySize);
                Point point3 = new Point(mouseX + polySize, mouseY - polySize);
                Point point4 = new Point(mouseX - polySize, mouseY - polySize);

                Point point5 = new Point(mouseX - polySize, mouseY -2*polySize);
                Point point6 = new Point(mouseX + polySize, mouseY -2* polySize);

                Point point7 = new Point(mouseX - polySize, mouseY +2* polySize);
                Point point8 = new Point(mouseX + polySize, mouseY +2* polySize);

                Point point9 = new Point(mouseX + 2 * polySize, mouseY + polySize);
                Point point10 = new Point(mouseX + 2* polySize, mouseY - polySize);

                Point point11 = new Point(mouseX - 2 * polySize, mouseY + polySize);
                Point point12 = new Point(mouseX - 2*polySize, mouseY - polySize);

                PointCollection polyPoints = new PointCollection();
                polyPoints.Add(point4);
                polyPoints.Add(point5);
                polyPoints.Add(point6);
                polyPoints.Add(point3);
                polyPoints.Add(point10);
                polyPoints.Add(point9);
                polyPoints.Add(point2);
                polyPoints.Add(point8);
                polyPoints.Add(point7);
                polyPoints.Add(point1);
                polyPoints.Add(point11);
                polyPoints.Add(point12);

                plus.Points = polyPoints;

                Brush brushColor = new SolidColorBrush(Colors.Olive);
                plus.Stroke = brushColor;
                paintSurface.Children.Add(plus);
            }
            else if (drawStyle == 17)
            {//star
                Polygon star = new Polygon();
                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;
                double polySize = 40;

                Point point1 = new Point(mouseX+polySize*Math.Cos(2*Math.PI*0/5+Math.PI/2), mouseY + polySize*Math.Sin(2 * Math.PI*0 / 5 + Math.PI / 2));
                Point point2 = new Point(mouseX + polySize/2 * Math.Cos(2 * Math.PI * 0 / 5 + 7*Math.PI / 10), mouseY + polySize/2 * Math.Sin(2 * Math.PI * 0 / 5 + 7 * Math.PI / 10));
                Point point3 = new Point(mouseX + polySize * Math.Cos(2 * Math.PI * 1 / 5 + Math.PI / 2), mouseY + polySize * Math.Sin(2 * Math.PI * 1 / 5 + Math.PI / 2));
                Point point4 = new Point(mouseX + polySize / 2 * Math.Cos(2 * Math.PI * 1 / 5 + 7 * Math.PI / 10), mouseY + polySize / 2 * Math.Sin(2 * Math.PI * 1 / 5 + 7 * Math.PI / 10));
                Point point5 = new Point(mouseX + polySize * Math.Cos(2 * Math.PI * 2 / 5 + Math.PI / 2), mouseY + polySize * Math.Sin(2 * Math.PI * 2 / 5 + Math.PI / 2));
                Point point6 = new Point(mouseX + polySize / 2 * Math.Cos(2 * Math.PI * 2 / 5 + 7 * Math.PI / 10), mouseY + polySize / 2 * Math.Sin(2 * Math.PI * 2 / 5 + 7 * Math.PI / 10));
                Point point7 = new Point(mouseX + polySize * Math.Cos(2 * Math.PI * 3 / 5 + Math.PI / 2), mouseY + polySize * Math.Sin(2 * Math.PI * 3 / 5 + Math.PI / 2));
                Point point8 = new Point(mouseX + polySize / 2 * Math.Cos(2 * Math.PI * 3 / 5 + 7 * Math.PI / 10), mouseY + polySize / 2 * Math.Sin(2 * Math.PI * 3 / 5 + 7 * Math.PI / 10));
                Point point9 = new Point(mouseX + polySize * Math.Cos(2 * Math.PI * 4 / 5 + Math.PI / 2), mouseY + polySize * Math.Sin(2 * Math.PI * 4 / 5 + Math.PI / 2));
                Point point10 = new Point(mouseX + polySize / 2 * Math.Cos(2 * Math.PI * 4 / 5 + 7 * Math.PI / 10), mouseY + polySize / 2 * Math.Sin(2 * Math.PI * 4 / 5 + 7 * Math.PI / 10));

                PointCollection polyPoints = new PointCollection();
                polyPoints.Add(point1);
                polyPoints.Add(point2);
                polyPoints.Add(point3);
                polyPoints.Add(point4);
                polyPoints.Add(point5);
                polyPoints.Add(point6);
                polyPoints.Add(point7);
                polyPoints.Add(point8);
                polyPoints.Add(point9);
                polyPoints.Add(point10);
                star.Points = polyPoints;

                Brush brushColor = new SolidColorBrush(Colors.DarkGoldenrod);
                star.Stroke = brushColor;
                paintSurface.Children.Add(star);
            }
            else if (drawStyle == 18)
            {//parallelogram
                Polygon parallelogram = new Polygon();
                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;
                double polySize = 20;

                Point point1 = new Point(mouseX - 2*polySize, mouseY + polySize);
                Point point2 = new Point(mouseX + polySize, mouseY + polySize);
                Point point3 = new Point(mouseX + 2*polySize, mouseY - polySize);
                Point point4 = new Point(mouseX - polySize, mouseY - polySize);

                PointCollection polyPoints = new PointCollection();
                polyPoints.Add(point1);
                polyPoints.Add(point2);
                polyPoints.Add(point3);
                polyPoints.Add(point4);
                parallelogram.Points = polyPoints;

                Brush brushColor = new SolidColorBrush(Colors.Olive);
                parallelogram.Stroke = brushColor;
                paintSurface.Children.Add(parallelogram);
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
        {//draw line
            drawStyle = 3;
        }

        private void editSegment_Click(object sender, RoutedEventArgs e)
        {//edit line
            drawStyle = 4;
            isFirstLinePointSet = false;
        }

        private void drawRectangle_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 11;
            isFirstLinePointSet = false;
        }

        private void drawPolygon_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 12;
            isFirstLinePointSet = false;
        }

        private void drawEllipse_Click(object sender, RoutedEventArgs e)
        {
            drawStyle=13;
            isFirstLinePointSet = false;
        }

        private void drawCircle_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 14;
            isFirstLinePointSet = false;
        }

        private void drawCustomShape1_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 15;
            isFirstLinePointSet = false;
        }

        private void drawCustomShape2_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 16;
            isFirstLinePointSet = false;
        }

        private void drawCustomShape3_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 17;
            isFirstLinePointSet = false;
        }

        private void drawCustomShape4_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 18;
            isFirstLinePointSet = false;
        }

        private void pickedLinePointSelected(object sender, MouseButtonEventArgs e)
        {
            linePointPicked = true;
            if (Object.ReferenceEquals(pickedLineP1, (sender as Ellipse)))
            {
                linePoint1Picked= true;
                drawStyle = 41;
            }
            else if (Object.ReferenceEquals(pickedLineP2, (sender as Ellipse)))
            {
                linePoint1Picked = false;
                drawStyle = 41;
            }
            //pickedLine.Stroke = new SolidColorBrush(Colors.Red);

            paintSurface.Children.Remove(pickedLineP1);
            paintSurface.Children.Remove(pickedLineP2);

        }

        private void paintSurface_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (drawStyle == 41)
            {
                drawStyle = 4;
                paintSurface.Children.Remove(pickedLineP1);
                paintSurface.Children.Remove(pickedLineP2);
            }
        }
    }
}
