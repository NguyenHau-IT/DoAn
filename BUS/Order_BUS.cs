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

        public List<dynamic> GetALLOrders()
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
                                 TableName = t.TableName,
                                 TableID = o.TableID
                             };

                return orders.OrderBy(o =>o.OrderID).ToList<dynamic>();
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

        public List<dynamic> SearchOrdersByDateLight(DateTime fromDate, DateTime toDate)
        {
            using (var context = new Cafe_Context())
            {
                var order = from o in context.Orders
                            join t in context.CF_Table on o.TableID equals t.TableID
                             where o.DateCheckIn >= fromDate && o.DateCheckIn <= toDate
                             select new
                             {
                                 OrderID = o.OrderID,
                                 DateCheckIn = o.DateCheckIn,
                                 DateCheckOut = o.DateCheckOut,
                                 Status = o.Status,
                                 TableName = t.TableName
                             };

                return order.ToList<dynamic>();
            }
        }

        public Order GetOrderById(int orderId)
        {
            try
            {
                using (var db = new Cafe_Context())
                {
                    return db.Orders.FirstOrDefault(o => o.OrderID == orderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin Order với ID {orderId}: {ex.Message}");
            }
        }

    }
}
