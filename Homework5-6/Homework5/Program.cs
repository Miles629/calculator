using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Program
    {

        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            while(true)
            {
                Console.WriteLine("1,添加订单\t2,删除订单\t3,修改订单\t4,查找订单\t" +
                    "5,按订单号排序\t6,序列化保存\t7,反序列化读取");
                string cho = Console.ReadLine();
                try
                {
                    switch (cho)
                    {
                        case "1": Addorder(orderService); break;
                        case "2": Delorder(orderService); break;
                        case "3": Exorder(orderService); break;
                        case "4": Searchorder(orderService); break;
                        case "5": Sort(orderService);break;
                        case "6": orderService.Export();break;
                        case "7": orderService.Import();break;
                    }
                }catch(Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void Sort(OrderService orderService)
        {
            orderService.Sort();
        }
        static IEnumerable<Order> Searchorder(OrderService orderService)
        {
            Console.WriteLine("1,根据订单号查找\t2，根据商品查找\t3，根据用户查找");
            string cho = Console.ReadLine();
            IEnumerable<Order> p;
            switch (cho)
            {
                case "1":
                    {
                        Console.Write("输入订单号：");
                        string find = Console.ReadLine();
                        p=orderService.Search_order_num(find);
                        break;
                    }
                case "2":
                    {
                        Console.Write("输入商品名：");
                        string find = Console.ReadLine();
                        p=orderService.Search_commoditLy_name(find);
                        break;
                    }
                case "3":
                    {
                        Console.Write("输入用户名：");
                        string find = Console.ReadLine();
                        p=orderService.Search_customer(find);
                        break;
                    }
                default:
                    {
                        Exception e = new Exception("查找格式错误");
                        throw e;
                    }
            }
            if (p.Count() != 0)
                foreach (Order o in p)
                {
                    Console.WriteLine(o.ToString());
                }
            else
                Console.WriteLine("未找到对应订单，请确认信息是否正确！");
            return p;
        }
        static void Exorder(OrderService orderService)
        {
            
            try
            {
                IEnumerable<Order> p=Searchorder(orderService);
                foreach (Order o in p)
                {
                    Console.WriteLine("当前订单信息：");
                    Console.WriteLine(o.ToString());
                    Console.WriteLine("输入订单号：");
                    string order_num = Console.ReadLine();
                    Console.WriteLine("输入用户名：");
                    string customer = Console.ReadLine();
                    Console.WriteLine("输入总商品种类数：");
                    int a;
                    Int32.TryParse(Console.ReadLine(), out a);
                    int total_num = a;
                    orderService.ExOrder(o,order_num,customer,total_num);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Delorder(OrderService orderService)
        {
            try
            {
                orderService.DelOrder(Searchorder(orderService));
                Console.WriteLine("删除成功！");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Addorder(OrderService orderService)
        {
            Console.WriteLine("输入订单号：");
            string order_num = Console.ReadLine();
            Console.WriteLine("输入用户名：");
            string customer = Console.ReadLine();
            Console.WriteLine("输入总商品种类数：");
            int total_num;
            Int32.TryParse(Console.ReadLine(), out total_num);
            List<OrderItem> details = new List<OrderItem>();
            int i = total_num;
            for (; i > 0; i--)
            {
                Console.WriteLine("输入商品名：");
                string commodity_name = Console.ReadLine();
                Console.WriteLine("输入商品ID：");
                int id; double per_price; int number;
                Int32.TryParse(Console.ReadLine(), out id);
                Console.WriteLine("输入单价：");
                Double.TryParse(Console.ReadLine(), out per_price);
                Console.WriteLine("输入数量：");
                Int32.TryParse(Console.ReadLine(), out number);
                OrderItem new_d = new OrderItem(commodity_name, id, per_price, number);
                foreach (OrderItem oi in details)
                {
                    if (oi.Equals(new_d))
                    {
                        Exception exception = new Exception("订单明细重复！添加失败");
                        throw exception;
                        //Console.WriteLine("订单明细重复！添加失败");
                        //return;
                    }
                }
                details.Add(new_d);
            }
            double total_price = 0;
            details.ForEach(s => total_price += (s.per_price * s.number));
            orderService.AddOrder(order_num, customer, total_num, total_price, details);
        }
    }
}
