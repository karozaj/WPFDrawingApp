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
using System.Threading;

namespace WpfApp2.DrawingStyles
{
    internal class PolylineDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 19;
        Polyline polyline;

        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            polyline = null;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            double mouseX = e.GetPosition(window).X;
            double mouseY = e.GetPosition(window).Y;

            if (polyline == null)
            {
                polyline=new Polyline();
                canvas.Children.Add(polyline);
                Point startPoint = new Point(mouseX, mouseY);
                polyline.Points.Add(startPoint);
            }

            Point point=new Point(mouseX, mouseY);
            polyline.Points.Add(point);
            Brush brushColor = new SolidColorBrush(color);
            polyline.Stroke = brushColor;

        }
        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            return;
        }
        public void MouseDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas)
        {
            return;
        }
        public void ExitDrawingStyle()
        {
            polyline = null;
            return;
        }
    }
}
