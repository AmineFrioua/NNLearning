
using NNLearning.DrawingTools;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NNLearning.Percetrons
{
    public class PerceptorOne
    {
        public ShapesGenerator Line;
        public int[] TrueValues { get; set; }

        public double[] Weights { get; set; }

        public double LearningRate { get; set; }

        public Ellipse[] Ellipses { get; set; }

        public PerceptorOne(int nums, int width,Point[] points, double a, double b)
        {
            TrueValues = new int[nums];

            Line = new ShapesGenerator(width);

            Ellipses = new Ellipse[nums];

            for (int i = 0; i < nums; i++)
            {

                if (points[i].Y > LinearMath.LineOrd(points[i].X, a, b))
                    TrueValues[i] = 1;
                else TrueValues[i] = -1;
            };

            Weights = new double[] { 0.1, 0.2, 0.3 };

            LearningRate = 0.1;
        }

        public void Train(Point[] points)
        {
            int i = 0;
            foreach (var point in points)
            {

                if (Guess(point, TrueValues[i]) != 0)
                {
                    Weights[0] += Guess(point, TrueValues[i]) * point.X * LearningRate;

                    Weights[1] += Guess(point, TrueValues[i]) * point.Y * LearningRate;

                    Weights[2] += Guess(point, TrueValues[i])  * LearningRate;
                }
                i++;
            }
        }

        public void Draw(Point[] points,Canvas canvas)
        {
            for (int i = 0; i < points.Length; i++)
            {
                canvas.Children.Remove(Ellipses[i]);

                if (points[i].X * Weights[0] + points[i].Y * Weights[1] + Weights[2] >= 0)
                {
                    Ellipses[i] = new Ellipse()
                    {
                        Width = 10,
                        Height = 10,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1,
                        Fill = Brushes.Green
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
                        Fill = Brushes.Red
                    };

                }
                Line.A = -Weights[0] / Weights[1];

                Line.B = -Weights[2] / Weights[1];

                Line.DrawLine(canvas, Brushes.Yellow);
                canvas.Children.Add(Ellipses[i]);

                Ellipses[i].SetValue(Canvas.LeftProperty, points[i].X);

                Ellipses[i].SetValue(Canvas.TopProperty, points[i].Y);
            }

        }

        private int Guess(Point point, int trueValue)
        {
            int guess;
            if (point.X * Weights[0] + point.Y * Weights[1] + Weights[2] >= 0)
            {
                 guess = 1;
            }
            else
            { guess = -1; }
            return trueValue - guess;
        }

    }
}

