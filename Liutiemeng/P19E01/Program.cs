using System;

namespace P19E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Calculator calculator = new Calculator();
            calculator.Report();// 直接调用
            Action action = new Action(calculator.Report);
            action(); // 间接调用

            Func<int, int, int> func1 = new Func<int, int, int>(calculator.Add);
            Func<int, int, int> func2 = new Func<int, int, int>(calculator.Sub);
            int x = 100, y = 200, z = 0;
            z = func1(x, y);
            z = func2(x, y);

        }

        class Calculator
        {
            public void Report()
            {
                Console.WriteLine("I have 3 methods.");
            }

            public int Add(int a, int b)
            {
                return a + b;
            }

            public int Sub(int a, int b)
            {
                return a - b;
            }
        }
    }
}
