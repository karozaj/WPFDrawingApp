using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace WpfApp2.DrawingStyles
{
    internal class LineDrawingStyle : IDrawingStyle
    {
        public int styleID { get; } = 3;
        Line currentLine;
        bool isFirstLinePointSet = false;
        public bool lineEditEnabled = false;

        public Canvas currentCanvas;
        public bool linePointPicked = false;
        public bool linePoint1Picked = false;
        public Line pickedLine;
        public Ellipse pickedLineP1;
        public Ellipse pickedLineP2;

        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            if (isFirstLinePointSet == true)
            {
                isFirstLinePointSet= false;
                currentLine= null;
            }
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            if(currentLine!=null)
            {
                canvas.Children.Remove(currentLine);
            }
            currentLine = new Line();
            currentLine.Stroke = new SolidColorBrush(color);
            currentLine.StrokeThickness = thickness;
            currentLine.X1 = e.GetPosition(canvas).X;
            currentLine.Y1 = e.GetPosition(canvas).Y;
            currentLine.X2 = e.GetPosition(canvas).X;
            currentLine.Y2 = e.GetPosition(canvas).Y;
            isFirstLinePointSet = true;
            canvas.Children.Add(currentLine);

            currentLine.MouseDown += delegate (object mouseSender, MouseButtonEventArgs mouseE)
            {
                if (lineEditEnabled && linePointPicked==false)
                {
                    canvas.Children.Remove(pickedLineP1);
                    canvas.Children.Remove(pickedLineP2);
                    pickedLine = (Line)mouseSender;

                    pickedLineP1 = new Ellipse();
                    pickedLineP1.Width = 6;
                    pickedLineP1.Height = 6;
                    Canvas.SetTop(pickedLineP1, pickedLine.Y1 - pickedLineP1.Height / 2);
                    Canvas.SetLeft(pickedLineP1, pickedLine.X1 - pickedLineP1.Width / 2);
                    pickedLineP1.MouseDown += pickedLinePointSelected;
                    pickedLineP1.Fill = new SolidColorBrush(Colors.Red);
                    canvas.Children.Add(pickedLineP1);

                    pickedLineP2 = new Ellipse();

                    pickedLineP2.Width = 6;
                    pickedLineP2.Height = 6;
                    Canvas.SetTop(pickedLineP2, pickedLine.Y2 - pickedLineP2.Height / 2);
                    Canvas.SetLeft(pickedLineP2, pickedLine.X2 - pickedLineP2.Width / 2);
                    pickedLineP2.MouseDown += pickedLinePointSelected;
                    pickedLineP2.Fill = new SolidColorBrush(Colors.Red);
                    canvas.Children.Add(pickedLineP2);
                }

            };


        }

        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            if(isFirstLinePointSet==true)
            {
                currentLine.X2 = e.GetPosition(canvas).X;
                currentLine.Y2 = e.GetPosition(canvas).Y;
            }
        }
        public void MouseDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas)
        {
            if(currentCanvas==null)
            {
                currentCanvas = canvas;
            }
        }
        public void ExitDrawingStyle()
        {
            if(isFirstLinePointSet==true)
            {
                currentCanvas.Children.Remove(currentLine);
                currentLine = null;
                isFirstLinePointSet = false;
            }
            return;
        }

        private void pickedLinePointSelected(object sender, MouseButtonEventArgs e)
        {
            if (lineEditEnabled == true && pickedLine != null)
            {
                linePointPicked = true;
                if (Object.ReferenceEquals(pickedLineP1, (sender as Ellipse)))
                {
                    linePoint1Picked = true;
                }
                else if (Object.ReferenceEquals(pickedLineP2, (sender as Ellipse)))
                {
                    linePoint1Picked = false;
                }
                if (currentCanvas != null)
                {
                    currentCanvas.Children.Remove(pickedLineP1);
                    currentCanvas.Children.Remove(pickedLineP2);
                }
            }

        }
    }
}
