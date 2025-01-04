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
    public partial class OrderDetail_Management : Form
    {
        OrderDetail_BUS orderDetail_BUS = new OrderDetail_BUS();

        private int selectedOrderDTId = -1 ;

        public OrderDetail_Management()
        {
            InitializeComponent();

            txtID.Enabled = false;
        }

        public void loadData()
        {
            var orderDT = orderDetail_BUS.GetALLOrderDetails();
            dgvOrderDetails.DataSource = orderDT;

            dgvOrderDetails.Columns["OrderDetailID"].HeaderText = "Mã tt đặt hàng";
            dgvOrderDetails.Columns["ProductSizeID"].HeaderText = "Mã thông tin SP";
            dgvOrderDetails.Columns["OrderID"].HeaderText = "Mã đặt hàng";
            dgvOrderDetails.Columns["Quantity"].HeaderText = "Số lượng";
        }

        Order_BUS order_BUS = new Order_BUS();

        private void loadOrder()
        {
            var order = order_BUS.GetALLOrders();

            if (order != null && order.Any())
            {
                cmbOrder.DataSource = order;
                cmbOrder.DisplayMember = "OrderID";
                cmbOrder.ValueMember = "OrderID";
            }
        }

        Product_Size_BUS product_Size_BUS = new Product_Size_BUS();

        private void loadProductSize()
        {
            var productSize = product_Size_BUS.GetALLProductSize();

            if (productSize != null && productSize.Any())
            {
                cmbProductSize.DataSource = productSize;
                cmbProductSize.DisplayMember = "ProductSizeID";
                cmbProductSize.ValueMember = "ProductSizeID";
            }
        }

        private void loadDgvProductSize()
        {
            var productSize = product_Size_BUS.GetALLProductSize();
            dgvProductSize.DataSource = productSize;

            dgvProductSize.Columns["ProductSizeID"].HeaderText="Mã Thông tin SP";
            dgvProductSize.Columns["SizeName"].HeaderText = "Kích thước";
            dgvProductSize.Columns["SizePrice"].HeaderText = "Giá phụ thu";
            dgvProductSize.Columns["ProductName"].HeaderText = "Sản Phẩm";
            dgvProductSize.Columns["ProductPrice"].HeaderText = "Giá sản phẩm";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                var orderDT = new OrderDetail
                {
                    ProductSizeID = int.Parse(cmbProductSize.SelectedValue.ToString()),
                    OrderID = int.Parse(cmbOrder.SelectedValue.ToString()),
                    Quantity = int.Parse(txtQuantity.Text)
                };

                orderDetail_BUS.AddOrderDetail(orderDT);
                MessageBox.Show("Thêm thông tin chi tiết order thành công!");

                loadData();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var orderDT = new OrderDetail
            {
                OrderDetailID = int.Parse(txtID.Text),
                ProductSizeID = int.Parse(cmbProductSize.SelectedValue.ToString()),
                OrderID = int.Parse(cmbOrder.SelectedValue.ToString()),
                Quantity = int.Parse(txtQuantity.Text)
            };

            orderDetail_BUS.UpdateOrderDetail(orderDT);

            MessageBox.Show("Cập nhật thông tin chi tiết order thành công!");

            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrderDetails.SelectedRows[0];

                if (int.TryParse(selectedRow.Cells["OrderDetailID"].Value?.ToString(), out int orderDTID))
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xoá thông tin chi tiết order này?", "Xoá thông tin chi tiết order", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            orderDetail_BUS.DeleteOrderDetail(orderDTID);
                            MessageBox.Show("Đã xoá thông tin chi tiết order!");
                            loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xoá thông tin chi tiết order: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("OrderDetailID không hợp lệ. Vui lòng kiểm tra dữ liệu!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mua hàng để xoá.");
            }
        }

        private void OrderDetail_Management_Load(object sender, EventArgs e)
        {
            loadData();
            loadOrder();
            loadProductSize();
            loadDgvProductSize();
        }

        private void dgvOrderDTs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrderDetails.Rows[e.RowIndex];

                selectedOrderDTId = (int)row.Cells["OrderDetailID"].Value;

                txtID.Text = selectedOrderDTId.ToString();
                cmbOrder.Text = row.Cells["OrderID"].Value.ToString();
                cmbProductSize.Text = row.Cells["ProductSizeID"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
            }

        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            Bill_Management bill_Management = new Bill_Management();
            bill_Management.Show();
        }
    }
}
