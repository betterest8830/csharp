using System;

namespace P05E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var x = 3;
            Console.WriteLine(x.GetType().Name);
            Print1(3);
            Print1(3);
            ResolveHannuota(3, "A", "B", "C");
        }

        public static void Print1(int x)
        {
            for (int i = x; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }

        public static void Print2(int x)
        {
            if(x == 1)
            {
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine(x);
                Print2(x - 1);
            }
        }

        public static void ResolveHannuota(int n, string origin, string temp, string destination)
        {
            if(n == 1)
            {
                Move(origin, destination);
            }
            else
            {
                ResolveHannuota(n - 1, origin, destination, temp);
                Move(origin, destination);
                ResolveHannuota(n - 1, temp, origin, destination);
            }
        }

        public static void Move(string origin, string destination)
        {
            Console.WriteLine("Move the plate from " + origin + " to " + destination);

        }
    }
}
