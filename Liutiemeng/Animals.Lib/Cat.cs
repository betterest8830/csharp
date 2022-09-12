using System;

namespace Animals.Lib
{
    public class Cat
    {
        public void Voice(int times)
        {
            for (var i = 0; i < times; i++)
            {
                Console.WriteLine("Meow!");
            }
        }
    }
}