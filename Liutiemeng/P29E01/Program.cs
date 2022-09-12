using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Reflection;

namespace P29E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums1 = { 1, 2, 3, 4 };
            ArrayList nums2 = new ArrayList { 2, 4, 6, 8 };
            Console.WriteLine(Sum(nums1));
            Console.WriteLine(Sum(nums2));

            var nums3 = new ReadOnlyCollection(nums1);
            Console.WriteLine(Sum(nums3));

            // 显示接口实现
            IKiller killer = new WarmKiller();
            killer.Kill();

            var wk = (WarmKiller)killer;
            wk.Love();

            // 反射
            ITank tank = new HeavyTank();
            var t = tank.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo fireMi = t.GetMethod("Fire");
            MethodInfo runMi = t.GetMethod("Run");
            fireMi.Invoke(o, null);
            runMi.Invoke(o,null);

            // 依赖注入(nuget dependencyInjection)
            var sc = new ServiceCollection();
            //sc.AddScoped(typeof(ITank), typeof(HeavyTank));
            sc.AddScoped(typeof(ITank), typeof(LightTank));
            sc.AddScoped(typeof(IVehicle), typeof(Car));
            sc.AddScoped<Driver>();
            var sp = sc.BuildServiceProvider();
            // ===========分割线===========
            // 分割线上面是整个程序的一次性注册，下面是具体使用
            ITank tank1 = sp.GetService<ITank>();
            tank1.Fire();
            tank1.Run();
            var driver = sp.GetService<Driver>();
            driver.Drive();

            // 插件式编程

        }

        // 调用者绝不多要
        //static int Sum(ICollection nums)
        static int Sum(IEnumerable nums)
        {
            int sums = 0;
            foreach (var n in nums)
            {
                sums += (int)n;
            }
            return sums;
        }
    }

    class ReadOnlyCollection : IEnumerable
    {

        private int[] _array;

        public ReadOnlyCollection(int[] array)
        {
            _array = array;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }


        // 为了避免污染整个名称空间，所以用了成员类
        public class Enumerator : IEnumerator
        {
            private ReadOnlyCollection _collection;

            private int _head;
            
            public Enumerator(ReadOnlyCollection collection)
            {
                _collection = collection;
                _head = -1;
            }

            public object Current
            {
                get
                {
                    object o = _collection._array[_head];
                    return o;
                }
            }

            public bool MoveNext()
            {
                return ++_head < _collection._array.Length;
            }

            public void Reset()
            {
                _head = -1;
            }
        }
    }

    interface IGentleman
    {
        void Love();
    }

    interface IKiller
    {
        void Kill();
    }

    class WarmKiller : IGentleman, IKiller
    {
        public void Love()
        {
            Console.WriteLine("I will love you forever ...");
        }

        void IKiller.Kill()
        {
            Console.WriteLine("Let me kill the enemy ...");
        }
    }


    class Driver
    {
        private IVehicle _vehicle;

        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Drive()
        {
            _vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }

    interface ITank
    {
        void Fire();
        void Run();
    }

    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ka ...");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka! ka! ka! ...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka!! ka!! ka!! ...");
        }
    }
}
