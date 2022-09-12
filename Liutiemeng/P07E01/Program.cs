using System;

namespace P07E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // 结构体类型
            int i = 6; //Int32
            long l = 7l; // Int64
            int x = new int(); // 合而为一
            x = 10;

            // 装箱和拆箱,损失性能(栈和堆互相拷贝)
            int x1 = 100;
            object obj = x1; // 装箱
            int x2 = (int)obj; // 拆箱


        }
    }
}
