using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2.DrawingStyles
{
    internal class SquareDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 11;

        private Rectangle rect;
        private Point topLeftPos;

        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            rect = new Rectangle();
            rect.Width = 5;
            rect.Height = 5;

            topLeftPos = e.GetPosition(canvas);
            Canvas.SetTop(rect, e.GetPosition(canvas).Y);
            Canvas.SetLeft(rect, e.GetPosition(canvas).X);

            Brush brushColor = new SolidColorBrush(color);

            rect.Stroke = brushColor;
            rect.StrokeThickness = thickness;
            canvas.Children.Add(rect);
        }
        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (rect != null)
                {
                    double newH = topLeftPos.Y - e.GetPosition(canvas).Y;
                    double newW = topLeftPos.X - e.GetPosition(canvas).X;
                    rect.Height = Math.Abs(newH);
                    rect.Width = Math.Abs(newW);
                    if (newW >= 0)
                    { 
                        Canvas.SetLeft(rect, e.GetPosition(canvas).X);
                    }
                    else
                    {
                        Canvas.SetRight(rect, e.GetPosition(canvas).X);
                    }
                    if (newH >= 0)
                    {
                        Canvas.SetTop(rect, e.GetPosition(canvas).Y);
                    }
                    else
                    {
                        Canvas.SetBottom(rect, e.GetPosition(canvas).Y);
                    }
                }
            }
            else
            {
                rect = null;
            }

        }
        public void MouseDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas)
        {
            return;
        }
        public void ExitDrawingStyle()
        {
            rect = null;
            return;
        }
    }
}
