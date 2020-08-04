using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
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

        public double[] Weights { get; set; }

        public int TrainingId = 0;

        public int ErrorId = 0;


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

                string test = (string)Labels[j].Content;

                if (Regex.IsMatch(test, @"(\w)\1"))
                {
                    TrueValues[j] = 1;
                    Labels[j].Foreground = Brushes.Blue;
                }
                else
                {
                    TrueValues[j] = -1;
                    Labels[j].Foreground = Brushes.Red;
                }
            }
        }

        public void Train()
        {
            for (int i = 0; i < 50; i++)
            {
                string label = (string)Labels[i].Content;

                int Error = TrueValues[i] - Guess(label);

                if (Error != 0)
                {
                    for (int j = 0; j < Weights.Length; j++)
                    {
                        if (j < Weights.Length - 1)
                        {
                            Weights[j] += Error * label[j] * 0.5;
                        }
                        else
                        {
                            Weights[j] += Error * 0.5;
                        }
                    }
                    ErrorId ++;
                }
            }

            //ErrorId++;
            //TrainingId++;

            Color();
        }

        public void Color()
        {
            for (int i = 0; i < 50; i++)
            {
                string label = (string)Labels[i].Content;

                if (Guess(label) > 0)
                {
                    Labels[i].Background = Brushes.Green;
                }
                else
                {
                    Labels[i].Background = Brushes.LightPink;
                }
            }

        }

        private double CalculateWeight(string label)
        {
            double total = Weights[0] * label[0] + Weights[1] * label[1] + Weights[2] * label[2] + Weights[3] * label[3] + Weights[4];

            return total;
        }

        private int Guess(string label)
        {
            if (CalculateWeight(label) >= 0) return 1;
            else return -1;
        }
    }
}
