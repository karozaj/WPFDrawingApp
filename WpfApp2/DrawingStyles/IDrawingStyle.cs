using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2
{
    internal interface IDrawingStyle
    {
        //interface for drawing styles 
        int styleID {  get; }
        void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color);
        void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color);
        void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas,Color color);
        void MouseDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas);
        void ExitDrawingStyle();
    }
}
