using System;

namespace P09E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Student
    {
        public int Id;
        public String Name;

        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
