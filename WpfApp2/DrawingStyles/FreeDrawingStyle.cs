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

namespace WpfApp2
{
    internal class FreeDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 1;
        Point currentPoint = new Point();

        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                line.Stroke = new SolidColorBrush(color);
                line.StrokeThickness = thickness;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(canvas).X;
                line.Y2 = e.GetPosition(canvas).Y;
                currentPoint = e.GetPosition(canvas);

                canvas.Children.Add(line);
            }
            else
            {
                currentPoint=e.GetPosition(canvas);
            }
        }
        public void MouseDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas)
        {
            return;
        }

        public void ExitDrawingStyle()
        {
            return;
        }
    }
}
