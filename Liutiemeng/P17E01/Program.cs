using System;
using System.Collections.Generic;

namespace P17E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student1 stu1 = new Student1();
            stu1.SetAge(20);

            Student2 stu2 = new Student2();
            stu2.Age = 20;

            Student3 stu3 = new Student3();
            stu3["Math"] = 90;
            var mathScore = stu3["Math"];
            Console.WriteLine(mathScore);
            

        }

        class Student1
        {
            private int age;

            public int GetAge()
            {
                return age;
            }

            public void SetAge(int value)
            {
                if(value >= 0 && value <= 120)
                {
                    this.age = value;
                }
                else
                {
                    throw new Exception("Age value has error");
                }
            }
        }

        class Student2
        {
            private int age;

            public int Age
            {
                get { return this.age; }
                set
                {
                    // value 为上下文关键字
                    if (value >= 0 && value <= 120)
                    {
                        this.age = value;
                    }
                    else
                    {
                        throw new Exception("Age value has error");
                    }
                }
            }

            // 高级版本修改属性 : ctr+r, ctrl+e
            private string testId;

            public string TestId { get => testId; set => testId = value; }
        }

        class Student3
        {
            private Dictionary<string, int> scoreDictionary = new Dictionary<string, int>();

            public int? this[string subject]
            {
                get {
                    if (this.scoreDictionary.ContainsKey(subject))
                    {
                        return this.scoreDictionary[subject];
                    }
                    else
                    {
                        return null;
                    }
                }
                set {
                    if (value.HasValue == false)
                    {
                        throw new Exception("score is null");
                    }
                    if (this.scoreDictionary.ContainsKey(subject))
                    {
                        this.scoreDictionary[subject] = value.Value;
                    }
                    else
                    {
                        this.scoreDictionary.Add(subject, value.Value);
                    }
                }
            }
        }
    }
}
