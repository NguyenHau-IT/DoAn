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

        private OrderDetail_BUS orderDetail_BUS = new OrderDetail_BUS();

        public Bill_Management()
        {
            InitializeComponent();
        }

        public void loadcmbODID()
        {
            var orderdetailID = orderDetail_BUS.GetALLOrderDetails();

            if (orderdetailID != null && orderdetailID.Any())
            {
                cmbODID.DataSource = orderdetailID;
                cmbODID.DisplayMember = "OrderDetailID";
                cmbODID.ValueMember = "OrderDetailID";
            }

        }

        public void loadData()
        {
            var bills = bill_BUS.GetALLBill();
            dgvBill.DataSource = bills;

            dgvBill.Columns["BillID"].HeaderText = "Mã hoá đơn";
            dgvBill.Columns["OrderDetailID"].HeaderText = "Mã chi tiết order";
            dgvBill.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";
            dgvBill.Columns["PaymentStatus"].HeaderText = "Trạng thái thanh toán";
            dgvBill.Columns["Total"].HeaderText = "Tổng";

            cmbStatus.Items.Add("Đã thanh toán");
            cmbStatus.Items.Add("Chưa thanh toán");
        }

        private void Bill_Management_Load(object sender, EventArgs e)
        {
            loadData();
            loadcmbODID();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra và chuyển đổi dữ liệu đầu vào
                if (!int.TryParse(txtBillID.Text, out int billID))
                {
                    MessageBox.Show("BillID phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(cmbODID.Text, out int orderDetailID))
                {
                    MessageBox.Show("OrderDetailID phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtTotal.Text, out decimal total))
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

                bill_BUS.AddBill(bill);

                loadData();
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

            if (!int.TryParse(cmbODID.Text, out int orderDetailID))
            {
                MessageBox.Show("OrderDetailID phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtTotal.Text, out decimal total))
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
                cmbODID.Text = row.Cells["OrderDetailID"].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(row.Cells["PaymentDate"].Value?.ToString(), out DateTime paymentDate))
                {
                    dtpDate.Value = paymentDate;
                }
                else
                {
                    MessageBox.Show("Ngày thanh toán không hợp lệ.", "Thông báo");
                }

                cmbStatus.Items.Clear();
                string status = row.Cells["PaymentStatus"]?.Value?.ToString() ?? string.Empty;
                cmbStatus.Items.Add(status);
                cmbStatus.SelectedIndex = 0;
                txtTotal.Text = ((decimal)row.Cells["Total"].Value).ToString();
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

    }
}
