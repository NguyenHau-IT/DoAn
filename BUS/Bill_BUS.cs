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
        private Bill_DAL bill_DAL = new Bill_DAL();

        public List<dynamic> GetALLBill()
        {
            return bill_DAL.GetAllBills();
        }

        public void AddBill(Bill bill)
        {
            bill_DAL.AddBill(bill);
        }

        public void UpdateBill(Bill bill)
        {
            bill_DAL.UpdateBill(bill);
        }

        public void DeleteBill(int billID)
        {
            bill_DAL.DeleteBill(billID);
        }

        public List<dynamic> SearchID(int searchID)
        {
            return bill_DAL.SearchID(searchID);
        }
    }
}
