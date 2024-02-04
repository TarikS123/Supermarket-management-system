namespace SupermarketMS
{
    public class Supplier   // klasa za cuvanje informacija o dobavljacu proizvoda. dobavljac moze samo dodati proizod u nas singleton
    {

        private int SupplierID { get; set; }
        private static int currid = 0;
        private string Name { get; set; }
        private string ContactNumber { get; set; }
        private string Email { get; set; }
        private string Address { get; set; }
        private List<Product> Products { get; set; }
        private string PaymentTerms { get; set; }

        public Supplier(
                        string name,
                        string contactNumber,
                        string email,
                        string address
                       )
        {
            SupplierID =currid++;
            Name = name;
            ContactNumber = contactNumber;
            Email = email;
            Address = address;
            Products = new List<Product>(); 
        }

        public void AddProduct(Product product)
        {
            ProductsSingleton.Instance.AddProduct(product);
            Products.Add(product);  
        }


    }
}