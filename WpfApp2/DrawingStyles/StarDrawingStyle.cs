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
    internal class StarDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 17;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            Polygon star = new Polygon();
            double mouseX = e.GetPosition(window).X;
            double mouseY = e.GetPosition(window).Y;
            double polySize = 40;

            Point point1 = new Point(mouseX + polySize * Math.Cos(2 * Math.PI * 0 / 5 + Math.PI / 2), mouseY + polySize * Math.Sin(2 * Math.PI * 0 / 5 + Math.PI / 2));
            Point point2 = new Point(mouseX + polySize / 2 * Math.Cos(2 * Math.PI * 0 / 5 + 7 * Math.PI / 10), mouseY + polySize / 2 * Math.Sin(2 * Math.PI * 0 / 5 + 7 * Math.PI / 10));
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

            Brush brushColor = new SolidColorBrush(color);
            star.Stroke = brushColor;
            canvas.Children.Add(star);
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
            return;
        }
    }
}
