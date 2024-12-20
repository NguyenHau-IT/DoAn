﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Bill_DAL
    {

        public List<dynamic> GetAllBills()
        {
            using (var context = new Cafe_Context())
            {
                var bills = from b in context.Bills
                            join o in context.OrderDetails on b.OrderDetailID equals o.OrderDetailID
                            select new 
                            {
                                BillID = b.BillID,
                                OrderDetailID = o.OrderDetailID,
                                PaymentDate = b.PaymentDate,
                                PaymentStatus = b.PaymentStatus,
                                Total = b.Total
                            };

                return bills.ToList<dynamic>();
            }
        }


        public void AddBill(Bill Bill)
        {
            using (var context = new Cafe_Context())
            {
                context.Bills.Add(Bill);
                context.SaveChanges();
            }
        }

        public void UpdateBill(Bill Bill)
        {
            using (var context = new Cafe_Context())
            {
                var existingBills = context.Bills.Find(Bill.BillID);
                if (existingBills != null)
                {
                    existingBills.BillID = Bill.BillID;
                    existingBills.OrderDetailID = Bill.OrderDetailID;
                    existingBills.PaymentDate = Bill.PaymentDate;
                    existingBills.PaymentStatus = Bill.PaymentStatus;
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
                            join o in context.OrderDetails on b.OrderDetailID equals o.OrderDetailID
                            where b.BillID == searchID
                            select new
                            {
                                BillID = b.BillID,
                                OrderDetailID = o.OrderDetailID,
                                PaymentDate = b.PaymentDate,
                                PaymentStatus = b.PaymentStatus,
                                Total = b.Total
                            };

                return bills.ToList<dynamic>();
            }
        }
    }
}