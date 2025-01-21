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
    internal class PolygonDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 12;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            Polygon poly = new Polygon();
            double mouseX = e.GetPosition(canvas).X;
            double mouseY = e.GetPosition(canvas).Y;
            double polySize = 20;

            Point point1 = new Point(mouseX - polySize, mouseY + 2 * polySize);
            Point point2 = new Point(mouseX + polySize, mouseY + 2 * polySize);
            Point point3 = new Point(mouseX + 2 * polySize, mouseY + 0); ;
            Point point4 = new Point(mouseX + polySize, mouseY - 2 * polySize);
            Point point5 = new Point(mouseX - polySize, mouseY - 2 * polySize);
            Point point6 = new Point(mouseX - 2 * polySize, mouseY + 0);

            PointCollection polyPoints = new PointCollection();
            polyPoints.Add(point1);
            polyPoints.Add(point2);
            polyPoints.Add(point3);
            polyPoints.Add(point4);
            polyPoints.Add(point5);
            polyPoints.Add(point6);
            poly.Points = polyPoints;

            Brush brushColor = new SolidColorBrush(color);
            poly.Stroke = brushColor;
            poly.StrokeThickness = thickness;
            canvas.Children.Add(poly);
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
