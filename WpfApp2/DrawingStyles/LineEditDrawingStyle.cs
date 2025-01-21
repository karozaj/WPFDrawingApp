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
    internal class LineEditDrawingStyle:IDrawingStyle
    {
        LineDrawingStyle lineDrawingStyle;
        public LineEditDrawingStyle(LineDrawingStyle lineDrawingStyle)
        {
            this.lineDrawingStyle = lineDrawingStyle;
        }

        public int styleID { get; } = 4;

        public void MouseRightButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            if (lineDrawingStyle.linePointPicked)
            {
                lineDrawingStyle.linePointPicked = false;
                lineDrawingStyle.linePoint1Picked = false;
                lineDrawingStyle.pickedLine = null;
            }
        }
        public void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            if (lineDrawingStyle.lineEditEnabled == false)
            {
                lineDrawingStyle.lineEditEnabled = true;
            }
        }

        public void MouseMoveAction(object sender, MouseEventArgs e, MainWindow window, Canvas canvas, Color color, int thickness)
        {
            if (lineDrawingStyle.linePointPicked)
            {
                if (lineDrawingStyle.linePoint1Picked == true)
                {
                    lineDrawingStyle.pickedLine.X1 = e.GetPosition(canvas).X;
                    lineDrawingStyle.pickedLine.Y1 = e.GetPosition(canvas).Y;
                }
                else
                {
                    lineDrawingStyle.pickedLine.X2 = e.GetPosition(canvas).X;
                    lineDrawingStyle.pickedLine.Y2 = e.GetPosition(canvas).Y;
                }
            }
        }
        public void MouseDownAction(object sender, MouseButtonEventArgs e, MainWindow window, Canvas canvas)
        {
            return;
        }
        public void ExitDrawingStyle()
        {
            if (lineDrawingStyle.pickedLineP1 != null && lineDrawingStyle.pickedLineP2 != null)
            {
                lineDrawingStyle.currentCanvas.Children.Remove(lineDrawingStyle.pickedLineP1);
                lineDrawingStyle.currentCanvas.Children.Remove(lineDrawingStyle.pickedLineP2);
            }

            lineDrawingStyle.linePointPicked = false;
            lineDrawingStyle.linePoint1Picked = false;
            lineDrawingStyle.pickedLine = null;
            lineDrawingStyle.lineEditEnabled = false;
        }
    }
}

