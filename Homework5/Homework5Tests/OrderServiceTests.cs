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
        List<Order> order_list;
        List<OrderItem> item_list;
        OrderService orderService1;
        OrderService orderService2;
        [TestInitialize]
        public void Initialize()
        {
            orderService1 = new OrderService();
            orderService2 = new OrderService();
            order_list = new List<Order>();
            item_list = new List<OrderItem>();
            item_list.Add(new OrderItem("apple", 1, 5, 2));
            item_list.Add(new OrderItem("pen", 2, 10, 1));
            order_list.Add(new Order("1", "mlies", 2, 20, item_list));
            
        }
        [TestCleanup]
        public void Clearup()
        {
            orderService1 = null;
            orderService2 = null;
            order_list = null;
            item_list = null;
        }
        [TestMethod()]
        public void AddOrderTest()
        {
            orderService1.AddOrder("1", "miles", 2, 20, item_list);
            CollectionAssert.AreEqual(orderService1.orders,order_list);
            Assert.Fail();
        }

        [TestMethod()]
        public void SortTest()
        {
            orderService1.Sort();
            Assert.Fail();
        }

        [TestMethod()]
        public void DelOrderTest()
        {
            orderService1.DelOrder(orderService1.Search_order_num(""));
            Assert.Fail();
        }

        [TestMethod()]
        public void ExOrderTest()
        {
            orderService1.ExOrder(order_list[0], "99", "99", 99);
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