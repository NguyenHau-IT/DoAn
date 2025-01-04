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

        private int selectedBillId = 0;

        private Order_BUS order_BUS = new Order_BUS();
        
        private CF_Table_BUS table_BUS = new CF_Table_BUS();
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
            dgvBill.Columns["OrderID"].HeaderText = "Mã order";
            dgvBill.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";
            dgvBill.Columns["PaymentStatus"].HeaderText = "Trạng thái thanh toán";
            dgvBill.Columns["Total"].HeaderText = "Tổng";

            dgvBill.Columns["PaymentDate"].DefaultCellStyle.Format = " dd-MM-yyyy";
        }

        private void Bill_Management_Load(object sender, EventArgs e)
        {
            loadData();
            loadcmbOD();
            loadcmb();
            cmbStatus.SelectedIndex = 1;
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

                if (string.IsNullOrWhiteSpace(txtTotal.Text) || !decimal.TryParse(txtTotal.Text, out decimal total))
                {
                    MessageBox.Show("Total phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbStatus.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var bill = new Bill
                {
                    BillID = billID,
                    OrderID = orderDetailID,
                    PaymentDate = dtpDate.Value,
                    PaymentStatus = cmbStatus.SelectedValue.ToString(),
                    Total = total
                };

                bill_BUS.AddBill(bill);

                // Nếu trạng thái thanh toán là "Đã thanh toán", cập nhật Order và Table
                if (cmbStatus.SelectedValue.ToString() == "Đã thanh toán")
                {
                    var order = order_BUS.GetOrderById(orderDetailID);
                    if (order != null)
                    {
                        order.Status = "Đã thanh toán";
                        order_BUS.UpdateOrder(order);

                        var table = table_BUS.GetTableById(order.TableID);
                        if (table != null)
                        {
                            table.Status = "Trống";
                            table_BUS.UpdateTable(table);
                        }
                    }
                }

                MessageBox.Show("Thêm hoá đơn thành công!");
                loadData();

                txtBillID.Clear();
                txtTotal.Clear();
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

                if (selectedRow.Cells["BillID"].Value != DBNull.Value && int.TryParse(selectedRow.Cells["BillID"].Value.ToString(), out int billID))
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xoá hoá đơn này?", "Xoá hoá đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Lấy thông tin Order trước khi xóa hóa đơn
                            var bill = bill_BUS.GetBillById(billID);
                            if (bill != null)
                            {
                                var order = order_BUS.GetOrderById(bill.OrderID);
                                if (order != null)
                                {
                                    // Cập nhật trạng thái Order và Table
                                    order.Status = "Chưa thanh toán";
                                    order_BUS.UpdateOrder(order);

                                    var table = table_BUS.GetTableById(order.TableID);
                                    if (table != null)
                                    {
                                        table.Status = "Có khách";
                                        table_BUS.UpdateTable(table);
                                    }
                                }
                            }

                            // Xoá hóa đơn
                            bill_BUS.DeleteBill(billID);

                            MessageBox.Show("Đã xoá hoá đơn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xoá hoá đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị BillID không hợp lệ hoặc không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hoá đơn để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
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

                if (!decimal.TryParse(txtTotal.Text, out decimal total))
                {
                    MessageBox.Show("Total phải là số thập phân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var bill = new Bill
                {
                    BillID = billID,
                    OrderID = orderDetailID,
                    PaymentDate = dtpDate.Value,
                    PaymentStatus = cmbStatus.SelectedValue.ToString(),
                    Total = total
                };

                bill_BUS.UpdateBill(bill);

                // Nếu trạng thái thanh toán là "Đã thanh toán", cập nhật Order và Table
                if (cmbStatus.SelectedValue.ToString() == "Đã thanh toán")
                {
                    var order = order_BUS.GetOrderById(orderDetailID);
                    if (order != null)
                    {
                        order.Status = "Đã thanh toán";
                        order_BUS.UpdateOrder(order);

                        var table = table_BUS.GetTableById(order.TableID);
                        if (table != null)
                        {
                            table.Status = "Trống";
                            table_BUS.UpdateTable(table);
                        }
                    }
                }

                MessageBox.Show("Cập nhật hoá đơn thành công!");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    selectedBillId = Convert.ToInt32(row.Cells["BillID"].Value);
                    txtBillID.Text = selectedBillId.ToString(); // Gán giá trị int vào TextBox

                cmbOD.Text = row.Cells["OrderID"].Value?.ToString() ?? string.Empty;

                txtTotal.Text = row.Cells["Total"].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(row.Cells["PaymentDate"].Value?.ToString(), out DateTime paymentDate))
                {
                    dtpDate.Value = paymentDate;
                }
                else
                {
                    MessageBox.Show("Ngày thanh toán không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpDate.Value = DateTime.Now;
                }
                dgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
