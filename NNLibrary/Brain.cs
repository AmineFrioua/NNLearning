using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNLibrary
{
    public class Brain
    {
        public double[] Input { get; set; }

        public int HiddenLayers { get; set; }

        public int Output { get; set; }

        public double[,] WeightIH { get; set; }

        public double[,] WeightHO { get; set; }

        public double[,] BiasH { get; set; }

        public double[,] BiasO { get; set; }

        public Brain(double[] input, int hidden, int output)
        {
            Input = input;
            HiddenLayers = hidden;
            Output = output;

            WeightIH = new double[HiddenLayers, Input.Length];

            WeightHO = new double[Output, HiddenLayers];

            BiasH = new double[HiddenLayers, 1];

            BiasO = new double[Output, 1];

            MatrixMath.Randomize(WeightIH);

            MatrixMath.Randomize(WeightHO);

            MatrixMath.Randomize(BiasH);

            MatrixMath.Randomize(BiasO);
        }

        public double[] FeedForward()
        {
            double[,] inputs = MatrixMath.FromArray(Input);

            // get the hidden matrix 
            double[,] hiddenOne = MatrixMath.Multiply(WeightIH, inputs);

            double[,] hiddenTwo = MatrixMath.Add(hiddenOne, BiasH);

            //activation function 
            double[,] hidden = MatrixMath.Map(Sigmoid, hiddenTwo);

            double[,] output = MatrixMath.Multiply(WeightHO, hidden);

            output = MatrixMath.Add(output, BiasO);

            output = MatrixMath.Map(Sigmoid, output);

            return MatrixMath.ToArray(output);
        }

        public void Train(double [] input, double [] answers)
        {

        }

        /// <summary>
        /// Activation Function for Neural Network AKA Brain 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double Sigmoid(double x)
        {
            return 1 / (Math.Exp(-x) + 1);
        }

    }
}
