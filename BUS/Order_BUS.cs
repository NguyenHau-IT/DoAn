using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Order_BUS
    {
        private Order_DAL order_DAL = new Order_DAL();

        public List<dynamic> GetALLOrders()
        {
            return order_DAL.GetAllOrders();
        }

        public void AddOrder(Order order)
        {
            order_DAL.AddOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            order_DAL.UpdateOrder(order);
        }

        public void DeleteOrder(int orderID)
        {
            order_DAL.DeleteOrder(orderID);
        }
    }
}
