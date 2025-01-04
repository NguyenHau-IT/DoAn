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

namespace DoAn
{
    public partial class Category_Management : Form
    {
        Category_BUS category_BUS = new Category_BUS();

        string selectedID;
        public Category_Management()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                        var category = new Category();
                        category.CategoryID = txt_cateid.Text.Trim();
                        category.CategoryName = txt_catename.Text;
                        category.Description = txt_description.Text;
                        category_BUS.AddCategory(category);
                    BindGrid();
                    MessageBox.Show($"Đã thêm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_frmCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgv_frmCategory.Rows[e.RowIndex];

                selectedID = row.Cells["CategoryID"].Value.ToString();

                txt_cateid.Text = selectedID;
                txt_catename.Text = row.Cells["CategoryName"].Value.ToString();
                txt_description.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private void Category_Management_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            var category = category_BUS.GetAllCategories();
            dgv_frmCategory.DataSource = category;

            dgv_frmCategory.Columns["CategoryID"].HeaderText = "Mã loại";
            dgv_frmCategory.Columns["CategoryName"].HeaderText = "Tên loại";
            dgv_frmCategory.Columns["Description"].HeaderText = "Mô tả";
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {

                var category = new Category();
                category.CategoryID = txt_cateid.Text.Trim();
                category.CategoryName = txt_catename.Text;
                category.Description = txt_description.Text;
                category_BUS.UpdateCategory(category);
                BindGrid();
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phát sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_frmCategory.SelectedRows.Count > 0 || dgv_frmCategory.SelectedColumns.Count > 0)
            {
                var selectedRow = dgv_frmCategory.SelectedRows[0];
                string cateId = (string)selectedRow.Cells["CategoryID"].Value;

                category_BUS.DeleteCategory(cateId);
                MessageBox.Show("Xoá chức vụ thành công!");
                BindGrid();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
