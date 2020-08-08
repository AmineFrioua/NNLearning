using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNLibrary
{
    public static class MatrixMath
    {

        private static readonly Random _random= new Random();

        public delegate double MyFunction(double x);

        public static void Randomize(ref double[,] A)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = _random.NextDouble();
                }
            }
        }


        public static double[,] Add(double[,] A, double[,] B)
        {
            double[,] result = new double[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    result[i, j] = A[i, j] + B[i, j];
                }
            }

            return result;
        }

        public static double[,] Substract(double[,] A, double[,] B)
        {
            double[,] result = new double[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    result[i, j] = A[i, j] - B[i, j];
                }
            }

            return result;
        }

        public static double[,] ScalarMultiply(double[,] A, double a)
        {
            double[,] result = new double[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    result[i, j] = A[i, j] * a;
                }
            }

            return result;
        }

        public static double[,] Multiply(double[,] A, double[,] B)
        {
            double[,] result = new double[A.GetLength(0), B.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    double temp = 0;

                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        temp += A[i, k] * B[k, j];
                    }

                    result[i, j] = temp;
                }
            }
            return result;
        }


        public static double[,] Transpose(double[,] A)
        {
            double[,] result = new double[A.GetLength(1), A.GetLength(0)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    result[j, i] = A[i, j];

                }
            }

            return result;
        }

        public static double [,] Map(MyFunction func , double [,] A)
        {
            double[,] result = new double[A.GetLength(1), A.GetLength(0)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    result[j, i] = func(A[i, j]);

                }
            }

            return result;
        }

    }
}
