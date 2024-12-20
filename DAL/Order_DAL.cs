using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order_DAL
    {
        public List<Order> GetAllOrders()
        {
            using (var context = new Cafe_Context())
            {
                return context.Orders.ToList();
            }
        }

        public void AddOrder(Order order)
        {
            using (var context = new Cafe_Context())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var context = new Cafe_Context())
            {
                var existingOrders = context.Orders.Find(order.OrderID);
                if (existingOrders != null)
                {
                    existingOrders.OrderID = order.OrderID;
                    existingOrders.DateCheckIn = order.DateCheckIn;
                    existingOrders.DateCheckOut = order.DateCheckOut;
                    existingOrders.Status = order.Status;
                    existingOrders.TableID = order.TableID;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteOrder(int orderID)
        {
            using (var context = new Cafe_Context())
            {
                var order = context.Orders.Find(orderID);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }
    }
}
