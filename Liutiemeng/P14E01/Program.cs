using System;
using System.Collections;
using System.Collections.Generic;

namespace P14E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        hello: Console.WriteLine("try go lable");
            TestSwitch();
            TestEnumerator();
        }

        static void TestSwitch()
        {
            //int score = 100;
            int score = 101;

            switch (score / 10)
            {
                case 10:// 必须是常量值
                    if(score == 100)
                    {
                        goto case 9;
                    }
                    else
                    {
                        goto default;
                    }
                // 只有单独的标签才能连起来写。
                case 9:
                case 8:
                    Console.WriteLine("A");
                    break; // 一旦有了具体的 section，就必需配套 break。

                default:
                    break;
            }

            return;
        }

        static void TestEnumerator()
        {

            var intArray = new int[] { 1, 3, 5, 7 };
            IEnumerator enumerator = intArray.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            var intList = new List<int>() { 2, 4, 6, 8 };
            IEnumerator enumerator2 = intList.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                Console.WriteLine(enumerator2.Current);
            }
            return;
        }
    }
}
