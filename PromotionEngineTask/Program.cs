﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineTask
{
    public class Program
    {
        static void Main(string[] args)
        {          

            TestPromotion obj= new TestPromotion();
            obj.TestPromotionEngine();
        }

        public class TestPromotion
        {

            public void TestPromotionEngine()
            {
                //create list of promotions
                //we need to add information about Product's count
                Dictionary<String, int> d1 = new Dictionary<String, int>();
                d1.Add("A", 3);
                Dictionary<String, int> d2 = new Dictionary<String, int>();
                d2.Add("B", 2);
                Dictionary<String, int> d3 = new Dictionary<String, int>();
                d3.Add("C", 1);
                d3.Add("D", 1);

                List<Promotion> promotions = new List<Promotion>()
             {

                  new Promotion(1, d1, 130),

                  new Promotion(2, d2, 45),

                   new Promotion(3, d3, 30),

             };

                List<Order> orders = new List<Order>();


                Order order1 = new Order(1, new List<Product>() { new Product("A"), new Product("B"), new Product("C") });
                Order order2 = new Order(2, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("C") });
                Order order3 = new Order(3, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("D") });

                orders.AddRange(new Order[] { order1, order2, order3
        });

                //check if order meets promotion
                foreach (Order ord in orders)
                {
                    List<decimal> promoprices = promotions
                        .Select(promo => PromotionChecker.GetTotalPrice(ord, promo))
                        .ToList();
                    decimal origprice = ord.Products.Sum(x => x.Price);
                    decimal promoprice = promoprices.Sum();
                    Console.WriteLine($"OrderID: {ord.OrderID} => Original price: {origprice.ToString("0.00")} | Promotion Price: {promoprice.ToString("0.00")} | Total price: {(origprice - promoprice).ToString("0.00")}");
                }

                Console.ReadLine();
            }

        }
        public class Product
        {
            public string Id { get; set; }
            public decimal Price { get; set; }
            public Product(string id)
            {
                this.Id = id;
                switch (id)
                {
                    case "A":
                        this.Price = 50m;

                        break;
                    case "B":
                        this.Price = 30m;

                        break;
                    case "C":
                        this.Price = 20m;

                        break;
                    case "D":
                        this.Price = 15m;
                        break;
                }
            }
        }
        
        public class Promotion
        {
            public int PromotionID { get; set; }
            public Dictionary<string, int> ProductInfo { get; set; }
            public decimal PromoPrice { get; set; }

            public Promotion(int promID, Dictionary<string, int> prodInfo, decimal pprice)
            {
                this.PromotionID = promID;
                this.ProductInfo = prodInfo;
                this.PromoPrice = pprice;
            }
        }

        public class Order
        {
            public int OrderID { get; set; }
            public List<Product> Products { get; set; }

            public Order(int oid, List<Product> prods)
            {
                this.OrderID = oid;
                this.Products = prods;
            }
        }

        public static class PromotionChecker
        {
            //returns PromotionID and count of promotions
            public static decimal GetTotalPrice(Order ord, Promotion prom)
            {
                decimal d = 0M;
                //get count of promoted products in order
                var copp = ord.Products
                    .GroupBy(x => x.Id)
                    .Where(grp => prom.ProductInfo.Any(y => grp.Key == y.Key && grp.Count() >= y.Value))
                    .Select(grp => grp.Count())
                    .Sum();
                //get count of promoted products from promotion
                int ppc = prom.ProductInfo.Sum(kvp => kvp.Value);
                while (copp >= ppc)
                {
                    d += prom.PromoPrice;
                    copp -= ppc;
                }
                return d;
            }

        }
    }
}
