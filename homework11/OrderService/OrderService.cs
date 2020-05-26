using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp {

    /**
   * The service class to manage orders
   * */
    public class OrderService {
        public static OrderContext db=new OrderContext();
        public OrderService() {
        }
        private static IQueryable<Order> getOrders()
        {
            return db.Orders.Include(o => o.Items.Select(i => i.GoodsItem));
        }
        public static List<Order> GetAllOrdersList() {
            return getOrders().ToList();
        }

        public static Order GetOrder(string id) {
            return getOrders().FirstOrDefault(o => o.OrderId == id);
        }

        public static bool AddOrder(Order order) {
            try {
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) {
                throw new ApplicationException($"添加错误: {e.Message}");
            }
        }

        public static bool RemoveOrder(string id) {
            try {
                var order = db.Orders.Include("Items").Where(o => o.OrderId == id).FirstOrDefault();
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) {
                throw new ApplicationException($"删除订单错误!");
            }
        }

        public static bool UpdateOrder(Order newOrder) {
            RemoveItems(newOrder.OrderId);
            db.Entry(newOrder).State = EntityState.Modified;
            db.OrderItems.AddRange(newOrder.Items);
            db.SaveChanges();
            return true;
        }

        private static bool RemoveItems(string orderId) {
            var oldItems = db.OrderItems.Where(item => item.OrderId == orderId);
            db.OrderItems.RemoveRange(oldItems);
            db.SaveChanges();
            return true;
        }

        public static List<Order> SearchByGoodsName(string goodsName) {
            var query = getOrders()
                .Where(o => o.Items.Count(i => i.GoodsItem.Name == goodsName) > 0);
            return query.ToList();
        }

        public static List<Order> SearchByCustomerName(string customerName) {
            var query = getOrders()
                .Where(o => o.Customer == customerName);
            return query.ToList();
        }

        public static void Export(String fileName) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                xs.Serialize(fs, GetAllOrdersList());
            }
        }

        public static void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open)) 
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => 
                {
                    AddOrder(order);
                });
            }
        }

    }
}