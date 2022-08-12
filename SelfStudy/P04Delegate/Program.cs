using System;

namespace P04Delegate
{
   
    class Program
    {
        static void Main(string[] args)
        {

            NumberChanger nc1 = new NumberChanger(Delegate1.AddNum);
            NumberChanger nc2 = new NumberChanger(Delegate1.MultNum);
            nc1(25);
            Console.WriteLine("Value of Num: {0}", Delegate1.GetNum());
            nc2(3);
            Console.WriteLine("Value of Num: {0}", Delegate1.GetNum());

            // 委托的多播
            NumberChanger nc;
            nc = nc1;
            nc += nc2;
            nc(3);
            Console.WriteLine("Value of Num: {0}", Delegate1.GetNum());

            //
            MyDelegate deleg = Delegate2.MethodA;
            Delegate2.InvokeDelagete(deleg);
            deleg = Delegate2.MethodB;
            Delegate2.InvokeDelagete(deleg);

            add<int> sum = Delegate3.Sum;
            Console.WriteLine(sum(10, 20));
            add<string> con = Delegate3.Concat;
            Console.WriteLine(con("Hello ", "World!!"));

        }
    }

    // 委托的声明、实例化和使用
    delegate int NumberChanger(int n);
    public class Delegate1
    {
        static int num = 10;

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        
        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int GetNum()
        {
            return num;
        }
    }

    public delegate void MyDelegate(string msg);
    public class Delegate2
    {
        public static void MethodA(string message)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
        }

        public static void MethodB(string message)
        {
            Console.WriteLine("Called ClassA.MethodB() with parameter: " + message);
        }

        public static void InvokeDelagete(MyDelegate deleg){
            deleg("hi,,,");
        }
    }

    // 泛型委托
    public delegate T add<T>(T param1, T param2);
    public class Delegate3
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }

        public static string Concat(string a, string b)
        {
            return a + b;
        }
    }

}
