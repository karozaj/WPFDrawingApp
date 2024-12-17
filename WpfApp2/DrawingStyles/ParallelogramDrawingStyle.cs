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
    internal class ParallelogramDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 18;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            Polygon parallelogram = new Polygon();
            double mouseX = e.GetPosition(canvas).X;
            double mouseY = e.GetPosition(canvas).Y;
            double polySize = 20;

            Point point1 = new Point(mouseX - 2 * polySize, mouseY + polySize);
            Point point2 = new Point(mouseX + polySize, mouseY + polySize);
            Point point3 = new Point(mouseX + 2 * polySize, mouseY - polySize);
            Point point4 = new Point(mouseX - polySize, mouseY - polySize);

            PointCollection polyPoints = new PointCollection();
            polyPoints.Add(point1);
            polyPoints.Add(point2);
            polyPoints.Add(point3);
            polyPoints.Add(point4);
            parallelogram.Points = polyPoints;

            Brush brushColor = new SolidColorBrush(color);
            parallelogram.Stroke = brushColor;
            canvas.Children.Add(parallelogram);
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
