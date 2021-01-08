﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprint_16.Models;

namespace Sprint_16
{
    public class SampleData
    {
        public static void Initialize(ShoppingContext context)
        {
            context.Database.EnsureCreated();
            if (context.Customers.Any())
                return;
            Customer[] customers = new Customer[]
            {
                new Customer {FName = "Ramil", LName = "Naum", Address = "Los-Ang", Discount = "5"},
                new Customer {FName = "Bob", LName = "Dillan", Address = "Berlin", Discount = "7"},
                new Customer {FName = "Kile", LName = "Rise", Address = "London", Discount = "0"},
                new Customer {FName = "John", LName = "Konor", Address = "Vashington", Discount = "3"},
                new Customer {FName = "Tony", LName = "Stark", Address = "Florida", Discount = "5"},
                new Customer {FName = "Jamie", LName = "Lanister", Address = "Westerros", Discount = "10"},
            };
            foreach (Customer customer in customers)
                context.Customers.Add(customer);
            context.SaveChanges();

            Product[] products = new Product[]
            {
                new Product {Name = "Asus laptop x550", Price = 880},
                new Product {Name = "Iphone X", Price = 1200},
                new Product {Name = "Samsung Galaxy X9", Price = 1100},
                new Product {Name = "Mouse Loditec", Price = 100},
                new Product {Name = "Keyboard Logitec", Price = 200},
                new Product {Name = "Monitor Dell", Price = 320},
                new Product {Name = "TV LG", Price = 1300},
            };
            foreach (Product product in products)
                context.Products.Add(product);
            context.SaveChanges();

            Supermarket[] supermarkets = new Supermarket[]
            {
                new Supermarket {Name = "Rozetka", Address = "Petrovka district"},
                new Supermarket {Name = "Comfy", Address = "Obolonsky district"},
                new Supermarket {Name = "Foxtrot", Address = "Pechercka district"},
                new Supermarket {Name = "Allo", Address = "Shevchenka district"},
                new Supermarket {Name = "Citrus", Address = "Obolon, Drea Town"},
                new Supermarket {Name = "Moyo", Address = "Skymall Troeshina"},
                new Supermarket {Name = "Stilus", Address = "Svyatosino"},
            };
            foreach (Supermarket supermarket in supermarkets)
                context.Supermarkets.Add(supermarket);
            context.SaveChanges();

            Order[] orders = new Order[]
            {
                new Order {CustomerId = 1, SupermarketId = 1, OrderDate = DateTime.Parse("4-11-2019")},
                new Order {CustomerId = 1, SupermarketId = 2, OrderDate = DateTime.Parse("5-6-2020")},
                new Order {CustomerId = 2, SupermarketId = 3, OrderDate = DateTime.Parse("2-11-2018")},
                new Order {CustomerId = 3, SupermarketId = 4, OrderDate = DateTime.Parse("7-7-2020")},
                new Order {CustomerId = 4, SupermarketId = 2, OrderDate = DateTime.Parse("1-8-2020")},
                new Order {CustomerId = 5, SupermarketId = 3, OrderDate = DateTime.Parse("9-3-2019")},
                new Order {CustomerId = 6, SupermarketId = 3, OrderDate = DateTime.Parse("12-12-2020")},
            };
            foreach (Order order in orders)
                context.Orders.Add(order);
            context.SaveChanges();

            OrderDetail[] ordersDetails = new OrderDetail[]
            {
                new OrderDetail {OrderId = 1, ProductId = 1, Quantity = 2},
                new OrderDetail {OrderId = 1, ProductId = 4, Quantity = 9},
                new OrderDetail {OrderId = 1, ProductId = 5, Quantity = 7},
                new OrderDetail {OrderId = 2, ProductId = 2, Quantity = 1},
                new OrderDetail {OrderId = 3, ProductId = 3, Quantity = 2},
                new OrderDetail {OrderId = 4, ProductId = 4, Quantity = 5},
                new OrderDetail {OrderId = 5, ProductId = 5, Quantity = 11},
                new OrderDetail {OrderId = 5, ProductId = 7, Quantity = 2},
                new OrderDetail {OrderId = 6, ProductId = 6, Quantity = 4},
                new OrderDetail {OrderId = 7, ProductId = 3, Quantity = 6},
                new OrderDetail {OrderId = 7, ProductId = 7, Quantity = 2},
            };
            foreach (OrderDetail orderDetails in ordersDetails)
                context.OrderDetails.Add(orderDetails);
            context.SaveChanges();
        }
    }
}
