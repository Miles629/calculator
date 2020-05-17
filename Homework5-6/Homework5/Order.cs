using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    [Serializable]
    public class Order
    {
        public Order(string onum, string cus, int tnum, double tp, List<OrderItem> list)
        {

            //Console.WriteLine("输入订单号：");
            //order_num = Console.ReadLine();
            //Console.WriteLine("输入用户名：");
            //customer = Console.ReadLine();
            //Console.WriteLine("输入总商品种类数：");
            //Int32.TryParse(Console.ReadLine(),out total_num);
            order_num = onum;
            customer = cus;
            total_num = tnum;
            total_price = tp;
            details = list;
            //for (;total_num>0;total_num--)
            //{
            //    OrderItem new_d = new OrderItem();
            //    foreach (OrderItem oi in details)
            //    {
            //        if (oi.Equals(new_d))
            //        {
            //            Console.WriteLine("订单明细重复！添加失败");
            //            return;
            //        }
            //    }
            //    details.Add(new_d);
            //}
            //details.ForEach(s => total_price += (s.per_price*s.number));
        }
        public Order()
        {

        }
        public List<OrderItem> details { get; set; }
        public string order_num { get; set; }
        public string customer { get; set; }
        public int total_num { get; set; }
        public double total_price { get; set; }
        public override string ToString()
        {
            string r = ($"订单号：{order_num}\r\n用户名：{customer}\r\n总金额：{total_price}\r\n");
            foreach (OrderItem oi in details)
            {
                r = r + oi.ToString();
            }
            return r;
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m != null && m.total_num == total_num
              && m.customer == customer && m.total_price == total_price;
        }
        public override int GetHashCode()
        {
            int i;
            Int32.TryParse(order_num, out i);
            return i;
        }
    }
}
