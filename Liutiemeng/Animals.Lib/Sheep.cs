﻿
using System;
using BabyStroller.SDK;

namespace Animals.Lib
{
    public class Sheep : IAnimal
    {
        public void Voice(int times)
        {
            for (var i = 0; i < times; i++)
            {
                Console.WriteLine("Baa...");
            }
        }
    }
}