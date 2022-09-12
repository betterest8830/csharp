using System;
using System.Collections.Generic;

namespace P10E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person p1 = new Person();
            Person p2 = new Person();
            p1.Name = "deer";
            p2.Name = "deer wife";
            // List<Person> people = Person.GetMarry(p1, p2);
            List<Person> people = p1 + p2;
            foreach (var p in people)
            {
                Console.WriteLine(p.Name);
            }

            //委托
            Action action = new Action(Person.PrintHello);
            action();

            // 基础操作符
            var t = typeof(int);
            Console.WriteLine(t.Namespace);
            Console.WriteLine(t.FullName);
            foreach (var item in t.GetMethods())
            {
                Console.WriteLine(item);
            }

            // 一元操作符：
            // 强制类型转换
            Stone stone = new Stone();
            stone.Age = 1010;
            Monkey swk = (Monkey)stone;
            Console.WriteLine(swk.Age);


        }
    }

    class Person
    {
        public string Name;

        public static List<Person> GetMarry(Person p1, Person p2)
        {
            List<Person> people = new List<Person>();
            people.Add(p1);
            people.Add(p2);
            for (int i = 0; i < 11; i++)
            {
                Person child = new Person();
                child.Name = p1.Name + "& " + p2.Name + "s child";
                people.Add(child);
            }

            return people;
        }

        public static List<Person> operator +(Person p1, Person p2)
        {
            List<Person> people = new List<Person>();
            people.Add(p1);
            people.Add(p2);
            for (int i = 0; i < 11; i++)
            {
                Person child = new Person();
                child.Name = p1.Name + "& " + p2.Name + "s child";
                people.Add(child);
            }

            return people;
        }

        public static void PrintHello()
        {
            Console.WriteLine("Hello, world!");
        }
    }

    class Stone
    {
        public int Age;
        // 显示类型转换
        public static explicit operator Monkey(Stone stone)
        {
            var m = new Monkey()
            {
                Age = stone.Age / 500
            };
            return m;
        }
    }

    class Monkey
    {
        public int Age;
    }
}
