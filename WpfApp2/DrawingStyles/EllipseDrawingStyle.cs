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
    internal class EllipseDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 13;
        private Ellipse circ;
        private Point topLeftPos;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            circ = new Ellipse();
            circ.Height = 5;
            circ.Width = 5;
            topLeftPos = e.GetPosition(canvas);
            Canvas.SetTop(circ, e.GetPosition(canvas).Y);
            Canvas.SetLeft(circ, e.GetPosition(canvas).X);

            Brush brushColor = new SolidColorBrush(color);
            circ.StrokeThickness = thickness;

            circ.Stroke = brushColor;
            canvas.Children.Add(circ);
        }
        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (circ != null)
                {
                    double newH = topLeftPos.Y - e.GetPosition(canvas).Y;
                    double newW = topLeftPos.X - e.GetPosition(canvas).X;
                    circ.Height = Math.Abs(newH);
                    circ.Width = Math.Abs(newW);
                    if (newW >= 0)
                    {
                        Canvas.SetLeft(circ, e.GetPosition(canvas).X);
                    }
                    else
                    {
                        Canvas.SetRight(circ, e.GetPosition(canvas).X);
                    }
                    if (newH >= 0)
                    {
                        Canvas.SetTop(circ, e.GetPosition(canvas).Y);
                    }
                    else
                    {
                        Canvas.SetBottom(circ, e.GetPosition(canvas).Y);
                    }
                }
            }
            else
            {
                circ = null;
            }
        }
        public void MouseDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas)
        {
            return;
        }
        public void ExitDrawingStyle()
        {
            circ = null;
            return;
        }
    }
}
