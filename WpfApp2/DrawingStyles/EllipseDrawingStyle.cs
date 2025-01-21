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
    internal class EllipseDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 13;
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            Ellipse elip = new Ellipse();
            elip.Height = 80;
            elip.Width = 50;
            Canvas.SetTop(elip, e.GetPosition(canvas).Y - elip.Height / 2);
            Canvas.SetLeft(elip, e.GetPosition(canvas).X - elip.Width / 2);

            Brush brushColor = new SolidColorBrush(color);
            elip.StrokeThickness = thickness;

            elip.Stroke = brushColor;
            canvas.Children.Add(elip);
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
