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

        public double[] Weights { get; set; }

        public int TrainingId = 0;


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
            TrainingId %= 50; ;

            string label = (string)Labels[TrainingId].Content;

            for (int i = 0; i < Weights.Length; i++)
            {
                if (i < Weights.Length - 1)
                {
                    Weights[i] += (TrueValues[TrainingId] - Guess(label)) * label[i] * 0.1;
                }
                else
                {
                    Weights[i] += (TrueValues[TrainingId] - Guess(label)) * 0.1;
                }
            }

            TrainingId++;

            Color();
        }

        public void Color()
        {
            for (int i = 0; i < 50; i++)
            {
                string label = (string)Labels[i].Content;

                if (CalculateWeight(label) >= 0)
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
