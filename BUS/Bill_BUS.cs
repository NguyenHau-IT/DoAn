using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BUS
{
    public class Bill_BUS
    {

        public List<dynamic> GetALLBill()
        {
            using (var context = new Cafe_Context())
            {
                var bills = from b in context.Bills
                            join o in context.Orders on b.OrderID equals o.OrderID
                            select new
                            {
                                BillID = b.BillID,
                                OrderID = o.OrderID,
                                PaymentDate = b.PaymentDate,
                                PaymentStatus = b.PaymentStatus,
                                Total = b.Total
                            };

                return bills.ToList<dynamic>();
            }
        }

        public void AddBill(Bill bill)
        {
            using (var context = new Cafe_Context())
            {
                context.Bills.Add(bill);
                context.SaveChanges();
            }
        }

        public void UpdateBill(Bill bill)
        {
            using (var context = new Cafe_Context())
            {
                var existingBills = context.Bills.Find(bill.BillID);
                if (existingBills != null)
                {
                    existingBills.OrderID = bill.OrderID;
                    existingBills.PaymentDate = bill.PaymentDate;
                    existingBills.PaymentStatus = bill.PaymentStatus;
                    existingBills.Total = bill.Total;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteBill(int billID)
        {
            using (var context = new Cafe_Context())
            {
                var bill = context.Bills.Find(billID);
                if (bill != null)
                {
                    context.Bills.Remove(bill);
                    context.SaveChanges();
                }
            }
        }

        public List<dynamic> SearchID(int searchID)
        {
            using (var context = new Cafe_Context())
            {
                var bills = from b in context.Bills
                            join o in context.Orders on b.OrderID equals o.OrderID
                            where b.BillID == searchID
                            select new
                            {
                                BillID = b.BillID,
                                OrderID = o.OrderID,
                                PaymentDate = b.PaymentDate,
                                PaymentStatus = b.PaymentStatus,
                                Total = b.Total
                            };

                return bills.ToList<dynamic>();
            }
        }

        public int CalculateTotal(int orderID)
        {
            using (var context = new Cafe_Context())
            {
                var total = (from od in context.OrderDetails
                             join ps in context.ProductSizes on od.ProductSizeID equals ps.ProductSizeID
                             join p in context.Product on ps.ProductID equals p.ProductID
                             join s in context.Sizes on ps.SizeName equals s.SizeName
                             where od.OrderID == orderID
                             select new
                             {
                                 ProductPrice = p.Price,
                                 SizePrice = s.SizePrice,
                                 Quantity = od.Quantity
                             })
                     .Sum(x => (x.ProductPrice + (x.SizePrice ?? 0)) * x.Quantity);

                return (int)total;
            }
        }
    }
}
