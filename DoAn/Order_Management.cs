﻿using BUS;
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
    public partial class Order_Management : Form
    {
        private Order_BUS order_BUS = new Order_BUS();

        private string selectedOrderId = "";

        public Order_Management()
        {
            InitializeComponent();
        }

        private CF_Table_BUS table_BUS = new CF_Table_BUS();

        private void LoadTable()
        {
            var table = table_BUS.GetALLTables();

            if (table != null && table.Any())
            {
                cmbTable.DataSource = table;
                cmbTable.DisplayMember = "TableName";
                cmbTable.ValueMember = "TableID";
            }
        }

        private void LoadStatus()
        {
            List<string> statusList = new List<string> { "Đã thanh toán", "Chưa thanh toán"};
            cmbStatus.DataSource = statusList;
        }

        public void loadData()
        {
            var order = order_BUS.GetALLOrders();
            dgvOrders.DataSource = order;

            dgvOrders.Columns["OrderID"].HeaderText = "Mã mua hàng";
            dgvOrders.Columns["DateCheckIn"].HeaderText = "Giờ vào";
            dgvOrders.Columns["DateCheckOut"].HeaderText = "Giờ về";
            dgvOrders.Columns["Status"].HeaderText = "Trạng thái";
            dgvOrders.Columns["TableName"].HeaderText = "Tên bàn";

            dgvOrders.Columns["DateCheckIn"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm";
            dgvOrders.Columns["DateCheckOut"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm";
        }

        private void Order_Management_Load(object sender, EventArgs e)
        {
            loadData();
            LoadTable();
            LoadStatus();

            dtpDateCheckOut.Format = DateTimePickerFormat.Custom;
            dtpDateCheckOut.CustomFormat = "dd-MM-yyyy HH:mm"; // Hiển thị chỉ giờ và phút
            dtpDateCheckOut.ShowCheckBox = true;
            dtpDateCheckOut.Checked = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime? selectedTime = dtpDateCheckOut.Checked ? dtpDateCheckOut.Value : (DateTime?)null;

            if (selectedTime == null)
            {
                var order = new Order
                {
                    OrderID = int.Parse(txtID.Text),
                    DateCheckIn = dtpDateCheckIn.Value,
                    Status = cmbStatus.SelectedValue.ToString(),
                    TableID = cmbTable.SelectedValue.ToString()
                };
                order_BUS.AddOrder(order);
                MessageBox.Show("Thêm order thành công!");
                loadData();
            }
            else
            {
                var order = new Order
                {
                    OrderID = int.Parse(txtID.Text),
                    DateCheckIn = dtpDateCheckIn.Value,
                    DateCheckOut = dtpDateCheckOut.Value,
                    Status = cmbStatus.SelectedValue.ToString(),
                    TableID = cmbTable.SelectedValue.ToString()
                };
                order_BUS.AddOrder(order);
                MessageBox.Show("Thêm order thành công!");
                loadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                var order = new Order
                {
                    OrderID = int.Parse(txtID.Text),
                    DateCheckIn = dtpDateCheckIn.Value,
                    DateCheckOut = dtpDateCheckOut.Value,
                    Status = cmbStatus.SelectedValue.ToString(),
                    TableID = cmbTable.SelectedValue.ToString()
                };

                order_BUS.UpdateOrder(order);

                MessageBox.Show("Cập nhật mua hàng thành công!");

                loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrders.SelectedRows[0];

                if (int.TryParse(selectedRow.Cells["OrderID"].Value?.ToString(), out int orderID))
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xoá mua hàng này?", "Xoá mua hàng", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            order_BUS.DeleteOrder(orderID);

                            MessageBox.Show("Đã xoá mua hàng!");
                            loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xoá mua hàng: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("OrderID không hợp lệ. Vui lòng kiểm tra dữ liệu!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mua hàng để xoá.");
            }

        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];

                txtID.Text = row.Cells["OrderID"].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(row.Cells["DateCheckIn"].Value?.ToString(), out DateTime dateCheckIn))
                {
                    dtpDateCheckIn.Checked = true;
                    dtpDateCheckIn.Value = dateCheckIn;
                    dtpDateCheckIn.CustomFormat = "dd-MM-yyyy HH:mm";
                }
                else
                {
                    dtpDateCheckIn.Checked = false;
                    dtpDateCheckIn.CustomFormat = " ";
                }

                if (DateTime.TryParse(row.Cells["DateCheckOut"].Value?.ToString(), out DateTime dateCheckOut))
                {
                    dtpDateCheckOut.Checked = true;
                    dtpDateCheckOut.Value = dateCheckOut;
                    dtpDateCheckOut.CustomFormat = "dd-MM-yyyy HH:mm";
                }
                else
                {
                    dtpDateCheckOut.Checked = false;
                    dtpDateCheckOut.CustomFormat = " ";
                }

                cmbStatus.Text = row.Cells["Status"].Value?.ToString() ?? string.Empty;
                cmbTable.Text = row.Cells["TableName"].Value?.ToString() ?? string.Empty;
            }

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            OrderDetail_Management orderDetail_Management = new OrderDetail_Management();
            orderDetail_Management.Show();
        }

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {

        }
    }
}
