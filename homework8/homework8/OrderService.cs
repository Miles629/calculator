using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace homework8

{
    [Serializable]
    public class OrderService
    {
        public List<Order> orders = new List<Order>();
        public OrderService()
        {
        }
        public void AddOrder(string onum, string cus, int tnum, double tp, List<OrderItem> list)

        {
            Order o = new Order(onum, cus, tnum, tp, list);
            foreach (Order a in orders)
            {
                if (o.Equals(a))
                {
                    Exception exception = new Exception("订单重复！添加失败");
                    throw exception;
                    //Console.WriteLine("订单重复！添加失败");
                    //return;
                }
            }
            orders.Add(o);
        }
        public void AddOrder(Order o)
        {
            orders.Add(o);
        }
        public void Sort()
        {
            //只写了默认以订单号排序，自定义排序无非是要分情况多写几个，今天太累了不写了。。。
            try
            {
                orders.Sort((p1, p2) => Convert.ToInt32(p1.order_num) - Convert.ToInt32(p2.total_num));
            }catch(Exception e)
            {
                throw e;
            }
        }
        public void DelOrder(IEnumerable<Order> p)
        {
            if (p.First() != null) 
            {
                try
                {
                    foreach (Order o in p)
                    {
                        orders.Remove(o);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                Exception ex = new Exception("无此订单！");
                throw ex;
            }
        }
        public void DelOrder(Order o)
        {
            orders.Remove(o);
        }

        public bool ExOrder(Order o,string a,string b,int c)
        {
            try
            {
                o.order_num = a;
                o.customer = b;
                o.total_num = c;
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Order> Search_order_num(string find)
        {
            var q = from s in orders
                    where s.order_num == find
                    orderby s.total_price
                    select s;
            return q;

        }
        public IEnumerable<Order> Search_commoditLy_name(string find)
        {
            var q = from s in orders
                    from a in s.details
                    where a.commodity_name == find
                    orderby s.total_price
                    select s;
            return q;

        }
        public IEnumerable<Order> Search_customer(string find)
        {
            var q = from s in orders
                    where s.customer == find
                    orderby s.total_price
                    select s;
            //List<Order> list = q.ToList();
            return q;
        }
        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (List<Order>));
            using (FileStream fs = new FileStream("Orders.xml",FileMode.Create))
            {
                xmlSerializer.Serialize(fs,orders);
            }
        }
        public void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs=new FileStream("Orders.xml", FileMode.Open))
            {
                orders = (List<Order>)xmlSerializer.Deserialize(fs);
            }
        }
    }
}
