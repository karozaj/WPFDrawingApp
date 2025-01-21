using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2.DrawingStyles
{
    internal class CircleDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 14;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            Ellipse circ = new Ellipse();
            circ.Height = 60;
            circ.Width = 60;
            Canvas.SetTop(circ, e.GetPosition(canvas).Y - circ.Height / 2);
            Canvas.SetLeft(circ, e.GetPosition(canvas).X - circ.Width / 2);

            Brush brushColor = new SolidColorBrush(color);
            circ.StrokeThickness = thickness;

            circ.Stroke = brushColor;
            canvas.Children.Add(circ);
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
