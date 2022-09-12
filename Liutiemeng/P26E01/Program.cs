using System;

namespace P26E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //重写
            var car = new Car();
            car.Run();
            var v = new Vehicle();
            v.Run();
            // hide
            // 可以理解为 v 作为 Vehicle 类型，它本来应该顺着继承链往下（一直到 Car）找 Run 的具体实现，
            // 但由于 Car 没有 Override，所以它找不下去，只能调用 Vehicle 里面的 Run。
            Vehicle1 v1 = new Car1();
            v1.Run();
        }
    }

    class Vehicle
    {
        public virtual void Run()
        {
            Console.WriteLine("I'm running!");
        }
    }

    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running!");
        }
    }

    class Vehicle1
    {
        public void Run()
        {
            Console.WriteLine("I'm running!");
        }
    }

    class Car1 : Vehicle1
    {
        public void Run()
        {
            Console.WriteLine("Car is running!");
        }
    }
}
