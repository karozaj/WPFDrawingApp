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
    internal class TriangleDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 15;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            Polygon triangle = new Polygon();
            double mouseX = e.GetPosition(canvas).X;
            double mouseY = e.GetPosition(canvas).Y;
            double polySize = 20;

            Point point1 = new Point(mouseX - polySize, mouseY + polySize);
            Point point2 = new Point(mouseX + polySize, mouseY + polySize);
            Point point3 = new Point(mouseX, mouseY - polySize);

            PointCollection polyPoints = new PointCollection();
            polyPoints.Add(point1);
            polyPoints.Add(point2);
            polyPoints.Add(point3);
            triangle.Points = polyPoints;

            Brush brushColor = new SolidColorBrush(color);
            triangle.Stroke = brushColor;
            triangle.StrokeThickness=thickness;
            canvas.Children.Add(triangle);
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
            return;
        }
    }
}
