using System;
using System.Collections.Generic;

namespace P03Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Student1 student1 = new Student1();
            student1.Name = "lina";
            Console.WriteLine(student1.Name);

            Student2 student2 = new Student2();
            for (int i = 0; i < student2.listStudent.Count; i++)
            {
                student2[i].Name += "...";
                Console.WriteLine(student2[i].Name);
            }

            Student3 student3 = new Student3();
            Student3 stu = student3[1, "lina"];
            Console.WriteLine("student number:" + stu.Sid + ",name:" + stu.Name + ",score:" + stu.Score);
            student3[1, "lina"] = new Student3(111, "lina", 66);
            stu = student3[111, "lina"];
            Console.WriteLine("student number:" + stu.Sid + ",name:" + stu.Name + ",score:" + stu.Score);
        }
    }

    public class Student1
    {

        private string name;
        // property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public class Student2
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Student2> listStudent = new List<Student2>();

        public Student2(string name)
        {
            this.name = name;
        }
        public Student2()
        {
            this.listStudent.Add(new Student2("lina1"));
            this.listStudent.Add(new Student2("lina2"));
            this.listStudent.Add(new Student2("lina3"));
        }

        public Student2 this[int index]
        {
            get { return listStudent[index]; }
            set { listStudent[index] = value; }
        }
    }

    // 构建多个参数的索引器
    public class Student3
    {

        public List<Student3> listStudent3 = new List<Student3>();

        private int sid;

        public int Sid
        {
            get { return sid; }
            set { sid = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Student3(int sid, string name, int score)
        {
            this.sid = sid;
            this.name = name;
            this.score = score;
        }

        public Student3()
        {
            this.listStudent3.Add(new Student3(1, "lina", 88));
            this.listStudent3.Add(new Student3(2, "lina", 90));
            this.listStudent3.Add(new Student3(3, "lina", 98));
        }

        public Student3 this[int i, string name]
        {
            get 
            {
                foreach (var stu in listStudent3.ToArray())
                {
                    if(stu.sid == i && stu.name == name)
                    {
                        return stu;
                    }
                }
                return null;
            }

            set { listStudent3[i] = value; }
        }
    }
}
