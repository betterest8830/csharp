using System;
using System.Reflection;

namespace P06E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Type myType = typeof(int);
            Console.WriteLine(myType.FullName);
            Console.WriteLine(myType.BaseType);
            PropertyInfo[] pInfos = myType.GetProperties();
            MemberInfo[] mInfos = myType.GetMethods();
            foreach (var p in mInfos)
            {
                Console.WriteLine(p.Name);
            }
            //StackTest();
        }

        static void StackTest()
        {
            unsafe
            {
                int* p = stackalloc int[9999999];
            }
        }
    }
}
