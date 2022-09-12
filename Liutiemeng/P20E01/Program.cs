using System;
using System.Threading;

namespace P20E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // 1.事件拥有者
            var customer = new Customer();
            // 2.事件响应者
            var waiter = new Waiter();
            // 3.Order 事件成员 5. +=事件订阅
            customer.Order += waiter.Action;

            customer.Action();
            customer.PayTheBill();
        }
    }

    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }

        public string Size { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);
    
    public class Customer
    {
        // 事件声明完整格式
        private OrderEventHandler orderEventHandler;

        public event OrderEventHandler Order
        {
            add { this.orderEventHandler += value; }
            remove { this.orderEventHandler -= value; }
        }

        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0}.", this.Bill);
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit down.");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think ...");
                Thread.Sleep(1000);
            }

            if (this.orderEventHandler != null)
            {
                var e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";

                this.orderEventHandler.Invoke(this, e);
            }
        }

        public void Action()
        {
            //Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    public class Waiter
    {
        // 4.事件处理器
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will serve you the dish - {0}.", e.DishName);

            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price *= 0.5;
                    break;
                case "large":
                    price *= 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
}
