using System;

namespace P31E01
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDele myDele1 = new MyDele(M1);
            myDele1 += M2;
            myDele1.Invoke();

            MyDele<int> myDeleAdd = new MyDele<int>(Add);
            int res1 = myDeleAdd(101, 202);
            Console.WriteLine(res1);
            MyDele<double> myDeleMul = new MyDele<double>(Mul);
            double res2 = myDeleMul(101, 202);
            Console.WriteLine(res2);
            Console.WriteLine(myDeleAdd.GetType().IsClass);

            // 使用系统声明好的委托 Action, Func
            Action action1 = new Action(M1);
            action1();
            Action<String> action2 = new Action<string>(SayHello);
            action2("hhee");

            Func<int, int, int> func1 = new Func<int, int, int>(Add);
            var res3 = func1(100,2);
            Console.WriteLine(res3);

            // lambda 表达式 （匿名方法， Inline方法）
            //Func<int, int, int> func3 = new Func<int, int, int>((int a, int b) => {return a + b; });
            Func<int, int, int> func3 = (a, b) => {return a + b; };
            res3 = func3(11, 22);
            Console.WriteLine(res3);
            DoSomeCalc<int>((int a, int b) => { return a * b; }, 10, 20);

            // LINQ : .NET Language Integrated Query


        }

        static void M1()
        {
            Console.WriteLine("M1 is called!");
        }

        static void M2()
        {
            Console.WriteLine("M2 is called!");
        }

        static void SayHello(string s)
        {
            Console.WriteLine($"{s} is called!");
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Mul (double a, double b)
        {
            return a * b;
        }

        static void DoSomeCalc<T>(Func<T, T, T>func, T x, T y)
        {
            T res = func(x, y);
            Console.WriteLine(res);
        }
    }

    delegate void MyDele();

    delegate T MyDele<T>(T a, T b);
}
