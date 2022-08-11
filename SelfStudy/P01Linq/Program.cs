using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData = { 5, 2, 0, 66, 4, 32, 7, 1 };
            TestLinq.TestLinq1(testData);
            TestLinq.TestLinq2(testData);
            TestLinq.TestLinq3(testData);

        }
    }

    class TestLinq
    {
        // 在C#2.0以前，假设有一个整数类型的数组，找到里面的偶数并进行降序排序。
        public static void TestLinq1(int[] testData)
        {
            List<int> newList = new List<int>();
            foreach (var item in testData)
            {
                if(item % 2 == 0)
                {
                    newList.Add(item);
                }
            }
            newList.Sort();
            newList.Reverse();
            Console.WriteLine(String.Join(",", newList));
        }

        // C#2.0引入了delegate，可以使用委托来处理这种场景
        public delegate bool FindEven(int item);
        public static int[] where(int[] testData, FindEven delete)
        {
            int[] newArray = new int[5];
            int i = 0;
            foreach (var item in testData)
            {
                if (delete(item))
                {
                    newArray[i] = item;
                    i++;
                }
            }
            return newArray;
        }
        public static void TestLinq2(int[] testData)
        {
            List<int> newList = where(testData, delegate (int item)
            {
                return item % 2 == 0;
            }).ToList();
            newList.Sort();
            newList.Reverse();
            Console.WriteLine(String.Join(",", newList));
        }

        // 在C#3.0中引入了扩展方法、Lambda表达式、匿名类型等新特性，你可以使用C#3.0的这些新特性
        public static void TestLinq3(int[] testData)
        {
            List<int> evens = testData.Where(p => p % 2 == 0).ToList();
            evens.Sort();
            evens.Reverse();
            int[] odds = testData.Where(P => P % 2 != 0).ToArray();
            Console.WriteLine("evens: " + string.Join(",", evens));
            Console.WriteLine("odds: " + string.Join(",", odds));
        }

    }

}
