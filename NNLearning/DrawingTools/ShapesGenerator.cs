using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NNLearning.DrawingTools
{
    public class ShapesGenerator
    {
        public Ellipse MyEllipse { get; set; }
        public Line MyLine { get; set; }

        private readonly int _width;
        public double A=0.5, B=0.96;

        public ShapesGenerator(int width)
        {
            _width = width;
            MyLine = new Line();
            MyEllipse = new Ellipse();
        }
        
        public void DrawLine(Canvas canvas,Brush color )
        {
            try
            {
                canvas.Children.Remove(MyLine);
            }
            catch 
            {
            }
            MyLine.X1 = 0;
            MyLine.Y1 = LinearMath.LineOrd(0,A,B);
            MyLine.X2 = _width;
            MyLine.Y2 = LinearMath.LineOrd(_width,A,B);
            MyLine.Stroke = color;
            MyLine.StrokeThickness = 2;

            canvas.Children.Add(MyLine);
        }
        
    }
}
