using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetail_DAL
    {
        public List<OrderDetail> GetAllOrderDetails()
        {
            using (var context = new Cafe_Context())
            {
                return context.OrderDetails.ToList();
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            using (var context = new Cafe_Context())
            {
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using (var context = new Cafe_Context())
            {
                var existingOrderDetails = context.OrderDetails.Find(orderDetail.OrderDetailID);
                if (existingOrderDetails != null)
                {
                    existingOrderDetails.OrderDetailID = orderDetail.OrderDetailID;
                    existingOrderDetails.OrderID = orderDetail.OrderID;
                    existingOrderDetails.Quantity = orderDetail.Quantity;
                    existingOrderDetails.ProductSizeID = orderDetail.ProductSizeID;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteOrderDetail(int OrderDetailID)
        {
            using (var context = new Cafe_Context())
            {
                var OrderDetail = context.OrderDetails.Find(OrderDetailID);
                if (OrderDetail != null)
                {
                    context.OrderDetails.Remove(OrderDetail);
                    context.SaveChanges();
                }
            }
        }
    }
}
