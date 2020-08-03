using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PerceptorSecondExample
{
    public class PerceptorTwo
    {
        public List<Label> Labels { get; set; }

        public int[] TrueValues { get; set; }

        public double [] Weights { get; set; }


        private static readonly Random random = new Random();

        public PerceptorTwo(List<Label> labels)
        {
            Labels = labels;

            TrueValues = new int[Labels.Count];

            Weights = new double[5];

            for (int i = 0; i < 5; i++)
            {
                Weights[i] = random.NextDouble();
            }

            InitialCheck();
        }

        private void InitialCheck()
        {
            for (int j = 0; j < Labels.Count; j++)
            {
                Labels[j].Foreground = Brushes.Red;

                TrueValues[j] = -1;

                string test = (string)Labels[j].Content;

                for (int i = 0; i < 3; i++)
                {
                    if (test[i] == test[i + 1])
                    {
                        TrueValues[j] = 1;

                        Labels[j].Foreground = Brushes.Blue;
                    }
                }
            }
        }

        public void Train()
        {
            for (int j = 0; j < Labels.Count; j++)
            {
                int guess;

                string label = (string)Labels[j].Content;

                if (CalculateWeight(label) >= 0)
                {
                    guess = 1;
                    Labels[j].Background = Brushes.Green;
                }
                else
                {
                    guess = -1;
                    Labels[j].Background = Brushes.LightPink;
                }

                if (guess != TrueValues[j])
                {
                    for (int i = 0; i < Weights.Length; i++)
                    {
                        if (i < Weights.Length - 1)
                        {
                            Weights[i]+= (TrueValues[j] - guess) * label[i] * 0.1;
                        }
                        else
                        {
                            Weights[i] += (TrueValues[j] - guess) * 0.1;
                        }
                    }
                }
               
            }
        }

        private double CalculateWeight(string label)
        {
            double total = Weights[0] * label[0] + Weights[1] * label[1] + Weights[2] * label[2] + Weights[3] * label[3] + Weights[4];

            return total;
        }
    }
}
