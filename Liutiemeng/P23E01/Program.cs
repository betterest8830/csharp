using System;

namespace P23E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Student stu = new Student
            {
                ID = 1,
                Name = "LINA"
            };
            stu.Report();

            // 反射与 dynamic 示例
            Type t = typeof(Student);
            object o = Activator.CreateInstance(t, 2, "Tom");
            Console.WriteLine(o.GetType().Name);
            Student stu2 = o as Student;
            Console.WriteLine(stu2.Name);
            dynamic stu3 = Activator.CreateInstance(t, 3, "Timothy");
            Console.WriteLine(stu3.Name);
        }
    }

    class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public void Report()
        {
            Console.WriteLine($"I'm #{ID} student, my name is {Name}.");
        }

        public Student(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public Student()
        {

        }

        // can not output ???
        ~Student()
        {
            Console.WriteLine("Bye bye! Release the system resources ...");
        }
    }
}
