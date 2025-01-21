using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp2.DrawingStyles;

namespace WpfApp2
{
    internal class DrawingManager
    {
        static LineDrawingStyle lineDrawingStyle=new LineDrawingStyle();
        private Dictionary<int, IDrawingStyle> drawingStyles = new Dictionary<int, IDrawingStyle>
        {
            {1, new FreeDrawingStyle() },
            {2, new PointDrawingStyle() },
            {3, lineDrawingStyle },
            {4, new LineEditDrawingStyle(lineDrawingStyle) },
            {5, new EraserDrawingStyle() },
            {11,new SquareDrawingStyle() },
            {12,new PolygonDrawingStyle() },
            {13,new EllipseDrawingStyle() },
            {14, new CircleDrawingStyle() },
            {15, new TriangleDrawingStyle() },
            {16, new PlusDrawingStyle() },
            {17, new StarDrawingStyle() },
            {18, new ParallelogramDrawingStyle() },
            {19, new PolylineDrawingStyle() },
        };

        private IDrawingStyle currentDrawingStyle = new FreeDrawingStyle();

        private int drawingStyle=1;
        public int DrawingStyle
        {  
            get { return drawingStyle; } 
            set 
            {
                drawingStyle = value;
                currentDrawingStyle.ExitDrawingStyle();
                currentDrawingStyle = drawingStyles[drawingStyle];
            }
        }

        private Color currentColor = Colors.Red;
        public Color CurrentColor
        {
            get { return currentColor; }
            set
            {
                currentColor = value;
            }
        }

        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas )
        {
            currentDrawingStyle.MouseRightButtonDownAction(sender, e, window, canvas, CurrentColor);
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas )
        {
            currentDrawingStyle.MouseLeftButtonDownAction(sender, e, window, canvas, CurrentColor);
        }
        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas)
        {
            currentDrawingStyle.MouseMoveAction(sender, e, window, canvas, CurrentColor);
        }
        public void MouseDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas)
        {
            currentDrawingStyle.MouseDownAction(sender, e, window, canvas);
        }

    }
}
