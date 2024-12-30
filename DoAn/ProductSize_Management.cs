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
using DAL.Entities;

namespace DoAn
{
    public partial class ProductSize_Management : Form
    {
        Product_BUS product_BUS = new Product_BUS();

        Sizes_BUS sizes_BUS = new Sizes_BUS();

        Product_Size_BUS product_Size_BUS = new Product_Size_BUS();

        int selectedPS;

        public ProductSize_Management()
        {
            InitializeComponent();
            LoadProduct();
            LoadSize();
            LoadDGV();
        }

        private void LoadProduct()
        {
            var product = product_BUS.GetALLProduct();

            if (product != null && product.Any())
            {
                cmbProduct.DataSource = product;
                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember = "ProductID";

            }
        }

        private void LoadSize()
        {
            var size = sizes_BUS.GetALLSize();

            if (size != null && size.Any())
            {
                cmbSize.DataSource = size;
                cmbSize.DisplayMember = "SizeName";
                cmbSize.ValueMember = "SizeName";

            }
        }

        private void LoadDGV()
        {
            var productSize = product_Size_BUS.GetALLProductSize();
            dgvProductSize.DataSource = productSize;

            dgvProductSize.Columns["ProductSizeID"].HeaderText = "Mã Thông tin SP";
            dgvProductSize.Columns["SizeName"].HeaderText = "Kích thước";
            dgvProductSize.Columns["SizePrice"].HeaderText = "Giá phụ thu";
            dgvProductSize.Columns["ProductName"].HeaderText = "Sản Phẩm";
            dgvProductSize.Columns["ProductPrice"].HeaderText = "Giá sản phẩm";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                var productSize = new ProductSize
                {
                    ProductSizeID = int.Parse(txtID.Text),
                    ProductID = cmbProduct.SelectedValue.ToString(),
                    SizeName = cmbSize.Text,
                };

                product_Size_BUS.AddProductSize(productSize);
                MessageBox.Show("Thêm thông tin chi tiết order thành công!");

                LoadDGV();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ: " + ex.Message);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                var productSize = new ProductSize
                {
                    ProductSizeID = int.Parse(txtID.Text),
                    ProductID = cmbProduct.SelectedValue.ToString(),
                    SizeName = cmbSize.Text,
                };

                product_Size_BUS.UpdateProductSize(productSize);
                MessageBox.Show("Sửa thông tin chi tiết order thành công!");

                LoadDGV();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ: " + ex.Message);
            }
        }

        private void dgvProductSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductSize.Rows[e.RowIndex];

                selectedPS = (int)row.Cells["ProductSizeID"].Value;

                txtID.Text = selectedPS.ToString();
                cmbProduct.Text = row.Cells["ProductName"].Value.ToString();
                cmbSize.Text = row.Cells["SizeName"].Value.ToString();
            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgvProductSize.SelectedRows.Count > 0)
            {
                var selectedRow = dgvProductSize.SelectedRows[0];

                if (int.TryParse(selectedRow.Cells["ProductSizeID"].Value?.ToString(), out int psID))
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xoá thông tin chi tiết order này?", "Xoá thông tin chi tiết order", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            product_Size_BUS.DeleteProductSize(psID);
                            MessageBox.Show("Đã xoá!");
                            LoadDGV();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xoá : " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ID không hợp lệ. Vui lòng kiểm tra dữ liệu!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mua hàng để xoá.");
            }
        }
    }
}
