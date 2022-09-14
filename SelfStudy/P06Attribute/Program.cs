using System;
using System.Reflection;

namespace P06Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyClass2 myObj = new MyClass2();
            Type myType = typeof(MyClass2);
            FieldInfo fieldInfo = myType.GetField("myField");
            Console.WriteLine((int)fieldInfo.GetValue(myObj));
            fieldInfo.SetValue(myObj, 2);
            Console.WriteLine((int)fieldInfo.GetValue(myObj));
            FieldInfo staticFieldInfo = myType.GetField("myStaticField");
            Console.WriteLine(staticFieldInfo.GetValue(myObj));
            staticFieldInfo.SetValue(myObj, 3);
            Console.WriteLine(staticFieldInfo.GetValue(myObj));

            myObj = new MyClass2() { MyProperty = 1 };
            myType = typeof(MyClass2);
            PropertyInfo propertyInfo = myType.GetProperty("MyProperty"); 
            Console.WriteLine((int)propertyInfo.GetValue(myObj, null));
            propertyInfo.SetValue(myObj, 2, null);
            Console.WriteLine((int)propertyInfo.GetValue(myObj, null));

            PropertyInfo staticPropertyInfo = myType.GetProperty("MyStaticProperty"); 
            Console.WriteLine(staticPropertyInfo.GetValue(null, null)); 
            staticPropertyInfo.SetValue(null, 2);
            Console.WriteLine(staticPropertyInfo.GetValue(null, null));

            myType = typeof(MyClass2);
            ConstructorInfo constructorInfo = myType.GetConstructor(new Type[] { });
            myObj = constructorInfo.Invoke(null) as MyClass2;
            constructorInfo = myType.GetConstructor(new Type[] { typeof(int) });
            myObj = constructorInfo.Invoke(new object[] { 20 }) as MyClass2;

            //Attribute[] attributes = Attribute.GetCustomAttributes(typeof(MyClass2));
            Attribute[] attributes = Attribute.GetCustomAttributes(typeof(MyClass));
            foreach (var item in attributes)
            {
                Console.WriteLine("...{0}...", item);
                if(item is MyselfAttribute)
                {
                    MyselfAttribute attribute = item as MyselfAttribute;
                    Console.WriteLine(attribute.ClassName + " " + attribute.Author);
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited =true, AllowMultiple =true)]
    public class MyselfAttribute : Attribute
    {
        public string ClassName { get; private set; }
        public string Author;

        public MyselfAttribute(string className)
        {
            this.ClassName = className;
        }
    }

    [Myself("MyClass", Author = "Me")]
    public class MyClass
    {

        public int MyFunc([Myself("MyParameter")] int myNum)
        {
            int i = myNum + 5;
            return i;
        }
    }

    public class MyClass2
    {
        public int myField;
        public static int myStaticField;
        public int MyProperty { get; set; }
        public static int MyStaticProperty { get; set; }

        public MyClass2()
        {
            Console.WriteLine("MyClass() execute.");
        }
        public MyClass2(int num)
        {
            Console.WriteLine("MyClass(int num) execute, the parameter is: " + num);
        }
    }


}
