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

        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            polyline = null;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            double mouseX = e.GetPosition(canvas).X;
            double mouseY = e.GetPosition(canvas).Y;

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
            polyline.StrokeThickness = thickness;

        }
        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
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
