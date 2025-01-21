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
    internal class EraserDrawingStyle:IDrawingStyle
    {
        public int styleID { get; } = 5;

        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            return;
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            var clickedElement = e.Source as FrameworkElement;
            if (clickedElement != null)
            {
                if (canvas.Children.Contains(clickedElement))
                {
                    canvas.Children.Remove(clickedElement);
                }

            }
        }
        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas, Color color)
        {
            if(System.Windows.Input.Mouse.LeftButton==MouseButtonState.Pressed)
            {
                var clickedElement = e.Source as FrameworkElement;
                if (clickedElement != null)
                {
                    if (canvas.Children.Contains(clickedElement))
                    {
                        canvas.Children.Remove(clickedElement);
                    }

                }
            }

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
