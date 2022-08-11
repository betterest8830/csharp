using System;
using System.Diagnostics;

namespace P02Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CommonMethod.ShowObject(1);
            CommonMethod.ShowObject("1");
            CommonMethod.Show<int>(1);
            CommonMethod.Show<string>("1");
            Monitor.Show();
        }
    }

    public class CommonMethod
    {
        // 使用Object类型达到了我们的要求，解决了代码的可复用
        public static void ShowObject(object o)
        {
            Console.WriteLine("This is {0}, parameter={1}, type={2}", 
                typeof(CommonMethod), o.GetType().Name, o);
        }

        // 上面object类型的方法又会带来另外一个问题：装箱和拆箱，会损耗程序的性能
        // 微软在C#2.0的时候推出了泛型，可以很好的解决上面的问题
        // 泛型方法
        public static void Show<T>(T t)
        {
            Console.WriteLine("This is {0}, parameter={1}, type={2}",
                typeof(CommonMethod), t.GetType().Name, t);
        }

    }

    public class Monitor
    {
        public static void Show()
        {
            Console.WriteLine("********monitor start*******");
            int value = 1234;
            long commonSecond=0, objectSecond=0, genericSecond=0;
            
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1000000000; i++)
                {
                    ShowInt(value);
                }
                watch.Stop();
                commonSecond = watch.ElapsedMilliseconds;
            }

            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1000000000; i++)
                {
                    ShowObject(value);
                }
                watch.Stop();
                objectSecond = watch.ElapsedMilliseconds;
            }

            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1000000000; i++)
                {
                    Show<int>(value);
                }
                watch.Stop();
                genericSecond = watch.ElapsedMilliseconds;
            }

            Console.WriteLine("commonSecond={0},objectSecond={1},genericSecond={2}", commonSecond, objectSecond, genericSecond);
            Console.WriteLine("********monitor end*******");
        }

        #region PrivateMethod
        private static void ShowInt(int iParameter)
        {
            //do nothing
        }
        private static void ShowObject(object oParameter)
        {
            //do nothing
        }
        private static void Show<T>(T tParameter)
        {
            //do nothing
        }
        #endregion
    }

    // 泛型类

    // 泛型接口

    // 泛型委托

    // 泛型约束

    // 泛型的协变和逆变

    // 泛型缓存


}
