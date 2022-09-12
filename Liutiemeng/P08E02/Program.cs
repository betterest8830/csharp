using System;

namespace P08E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double result = Calculator.GetConeVolume(100, 20);
        }
    }

    class Calculator
    {
        public static double GetCircleArea(double r)
        {
            return Math.PI * r * r;
        }

        public static double GetCylinderVolume(double r, double h)
        {
            return GetCircleArea(r) * h;
        }

        public static double GetConeVolume(double r, double h)
        {
            return GetCylinderVolume(r, h) / 3;
        }
    }
}
