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
            
            Console.ReadLine();
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
