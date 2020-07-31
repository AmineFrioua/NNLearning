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

        private readonly int _width, _height;
        private double _a=0.5, _b=0.96;

        public ShapesGenerator(int width, int height)
        {
            _width = width;
            _height = height;
            MyLine = new Line();
            MyEllipse = new Ellipse();
        }

        public void SetLineFunction (double a, double b)
        {
            _a = a;
            _b = b;
        }

        public double LineOrd(double x)
        {
            return _a * x + _b;
        }
        
        public void DrawLine(Canvas canvas )
        {
            MyLine.X1 = 0;
            MyLine.Y1 = LineOrd(0);
            MyLine.X2 = _width;
            MyLine.Y2 = LineOrd(_width);
            MyLine.Stroke = Brushes.HotPink;
            MyLine.StrokeThickness = 2;

            canvas.Children.Add(MyLine);
        }
        
    }
}
