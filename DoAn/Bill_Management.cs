using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Bill_Management : Form
    {
        private Bill_BUS bill_BUS = new Bill_BUS();

        private string selectedBillId = "";

        private Order_BUS order_BUS = new Order_BUS();

        public Bill_Management()
        {
            InitializeComponent();
        }

        public void loadcmbOD()
        {
            var orderID = order_BUS.GetALLOrders();

            if (orderID != null && orderID.Any())
            {
                cmbOD.DataSource = orderID;
                cmbOD.DisplayMember = "OrderID";
                cmbOD.ValueMember = "OrderID";
            }

        }

        public  void loadcmb()
        {
            cmbStatus.DataSource = new List<string> { "Đã thanh toán", "Chưa thanh toán"};
        }

        public void loadData()
        {
            var bills = bill_BUS.GetALLBill();
            dgvBill.DataSource = bills;

            dgvBill.Columns["BillID"].HeaderText = "Mã hoá đơn";
            dgvBill.Columns["OrderDetailID"].HeaderText = "Mã order";
            dgvBill.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";
            dgvBill.Columns["PaymentStatus"].HeaderText = "Trạng thái thanh toán";
            dgvBill.Columns["Total"].HeaderText = "Tổng";
        }

        private void Bill_Management_Load(object sender, EventArgs e)
        {
            loadData();
            loadcmbOD();
            loadcmb();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBillID.Text) || !int.TryParse(txtBillID.Text, out int billID))
                {
                    MessageBox.Show("BillID phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbOD.Text) || !int.TryParse(cmbOD.Text, out int orderDetailID))
                {
                    MessageBox.Show("OrderDetailID phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTotal.Text) || !int.TryParse(txtTotal.Text, out int total))
                {
                    MessageBox.Show("Total phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbStatus.SelectedValue.ToString() == null)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (bill_BUS == null)
                {
                    MessageBox.Show("bill_BUS chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var bill = new Bill
                {
                    BillID = billID,
                    OrderDetailID = orderDetailID,
                    PaymentDate = dtpDate.Value,
                    PaymentStatus = cmbStatus.SelectedValue.ToString(),
                    Total = total
                };

                bill_BUS.AddBill(bill);

                try
                {
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                var selectedRow = dgvBill.SelectedRows[0];
                int billId = (int)selectedRow.Cells["BillID"].Value;

                var result = MessageBox.Show("Bạn có chắc chắn muốn xoá hoá đơn này?", "Xoá hoá đơn", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bill_BUS.DeleteBill(billId);

                        MessageBox.Show("Đã xoá sản phẩm!");
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xoá sản phẩm: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xoá.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBillID.Text, out int billID))
            {
                MessageBox.Show("BillID phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(cmbOD.Text, out int orderDetailID))
            {
                MessageBox.Show("OrderDetailID phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtTotal.Text, out int total))
            {
                MessageBox.Show("Total phải là số thập phân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var bill = new Bill
            {
                BillID = billID,
                OrderDetailID = orderDetailID,
                PaymentDate = dtpDate.Value,
                PaymentStatus = cmbStatus.SelectedValue.ToString(),
                Total = total
            };

            bill_BUS.UpdateBill(bill);

            MessageBox.Show("Cập nhật sản phẩm thành công!");

            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string inputText = txtSearchID.Text;

            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Hãy nhập mã hoá đơn!", "Thông báo");
                return;
            }

            if (!int.TryParse(inputText, out int searchID))
            {
                MessageBox.Show("Vui lòng nhập một mã hoá đơn hợp lệ (số nguyên)!", "Thông báo");
                return;
            }

            var bills = bill_BUS.SearchID(searchID);
            if (bills != null && bills.Count > 0)
            {
                dgvBill.DataSource = bills;
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn với mã sản phẩm này.", "Thông báo");
            }
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBill.Rows[e.RowIndex];

                selectedBillId = row.Cells["BillID"].Value?.ToString() ?? string.Empty;
                txtBillID.Text = selectedBillId;
                cmbOD.Text = row.Cells["OrderDetailID"].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(row.Cells["PaymentDate"].Value?.ToString(), out DateTime paymentDate))
                {
                    dtpDate.Value = paymentDate;
                }
                else
                {
                    MessageBox.Show("Ngày thanh toán không hợp lệ.", "Thông báo");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCalculateTotal_Click(object sender, EventArgs e)
        {
            int orderId;
            if (int.TryParse(cmbOD.SelectedValue.ToString(), out orderId))
            {
                int total = bill_BUS.CalculateTotal(orderId);
                txtTotal.Text = total.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một OrderID hợp lệ.");
            }
        }
    }
}
