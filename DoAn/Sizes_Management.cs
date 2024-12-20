using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoAn
{
    public partial class Sizes_Management : Form
    {
        private Sizes_BUS sizes_BUS = new Sizes_BUS();

        private string selectedSizeId = "";

        public Sizes_Management()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            var Size = sizes_BUS.GetALLSize();
            dgvSize.DataSource = Size;

            dgvSize.Columns["SizeName"].HeaderText = "Kích cở";
            dgvSize.Columns["SizePrice"].HeaderText = "Giá";
        }

        private void Size_Management_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var size = new Sizes
            {
                SizeName = txtName.Text,
                SizePrice = Convert.ToDecimal(txtPrice.Text)
            };

            sizes_BUS.AddSize(size);
            MessageBox.Show("Đã thêm kích cở thành công!");
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSize.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSize.SelectedRows[0];
                string sizeName = (string)selectedRow.Cells["SizeName"].Value;

                sizes_BUS.DeleteSize(sizeName);
                MessageBox.Show("Xoá kích cở thành công!");
                loadData();
                txtName.Clear();
                txtPrice.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(selectedSizeId))
            {
                try
                {
                    if (Decimal.TryParse(txtPrice.Text, out decimal price))
                    {
                        var size = new Sizes
                        {
                            SizeName = txtName.Text.Trim(),
                            SizePrice = price
                        };

                        sizes_BUS.UpdateSize(size);
                        MessageBox.Show("Cập nhật kích cỡ thành công!");

                        loadData();
                        selectedSizeId = "";
                        txtName.Clear();
                        txtPrice.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Giá phải là một số hợp lệ!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi cập nhật kích cỡ: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một kích cỡ để cập nhật bằng cách nhấn vào danh sách.");
            }
        }


        private void dgvSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSize.Rows[e.RowIndex];

                selectedSizeId = (string)row.Cells["SizeName"].Value;

                txtName.Text = row.Cells["SizeName"].Value.ToString();
                txtPrice.Text = row.Cells["SizePrice"].Value.ToString();
            }
        }

        private void Sizes_Management_Load(object sender, EventArgs e)
        {
            loadData();
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
