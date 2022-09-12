using System;
using System.Collections;

namespace P28E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // 整型数组的基类是 Array，Array 和 ArrayList 都实现了 IEnumerable。
            int[] nums1 = new int[] { 1, 2, 3, 4, 5 };
            // ArrayList 里面存储的元素类型是 object 
            ArrayList nums2 = new ArrayList { 1, 2, 3, 4, 5 };
            var fan = new DeskFan(new PowerSupply());
            Console.WriteLine(fan.Work());

        }
    }

    public interface IPowerSupply
    {
        int GetPower();
    }

    public class PowerSupply : IPowerSupply
    {
        public int GetPower()
        {
            return 110;
        }
    }

    public class DeskFan
    {
        private IPowerSupply _powerSupply;

        public DeskFan(IPowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }

        public string Work()
        {
            int power = _powerSupply.GetPower();
            if (power <= 0)
            {
                return "Won't work.";
            }
            else if (power < 100)
            {
                return "Slow";
            }
            else if (power < 200)
            {
                return "Work fine";
            }
            else
            {
                return "Warning";
            }
        }
    }
}
