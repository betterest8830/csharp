using System;

namespace Animals.Lib2
{
    public class Dog
    {
        public void Voice(int times)
        {
            for (var i = 0; i < times; i++)
            {
                Console.WriteLine("Woof!");
            }
        }
    }
}