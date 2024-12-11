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
        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            Ellipse elip = new Ellipse();
            elip.Height = 80;
            elip.Width = 50;
            Canvas.SetTop(elip, e.GetPosition(window).Y - elip.Height / 2);
            Canvas.SetLeft(elip, e.GetPosition(window).X - elip.Width / 2);

            Brush brushColor = new SolidColorBrush(color);

            elip.Stroke = brushColor;
            canvas.Children.Add(elip);
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
