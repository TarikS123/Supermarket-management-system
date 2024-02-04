
namespace SupermarketMS
{
    public class Product  // klasa koja cuva informacije o dostupnim proizvodima
    {
        public int Id { get; }
        private static int currid = 0;
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal discount { get; set; }
        public Supplier supplier { get; set; }
        public ProductLocation LocationInStore { get; }
        public ProductLocation LocationinStore {  get; set; }
        public double salesThisMonth  {  get; set; }


        public Product(string name, string description, string category, double quantity,
        double price, int quantityInStock, DateTime? expiryDate, decimal discount, Supplier supplierID, ProductLocation locationInStore)
        {
            this.Id = currid++;
            this.name = name;
            this.description = description;
            this.category = category;
            this.quantity = quantity;
            this.price = price;
            this.QuantityInStock = quantityInStock;
            ExpiryDate = expiryDate;
            this.discount = discount;
            this.supplier = supplier;
            this.LocationInStore = locationInStore;
            this.salesThisMonth = 0;
            CalculateOrdersThisMonth();

        }

        public void CalculateOrdersThisMonth()    // funkcija koja vraca ukupnu prodaju proizvoda ovog mjeseca 
        {
            double sales = 0;
            List<MyOrder> lista =OrderSingleton.Instance.GetAllOrders();
            
            foreach (MyOrder order in lista)
            {
                foreach(OrderItem oi in order.items)if (oi.product.Id == this.Id && order.OrderDate>=DateTime.Now.AddMonths(-0))
                    {
                        sales += this.price * oi.quantity;
                    }

            }
            
            this.salesThisMonth = sales;
        }

        public void Restock(double quantity)
        {
            this.quantity += quantity;
        }

        public void Sell(double quantity)
        {
            this.quantity -= quantity;  
        }

    }

    

    public class ProductLocation   // pomocna klasa kako bi mogli voditi evidenciju o lokaciji proizvoda.
    {
        int lane {  get; set; }
        int shelf { get; set; }

        public ProductLocation(int lane, int shelf) {
                 this.lane = lane;
                this.shelf = shelf;
        }
    }
}