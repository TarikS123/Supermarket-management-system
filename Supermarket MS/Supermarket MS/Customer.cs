namespace SupermarketMS
{
    public class Customer // moze praviti narudzbe i otkazivati ih
    {
        private int CustomerID { get; }
        private static int currid = 0;
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
        private string PhoneNumber { get; set; }
        private string Address { get; set; }

        
        public Customer( string firstName, string lastName, string email, string phoneNumber, string address)
        {
            CustomerID = currid++;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void MakeOrder(MyOrder order) {
        
            OrderSingleton.Instance.AddOrder(order);
        
        }
        public void CancelOrder(MyOrder order)
        {
            OrderSingleton.Instance.GetAllOrders().Remove(order);
        }


    }

}