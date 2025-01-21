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
    internal class PlusDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 16;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            Polygon plus = new Polygon();
            double mouseX = e.GetPosition(canvas).X;
            double mouseY = e.GetPosition(canvas).Y;
            double polySize = 20;

            Point point1 = new Point(mouseX - polySize, mouseY + polySize);
            Point point2 = new Point(mouseX + polySize, mouseY + polySize);
            Point point3 = new Point(mouseX + polySize, mouseY - polySize);
            Point point4 = new Point(mouseX - polySize, mouseY - polySize);

            Point point5 = new Point(mouseX - polySize, mouseY - 2 * polySize);
            Point point6 = new Point(mouseX + polySize, mouseY - 2 * polySize);

            Point point7 = new Point(mouseX - polySize, mouseY + 2 * polySize);
            Point point8 = new Point(mouseX + polySize, mouseY + 2 * polySize);

            Point point9 = new Point(mouseX + 2 * polySize, mouseY + polySize);
            Point point10 = new Point(mouseX + 2 * polySize, mouseY - polySize);

            Point point11 = new Point(mouseX - 2 * polySize, mouseY + polySize);
            Point point12 = new Point(mouseX - 2 * polySize, mouseY - polySize);

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

            Brush brushColor = new SolidColorBrush(color);
            plus.Stroke = brushColor;
            plus.StrokeThickness = thickness;
            canvas.Children.Add(plus);
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
