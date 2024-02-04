using Mysqlx.Crud;

namespace SupermarketMS
{
    public class OrderSingleton   // klasa koja vodi evidencije o narudzbama. vec smo napravili da kupac moze napraviti narudzbu.
    {                             // ova klasa omogucuje da kupac moze napraviti vise narudzbi i da pri tome ostavi trag
        private static OrderSingleton instance;
        private List<MyOrder> orders;

        private OrderSingleton()
        {
            orders = new List<MyOrder>();
        }

        public static OrderSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderSingleton();
                }
                return instance;
            }
        }

        internal void AddOrder(MyOrder order)
        {
            orders.Add(order);
        }

        public List<MyOrder> GetAllOrders()
        {
            return orders;
        }

        public MyOrder FindOrderById(int orderId)
        {
            foreach (MyOrder order in orders)
            {
                if (order.OrderID == orderId)
                {
                    return order;
                }
            }
            return null; 
        }
    }

}
