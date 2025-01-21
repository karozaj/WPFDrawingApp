using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    internal class PointDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 2;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = thickness;
            ellipse.Height = thickness;
            Canvas.SetTop(ellipse, e.GetPosition(canvas).Y - ellipse.Height / 2);
            Canvas.SetLeft(ellipse, e.GetPosition(canvas).X - ellipse.Width / 2);
            ellipse.Fill = new SolidColorBrush(color);
            canvas.Children.Add(ellipse);
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
