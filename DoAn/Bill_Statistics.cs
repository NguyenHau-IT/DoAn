using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace DoAn
{
    public partial class Bill_Statistics : Form
    {
        Bill_BUS bill = new Bill_BUS();
        public Bill_Statistics()
        {
            InitializeComponent();

            cmbStyle.SelectedValue = 0;
        }

        private void Bill_Statistics_Load(object sender, EventArgs e)
        {
            loadcmb();

            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpTo.Format = DateTimePickerFormat.Custom;

            dtpFrom.CustomFormat = "dd - MM - yyyy";
            dtpTo.CustomFormat = "dd - MM - yyyy";
        }

        private void loadcmb()
        {
            cmbStyle.Items.Add("Thống kê theo ngày");
            cmbStyle.Items.Add("Thống kê theo tháng");
            cmbStyle.Items.Add("Thống kê theo năm");
        }

        private void loaddgv()
        {
            dgvThongKe.Columns["BillID"].HeaderText = "Mã hoá đơn";
            dgvThongKe.Columns["OrderID"].HeaderText = "Mã mua hàng";
            dgvThongKe.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";
            dgvThongKe.Columns["PaymentStatus"].HeaderText = "Trạng thái thanh toán";
            dgvThongKe.Columns["Total"].HeaderText = "Tổng cộng";

            dgvThongKe.Columns["PaymentDate"].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            List<object> bills;

            if (cmbStyle.SelectedIndex == 0)
            {
                // Thống kê theo ngày
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;
                bills = bill.GetBill(fromDate, toDate);
            }
            else if (cmbStyle.SelectedIndex == 1)
            {
                // Thống kê theo tháng
                int selectedMonth = dtpFrom.Value.Month;
                int selectedYear = dtpFrom.Value.Year;
                bills = bill.GetBillByMonth(selectedMonth, selectedYear);
            }
            else if (cmbStyle.SelectedIndex == 2)
            {
                // Thống kê theo năm
                int selectedYear = dtpFrom.Value.Year;
                bills = bill.GetBillByYear(selectedYear);
            }
            else
            {
                // Thống kê tất cả
                bills = bill.GetALLBill();
            }

            dgvThongKe.DataSource = bills; // Gán dữ liệu
            loaddgv();
        }
    }
}
