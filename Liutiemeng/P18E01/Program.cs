using System;
using System.Collections.Generic;
using System.Linq;

namespace P18E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestLinq();
        }

        static void TestLinq()
        {
            var myList = new List<int>() { 11, 12, 9, 14, 15 };
            bool result = myList.All(i => i > 10);
            Console.WriteLine(result);
        }
    }
}
