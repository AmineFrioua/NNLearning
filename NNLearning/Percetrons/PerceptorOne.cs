
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
        public int[] TrueValues { get; set; }

        public double[] Weights { get; set; }

        public double LearningRate { get; set; }

        public Ellipse[] Ellipses { get; set; }

        public PerceptorOne(int nums, Point[] points, double a, double b)
        {
            TrueValues = new int[nums];

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

