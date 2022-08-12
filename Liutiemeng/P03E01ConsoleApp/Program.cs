using P03E02ClassLibrary1;
using System;


namespace P03E01ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 别人的 dll
            Console.WriteLine("Hello World!");
            ClassLibraryTest.MyOperate op = new ClassLibraryTest.MyOperate();
            Console.WriteLine("sum = {0}", op.GetSum(3, 5));
            Console.WriteLine("sum = {0}", op.GetSubtract(3, 5));
            // 公开的 dll : System.Windows.Froms

            // nuget : Entity Framwork

            // 白盒的话，先把其他solotion 下的 project 加入到 当前 solution 然后 add preference

            // 建立自己的 libray, 编译后的结果就是 dll, 也需要 add proference
            double res = Calculater.Mul(1.2, 5.2);
            Console.WriteLine("res = {0}", res);

        }
    }
}
