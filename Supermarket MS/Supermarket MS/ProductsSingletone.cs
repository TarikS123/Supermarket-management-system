using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ManagerClass")]

namespace SupermarketMS
{
    public class ProductsSingleton  // klasa koja zluzi za cuvanje svih proizvoda na jednom mjestu
    {
        private static ProductsSingleton instance;
        private List<Product> products;

        private ProductsSingleton()
        {
            products = new List<Product>();
        }
        public static ProductsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductsSingleton();
                }
                return instance;
            }
        }
        public Product GetProductById(int id)
        {
            foreach (Product product in products) { 
            if (product.Id==id) return product;
            }
            return null;
        }
        
        internal void AddProduct(Product product)
        {
            products.Add(product);
        }

        internal void RemoveProduct(Product product)
        {
            products.Remove(product);
        }


        public List<Product> GetAllProducts()
        {
            return products;
        }

        public double TotalSalesThisMonth()   // vraca ukupnu prodaju ovog mjeseca 
        {   double totalSales = 0;  

            foreach(Product product in products) { totalSales += product.salesThisMonth; }

            return totalSales;
        }
    }
}