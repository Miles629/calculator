using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class OrderItem
    {
        //public OrderItem()
        //{
        //    Console.WriteLine("输入商品名：");
        //    commodity_name = Console.ReadLine();
        //    Console.WriteLine("输入商品ID：");
        //    Int32.TryParse(Console.ReadLine(), out id);
        //    Console.WriteLine("输入单价：");
        //    Double.TryParse(Console.ReadLine(), out per_price);
        //    Console.WriteLine("输入数量：");
        //    Int32.TryParse(Console.ReadLine(), out number);
        //}
        public OrderItem(string a, int b, double c, int d)
        {

            commodity_name = a;
            id = b;
            per_price = c;
            number = d;
        }
        public string commodity_name { get; }
        public int id { get; }
        public double per_price { get; }
        public int number { get; }
        public override string ToString()
        {
            return ($"商品名：{commodity_name}\t单价：{per_price}\t数量：{number}\r\n");
        }
        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.commodity_name == commodity_name
              && m.per_price == per_price && m.number == number;
        }
        public override int GetHashCode()
        {
            return id;
        }
    }
}
