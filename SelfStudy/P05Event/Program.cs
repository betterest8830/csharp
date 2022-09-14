using System;
using System.IO;

namespace P05Event
{
    class Program
    {
        static void Main(string[] args)
        {
            EventTest e = new EventTest(); // 实例化对象,第一次没有触发事件
            SubscriptEvent v = new SubscriptEvent(); // 实例化对象
            e.ChangeNum += new EventTest.NumManipulationHandler(v.prinf); // 注册
            e.SetValue(7);
            e.SetValue(7);
            e.SetValue(10);

            BoilerInfoLogger filelog = new BoilerInfoLogger("d:\\boiler.txt");
            DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(RecordBoilerInfo.Logger);
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(filelog.Logger);
            boilerEvent.LogProcess();
            filelog.Close();
        }

    }

    // 发布器类
    public class EventTest
    {
        private int value;

        public delegate void NumManipulationHandler();

        public event NumManipulationHandler ChangeNum;

        protected virtual void OnChangeNum()
        {
            if(ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("first : event not fire");
            }
        }

        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }

        public void SetValue(int n)
        {
            if(value != n)
            {
                value = n;
                OnChangeNum();
            }
            else
            {
                Console.WriteLine("same num : event not fire");
            }
        }
    }

    // 订阅器类
    public class SubscriptEvent
    {
        public void prinf()
        {
            Console.WriteLine("event fire");
        }
    }

    // boiler 类
    public class Boiler
    {
        private int temp;
        private int pressure;
        public Boiler(int t, int p)
        {
            temp = t;
            pressure = p;
        }

        public int GetTemp()
        {
            return temp;
        }

        public int GetPressure()
        {
            return pressure;
        }
    }

    // 事件发布器
    class DelegateBoilerEvent
    {
        public delegate void BoilerLogHandler(string status);

        public event BoilerLogHandler BoilerEventLog;

        public void LogProcess()
        {
            string remarks = "O. K";
            Boiler b = new Boiler(100, 12);
            int t = b.GetTemp();
            int p = b.GetPressure();
            if (t > 150 || t < 80 || p < 12 || p > 15)
            {
                remarks = "Need Maintenance";
            }
            OnBoilerEventLog("Logging Info:\n");
            OnBoilerEventLog("Temparature " + t + "\nPressure: " + p);
            OnBoilerEventLog("\nMessage: " + remarks);
        }

        protected void OnBoilerEventLog(string message)
        {
            if(BoilerEventLog != null)
            {
                BoilerEventLog(message);
            }
        }
    }

    // 该类保留写入日志文件的条款
    class BoilerInfoLogger
    {
        FileStream fs;
        StreamWriter sw;

        public BoilerInfoLogger(string filename)
        {
            fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
        }

        public void Logger(string info)
        {
            sw.WriteLine(info);
        }

        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }

    // 事件订阅器
    public class RecordBoilerInfo
    {
        public static void Logger(string info)
        {
            Console.WriteLine(info);
        }
    }
}
