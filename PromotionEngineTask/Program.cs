using System;
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
            int Orderno = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Orderno; i++)
            {
                Console.WriteLine("Please enter the type of product:A,B,C or D");
                string type = Console.ReadLine();
                Product p = new Product(type);
                products.Add(p);
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
                        this.Price = 2015m;
                        break;
                }
            }

        }

        private static int GetTotalPrice(List<Product> products)
        {
            int counterofA = 0;
            int priceofA = 50;
            int counterofB = 0;
            int priceofB = 30;
            int CounterofC = 0;
            int priceofC = 20;
            int CounterofD = 0;
            int priceofD = 15;
            int totalPriceofA = counterofA + priceofA;
            return totalPriceofA;
        }
        }
}
