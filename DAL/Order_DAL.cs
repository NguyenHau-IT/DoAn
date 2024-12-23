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
        public List<dynamic> GetAllOrders()
        {
            using (var context = new Cafe_Context())
            {
                var orders = from o in context.Orders
                             join t in context.CF_Table on o.TableID equals t.TableID
                             select new
                             {
                                 OrderID = o.OrderID,
                                 DateCheckIn = o.DateCheckIn,
                                 DateCheckOut = o.DateCheckOut,
                                 Status = o.Status,
                                 TableName = t.TableName
                             };

                return orders.ToList<dynamic>();
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
