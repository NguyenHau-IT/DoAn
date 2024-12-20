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
        private OrderDetail_DAL orderDetail_DAL = new OrderDetail_DAL();

        public List<OrderDetail> GetALLOrderDetails()
        {
            return orderDetail_DAL.GetAllOrderDetails();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetail_DAL.AddOrderDetail(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            orderDetail_DAL.UpdateOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(int orderDetailID)
        {
            orderDetail_DAL.DeleteOrderDetail(orderDetailID);
        }
    }
}
