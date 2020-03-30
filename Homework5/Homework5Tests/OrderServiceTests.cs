using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService service;
        OrderItem apple;
        OrderItem egg;
        OrderItem milk;
        [TestInitialize]
        public void Initialize()
        {
            //orderService1 = new OrderService();
            //orderService2 = new OrderService();
            //order_list = new List<Order>();
            //item_list = new List<OrderItem>();
            //item_list.Add(new OrderItem("apple", 1, 5, 2));
            //item_list.Add(new OrderItem("pen", 2, 10, 1));
            //order_list.Add(new Order("1", "mlies", 2, 20, item_list));
            service = new OrderService();
            apple = new OrderItem( "apple",1, 10.0, 1);
            egg = new OrderItem( "egg",2, 1.2, 1);
            milk = new OrderItem("milk",3, 50, 1);
            Order order1 = new Order("1", "Customer1",3,61.2, new List<OrderItem> { apple, egg, milk });
            Order order2 = new Order("2", "Customer2",2,51.2, new List<OrderItem> { egg, milk });
            Order order3 = new Order("3", "Customer2",2,60, new List<OrderItem> { apple, milk });
            service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
        }
        [TestCleanup]
        public void Clearup()
        {
            service = null;
            apple = null;
            egg = null;
            milk = null;
        }
        [TestMethod()]
        public void AddOrderTest1()
        {
            Order order4 = new Order("4", "Customer2",1,50, new List<OrderItem> { milk });
            service.AddOrder(order4);
            Assert.AreEqual(4, service.orders.Count);
            CollectionAssert.Contains(service.orders, order4);
            Assert.Fail();
        }
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void AddOrderTest2()
        {
            Order order4 = new Order("3", "Customer2",1,50, new List<OrderItem> { milk });
            service.AddOrder(order4);
        }

        [TestMethod()]
        public void DelOrderTest()
        {
            service.DelOrder(service.Search_order_num("3"));
            Assert.AreEqual(2, service.orders.Count);
            service.DelOrder(service.Search_order_num("100"));
            Assert.AreEqual(2, service.orders.Count);
            Assert.Fail();
        }

        [TestMethod()]
        public void ExOrderTest()
        {
            Order order3 = new Order("3", "Customer5",1,50, new List<OrderItem> { milk });
            service.ExOrder(order3,"3", "Customer5",1);
            Assert.AreEqual(3, service.orders.Count);
            Assert.Fail();
        }

        [TestMethod()]
        public void Search_order_numTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Search_commoditLy_nameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Search_customerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            Assert.Fail();
        }
    }
}