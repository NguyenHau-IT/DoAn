using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class OrderDetail_BUS
    {

        public List<OrderDetail> GetALLOrderDetails()
        {
            using (var context = new Cafe_Context())
            {
                return context.OrderDetails.OrderBy(o => o.OrderDetailID).ToList();
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
                    existingOrderDetails.OrderID = orderDetail.OrderID;
                    existingOrderDetails.Quantity = orderDetail.Quantity;
                    existingOrderDetails.ProductSizeID = orderDetail.ProductSizeID;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteOrderDetail(int orderDetailID)
        {
            using (var context = new Cafe_Context())
            {
                var OrderDetail = context.OrderDetails.Find(orderDetailID);
                if (OrderDetail != null)
                {
                    context.OrderDetails.Remove(OrderDetail);
                    context.SaveChanges();
                }
            }
        }
    }
}
