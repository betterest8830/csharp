using System;

namespace P27E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Vehicle1 vehicle1 = new Vehicle1();
            vehicle1.Run();
            Car car = new Car();
            car.Run();
        }
    }

    // 为做基类而生的“抽象类”与“开闭原则”
    class Vehicle1
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public virtual void Run()
        {
            Console.WriteLine("Vehicle is running...");
        }
    }

    interface VehicleBase
    {
        void Stop();
        void Fill();
        void Run();

    }

    abstract class Vehicle : VehicleBase
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public void Fill()
        {
            Console.WriteLine("Pay and fill...");
        }
        
        public abstract void Run(); // 不能省略
    }

    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }

}
