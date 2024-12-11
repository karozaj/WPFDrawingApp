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
    internal class SquareDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 11;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            Rectangle rect = new Rectangle();
            rect.Width = 60;
            rect.Height = 60;

            Canvas.SetTop(rect, e.GetPosition(window).Y - rect.Height / 2);
            Canvas.SetLeft(rect, e.GetPosition(window).X - rect.Width / 2);

            Brush brushColor = new SolidColorBrush(color);

            rect.Stroke = brushColor;
            canvas.Children.Add(rect);
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
