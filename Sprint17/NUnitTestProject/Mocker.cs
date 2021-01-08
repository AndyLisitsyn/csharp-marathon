using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using NUnit.Framework;
using Moq;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NUnitTestProject
{
    class Mocker
    {
        private Mock<ShoppingContext> mock;
        private static Mocker instance;
        public static Mocker getInstance()
        {
            if (instance == null)
                instance = new Mocker();
            return instance;
        }
        public Mocker()
        {
            mock = new Mock<ShoppingContext>();

            var mockCustomerSet = new Mock<DbSet<Customer>>();
            var customersData = GetTestCustomers().AsQueryable();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customersData.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customersData.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customersData.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customersData.GetEnumerator());
            mock.Setup(c => c.Customers).Returns(mockCustomerSet.Object);

            var mockProductsSet = new Mock<DbSet<Product>>();
            var productsData = GetTestProducts().AsQueryable();
            mockProductsSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(productsData.Provider);
            mockProductsSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(productsData.Expression);
            mockProductsSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(productsData.ElementType);
            mockProductsSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(productsData.GetEnumerator());
            mock.Setup(c => c.Products).Returns(mockProductsSet.Object);

            var mockOrdersSet = new Mock<DbSet<Order>>();
            var ordersData = GetTestOrders().AsQueryable();
            mockOrdersSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(ordersData.Provider);
            mockOrdersSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(ordersData.Expression);
            mockOrdersSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(ordersData.ElementType);
            mockOrdersSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(ordersData.GetEnumerator());
            mock.Setup(c => c.Orders).Returns(mockOrdersSet.Object);

            var mockSupermarketsSet = new Mock<DbSet<Supermarket>>();
            var supermarketData = GetTestSupermarkets().AsQueryable();
            mockSupermarketsSet.As<IQueryable<Supermarket>>().Setup(m => m.Provider).Returns(supermarketData.Provider);
            mockSupermarketsSet.As<IQueryable<Supermarket>>().Setup(m => m.Expression).Returns(supermarketData.Expression);
            mockSupermarketsSet.As<IQueryable<Supermarket>>().Setup(m => m.ElementType).Returns(supermarketData.ElementType);
            mockSupermarketsSet.As<IQueryable<Supermarket>>().Setup(m => m.GetEnumerator()).Returns(supermarketData.GetEnumerator());
            mock.Setup(c => c.Supermarkets).Returns(mockSupermarketsSet.Object);

            var mockOrderDetailsSet = new Mock<DbSet<OrderDetails>>();
            var orderDetailsData = GetTestOrderDetails().AsQueryable();
            mockOrderDetailsSet.As<IQueryable<OrderDetails>>().Setup(m => m.Provider).Returns(orderDetailsData.Provider);
            mockOrderDetailsSet.As<IQueryable<OrderDetails>>().Setup(m => m.Expression).Returns(orderDetailsData.Expression);
            mockOrderDetailsSet.As<IQueryable<OrderDetails>>().Setup(m => m.ElementType).Returns(orderDetailsData.ElementType);
            mockOrderDetailsSet.As<IQueryable<OrderDetails>>().Setup(m => m.GetEnumerator()).Returns(orderDetailsData.GetEnumerator());
            mock.Setup(c => c.OrdersDetails).Returns(mockOrderDetailsSet.Object);
        }

        public Mock<ShoppingContext> GetMock()
            => mock;

        public ShoppingContext Build()
            => mock.Object;

        private List<Customer> GetTestCustomers()
           => new List<Customer>()
            {
               new Customer {FirstName = "Ramil", LastName = "Naum", Address = "Los-Ang", Discount = "5"},
                new Customer {FirstName = "Bob", LastName = "Dillan", Address = "Berlin", Discount = "7"},
                new Customer {FirstName = "Kile", LastName = "Rise", Address = "London", Discount = "0"},
                new Customer {FirstName = "John", LastName = "Konor", Address = "Vashington", Discount = "3"},
                new Customer {FirstName = "Tony", LastName = "Stark", Address = "Florida", Discount = "5"},
                new Customer {FirstName = "Jamie", LastName = "Lanister", Address = "Westerros", Discount = "10"}
            };

        private List<Order> GetTestOrders()
          => new List<Order>()
           {
               new Order {CustomerId = 1, SupermarketId = 1, OrderDate = DateTime.Parse("4-11-2019")},
                new Order {CustomerId = 1, SupermarketId = 2, OrderDate = DateTime.Parse("5-6-2020")},
                new Order {CustomerId = 2, SupermarketId = 3, OrderDate = DateTime.Parse("2-11-2018")},
                new Order {CustomerId = 3, SupermarketId = 4, OrderDate = DateTime.Parse("7-7-2020")},
                new Order {CustomerId = 4, SupermarketId = 2, OrderDate = DateTime.Parse("1-8-2020")},
                new Order {CustomerId = 5, SupermarketId = 3, OrderDate = DateTime.Parse("9-3-2019")},
                new Order {CustomerId = 6, SupermarketId = 3, OrderDate = DateTime.Parse("12-12-2020")}
           };

        private List<Supermarket> GetTestSupermarkets()
          => new List<Supermarket>()
           {
               new Supermarket {Name = "Rozetka", Address = "Petrovka district"},
                new Supermarket {Name = "Comfy", Address = "Obolonsky district"},
                new Supermarket {Name = "Foxtrot", Address = "Pechercka district"},
                new Supermarket {Name = "Allo", Address = "Shevchenka district"},
                new Supermarket {Name = "Citrus", Address = "Obolon, Drea Town"},
                new Supermarket {Name = "Moyo", Address = "Skymall Troeshina"},
                new Supermarket {Name = "Stilus", Address = "Svyatosino"}
           };

        private List<Product> GetTestProducts()
         => new List<Product>()
          {
                new Product {Name = "Asus laptop x550", Price = 880},
                new Product {Name = "Iphone X", Price = 1200},
                new Product {Name = "Samsung Galaxy X9", Price = 1100},
                new Product {Name = "Mouse Loditec", Price = 100},
                new Product {Name = "Keyboard Logitec", Price = 200},
                new Product {Name = "Monitor Dell", Price = 320},
                new Product {Name = "TV LG", Price = 1300}
          };

        private List<OrderDetails> GetTestOrderDetails()
         => new List<OrderDetails>()
          {
                 new OrderDetails {OrderId = 1, ProductId = 1, Quantity = 2},
                new OrderDetails {OrderId = 1, ProductId = 4, Quantity = 9},
                new OrderDetails {OrderId = 1, ProductId = 5, Quantity = 7},
                new OrderDetails {OrderId = 2, ProductId = 2, Quantity = 1},
                new OrderDetails {OrderId = 3, ProductId = 3, Quantity = 2},
                new OrderDetails {OrderId = 4, ProductId = 4, Quantity = 5},
                new OrderDetails {OrderId = 5, ProductId = 5, Quantity = 11},
                new OrderDetails {OrderId = 5, ProductId = 7, Quantity = 2},
                new OrderDetails {OrderId = 6, ProductId = 6, Quantity = 4},
                new OrderDetails {OrderId = 7, ProductId = 3, Quantity = 6},
                new OrderDetails {OrderId = 7, ProductId = 7, Quantity = 2}
          };

    }
}
