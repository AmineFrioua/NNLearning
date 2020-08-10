using NNLibrary;
using System;

namespace TestingFun
{
    class Program
    {
        //Brain Amine;
        static void Main()
        {
            Brain Amine = new Brain(new double[2] { 0, 1 }, 2, 1);




            Console.WriteLine("Hello World!");

            Console.WriteLine(Amine.FeedForward()); 
        }
    }
}
