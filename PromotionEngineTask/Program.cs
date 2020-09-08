﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("Please enter total number of order:");
            int orderNo = 0;

            while (!int.TryParse(Console.ReadLine(), out orderNo))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
                Console.WriteLine("Please Enter an ID number to search for:");
            }

            ProductService productService = new ProductService();
            for (int i = 0; i < orderNo; i++)
            {
                Console.WriteLine("Please enter the type of product:A,B,C or D");
                string type = Console.ReadLine();
                Product product = new Product();
                product.Id = type;
                

                productService.GetPriceByType(product);
                products.Add(product);
            }
             int totalPrice = productService.GetTotalPrice(products);
             Console.WriteLine(totalPrice);
            Console.ReadLine();
        }

        public class Product
        {
            public string Id { get; set; }
            public decimal Price { get; set; }
        }

        public interface IProductService
        {
            void GetPriceByType(Product product);
            int GetTotalPrice(List<Product> products);
        }

        public class ProductService : IProductService
        {
            public void GetPriceByType(Product product)
            {
                switch (product.Id)
                {
                    case "A":
                        product.Price = 50m;

                        break;
                    case "B":
                        product.Price = 30m;

                        break;
                    case "C":
                        product.Price = 20m;

                        break;
                    case "D":
                        product.Price = 2015m;
                        break;
                }
            }

            public int GetTotalPrice(List<Product> products)
            {
                int counterOfA = 0;
                int priceOfA = 50;
                int counterOfB = 0;
                int priceOfB = 30;
                int counterOfC = 0;
                int priceOfC = 20;
                int counterOfD = 0;
                int priceOfD = 15;

                foreach (Product pr in products)
                {
                    switch (pr.Id)
                    {
                        case "A":
                        case "a":
                            counterOfA += 1;
                            break;
                        case "B":
                        case "b":
                            counterOfB += 1;
                            break;
                        case "C":
                        case "c":
                            counterOfC += 1;
                            break;
                        case "D":
                        case "d":
                            counterOfD += 1;
                            break;
                    }
                }
                int totalPriceOfA = (counterOfA / 3) * 130 + (counterOfA % 3 * priceOfA);
                int totalPriceOfB = (counterOfB / 2) * 45 + (counterOfB % 2 * priceOfB);
                int totalPriceOfC = (counterOfC * priceOfC);
                int totalPriceOfD = (counterOfD * priceOfD);
                return totalPriceOfA + totalPriceOfB + totalPriceOfC + totalPriceOfD;
            }
        }

    }
}
