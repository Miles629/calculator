using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderApp {

    /**
   **/
    public class Order:IComparable<Order>{

        [Key]
        public string OrderId { get; set; }

        public DateTime Time { get; set; }
        public string Customer { get; set; }

        public List<OrderItem> Items { get; set; }

        public Order() {
            OrderId = Guid.NewGuid().ToString();
            Items = new List<OrderItem>();
            Time = DateTime.Now;
        }

        public Order(List<OrderItem> items):this() {
            this.Time = DateTime.Now;
            if (items != null) Items = items;
        }

        public double TotalPrice {
            get=>Items.Sum(item => item.TotalPrice);
        }

        public bool AddItem(OrderItem orderItem) {
            if(Items.Contains(orderItem))
                throw new ApplicationException("订单项已存在!");
            Items.Add(orderItem);
            return true;
        }

        public void RemoveItem(OrderItem orderItem) {
            Items.Remove(orderItem);
        }

        public override string ToString() {
            string r;
            r = $"Id:{OrderId},orderTime:{Time},totalPrice：{TotalPrice}\n\t";
            foreach (OrderItem oi in Items)
            {
                r = r + oi.ToString();
            }
            return r;
        }

        public override bool Equals(object obj) {
            var m = obj as Order;
            return m != null &&
                   OrderId == m.OrderId && m.TotalPrice == TotalPrice;
        }

        public override int GetHashCode() {
            int i;
            Int32.TryParse(OrderId, out i);
            return i;
        }
        public int CompareTo(Order other) {
            if (other.OrderId == this.OrderId) return 1;
            return 0;
        }
    }
}