﻿using System;
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
    private static IQueryable<Order> getAllOrders()
    {
         return db.Orders.Include(o => o.Items.Select(i => i.GoodsItem))
                 .Include("Customer");
    }
    public static List<Order> GetAllOrders() {
        return getAllOrders().ToList();
    }

    public static Order GetOrder(string id) {
        return getAllOrders().FirstOrDefault(o => o.Id == id);
    }

    public static Order AddOrder(Order order) {
      try {
          db.Orders.Add(order);
          db.SaveChanges();
          return order;
      }
      catch (Exception e) {
        throw new ApplicationException($"添加错误: {e.Message}");
      }
    }

    public static void RemoveOrder(string id) {
      try {
          var order = db.Orders.Include("Items").Where(o => o.Id == id).FirstOrDefault();
          db.Orders.Remove(order);
          db.SaveChanges();
      }
      catch (Exception e) {
        //TODO 需要更加错误类型返回不同错误信息
        throw new ApplicationException($"删除订单错误!");
      }
    }

    public static void UpdateOrder(Order newOrder) {
        RemoveItems(newOrder.Id);
        db.Entry(newOrder).State = EntityState.Modified;
        db.OrderItems.AddRange(newOrder.Items);
        db.SaveChanges();
    }

    private static void RemoveItems(string orderId) {
        var oldItems = db.OrderItems.Where(item => item.OrderId == orderId);
        db.OrderItems.RemoveRange(oldItems);
        db.SaveChanges();
    }

    public static List<Order> QueryOrdersByGoodsName(string goodsName) {
        var query = getAllOrders()
          .Where(o => o.Items.Count(i => i.GoodsItem.Name == goodsName) > 0);
        return query.ToList();
    }

    public static List<Order> QueryOrdersByCustomerName(string customerName) {
        var query = getAllOrders()
          .Where(o => o.Customer.Name == customerName);
        return query.ToList();
    }

    public static object QueryByTotalAmount(float amout) {
        return getAllOrders()
          .Where(o => o.Items.Sum(item => item.GoodsItem.Price * item.Quantity) > amout)
          .ToList();
    }



    public static void Export(String fileName) {
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
        xs.Serialize(fs, GetAllOrders());
      }
    }

    public static void Import(string path) {
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(path, FileMode.Open)) {
        List<Order> temp = (List<Order>)xs.Deserialize(fs);
        temp.ForEach(order => {
          try {
            AddOrder(order);
          }catch {
            //ignore errors
          }
        });
      }
    }
  }
}
