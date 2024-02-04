namespace SupermarketMS
{
    public class MyOrder  // klasa koja omogucava kupcu da pravi narudzbu
    {
        private static int currid=0;
        public int OrderID { get;  }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime? DeliveryDate { get; set; }
        
        public List<OrderItem> items {  get; set; }
       

        
        public MyOrder(Customer customer, string status, string deliveryAddress, DateTime? deliveryDate)
        {
            OrderID = currid++;
            OrderDate = DateTime.Now;
            Customer = customer;
            Status = status;
            DeliveryAddress = deliveryAddress;
            DeliveryDate = deliveryDate;
            items = new List<OrderItem>();
            
        }

        public void AddItem (Product item, double quantity)
        {
            items.Add(new OrderItem(item, quantity));

        }

        public void CalculateTotal() // izracuna koliko je ovaj proizvod generisao prodaje 
        {
            double total = 0;
            foreach(OrderItem item in items) { total += item.product.price * item.quantity; }
            this.TotalPrice = total;
            
        }
    }

    public class OrderItem // sluzi samo da bi mogao napraviti 1:many vezu tj da kupac moze kupiti vise jednog proizvoda a da ga ne cuvamo vise puta.
    {
        public Product product { get; set; }
        public double quantity { get; set; }

        public OrderItem(Product product, double quantity)
        {

            this.product = product;
            this.quantity = quantity;
        }
    }

    
}