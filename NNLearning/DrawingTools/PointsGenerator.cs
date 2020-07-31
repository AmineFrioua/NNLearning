using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace NNLearning.DrawingTools
{
    public class PointsGenerator
    {
        public Point[] Points { get; set; }

        public Ellipse[] Ellipses { get; set; }

        private readonly Random _myRandomizer;

        public PointsGenerator(int numOfPoints, int canvasWidth, int canvasHeight, double a, double b)
        {
            _myRandomizer = new Random();

            Points = new Point[numOfPoints];

            Ellipses = new Ellipse[numOfPoints];

            for (int i = 0; i < numOfPoints; i++)
            {
                Points[i] = GeneratePoint(canvasWidth, canvasHeight);

                if (Points[i].Y >= LinearMath.LineOrd(Points[i].X, a, b))
                {
                    Ellipses[i] = new Ellipse()
                    {

                        Width = 10,
                        Height = 10,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1,
                        Fill = Brushes.Blue
                    };
                }
                else
                {
                    Ellipses[i] = new Ellipse()
                    {

                        Width = 10,
                        Height = 10,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1,
                        Fill = Brushes.White
                    };
                }

            }
        }

        private Point GeneratePoint(int width, int height)
        {
            return new Point(_myRandomizer.Next(0, width), _myRandomizer.Next(0, height));
        }

        public void DrawCircles(Canvas canvas)
        {
            for (int i = 0; i < 100; i++)
            {
                canvas.Children.Add(Ellipses[i]);

                Ellipses[i].SetValue(Canvas.LeftProperty, Points[i].X);

                Ellipses[i].SetValue(Canvas.TopProperty, Points[i].Y);
            }
        }

    }
}
