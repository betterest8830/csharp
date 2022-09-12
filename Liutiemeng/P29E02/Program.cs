using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using BabyStroller;
using BabyStroller.SDK;

namespace P29E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            var files = Directory.GetFiles(folder);
            var animalTypes = new List<Type>();
            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    // 如果类型里面有 Voice 方法，就认为是动物类
                    if (t.GetMethod("Voice") != null)
                    {
                        animalTypes.Add(t);
                    }
                    /*
                    // 通过接口和 Attribute 筛选类
                    if (t.GetInterfaces().Contains(typeof(IAnimal)))
                    {
                        var isUnfinished = t.GetCustomAttributes(false)
                            .Any(a => a.GetType() == typeof(UnfinishedAttribute));
                        if (isUnfinished) continue;
                        animalTypes.Add(t);
                    }
                    */
                }
            }

            while (true)
            {
                for (var i = 0; i < animalTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{animalTypes[i].Name}");
                }
                Console.WriteLine("==================");
                Console.WriteLine("Please choose animal:");
                var index = int.Parse(Console.ReadLine());
                if (index > animalTypes.Count || index < 1)
                {
                    Console.WriteLine("No such an animal. Try again!");
                    continue;
                }

                Console.WriteLine("How many times?");
                var times = int.Parse(Console.ReadLine());
                var t = animalTypes[index - 1];
                var m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);
                m.Invoke(o, new object[] { times });
            }
        }
    }
}
