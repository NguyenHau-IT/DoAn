using BUS;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoAn
{
    public partial class Product_Management : Form
    {
        private Product_BUS product_BUS = new Product_BUS();

        private string selectedProductId = "";

        private int progressValue = 0;

        public Product_Management()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] imageBytes = null;

                if (pbProduct.Image != null)
                {
                    pbProduct.Image.Save(ms, pbProduct.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }

                var product = new Product
                {
                    ProductID = txtProductID.Text,
                    ProductName = txtProductName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    CategoryID = cmbCategory.SelectedValue.ToString(),
                    Images = imageBytes,
                };

                product_BUS.AddProduct(product);
                MessageBox.Show("Thêm sản phẩm thành công!");
                loadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dgvProducts.SelectedRows[0];
                string productId = (string)selectedRow.Cells["ProductID"].Value;

                var result = MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm này?", "Xoá sản phẩm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        product_BUS.DeleteProduct(productId);

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
            if (pbProduct.Image != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] imageBytes = null;

                        pbProduct.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imageBytes = ms.ToArray();

                        var product = new Product
                        {
                            ProductID = txtProductID.Text,
                            ProductName = txtProductName.Text,
                            Price = decimal.Parse(txtPrice.Text),
                            Description = txtDescription.Text,
                            CategoryID = cmbCategory.SelectedValue.ToString(),
                            Images = imageBytes,
                        };

                        product_BUS.UpdateProduct(product);

                        MessageBox.Show("Cập nhật sản phẩm thành công!");

                        loadData();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message);
                }
            }
            else
            {
                var product = new Product
                {
                    ProductID = txtProductID.Text,
                    ProductName = txtProductName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    CategoryID = cmbCategory.SelectedValue.ToString(),
                };

                product_BUS.UpdateProduct(product);

                MessageBox.Show("Cập nhật sản phẩm thành công!");

                loadData();
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pbProduct.Image = Image.FromFile(selectedImagePath);

                    txtImagePath.Text = selectedImagePath;
                }
            }

        }

        private Category_BUS category_BUS = new Category_BUS();

        private void LoadCategoriesIntoComboBox()
        {
            var categories = category_BUS.GetAllCategories();

            if (categories != null && categories.Any())
            {
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbFilter.DataSource = categories;
                cmbFilter.DisplayMember = "CategoryName";
                cmbFilter.ValueMember = "CategoryID";
            }
        }

        public void loadData()
        {
            var products = product_BUS.GetALLProduct();
            dgvProducts.DataSource = products;

            dgvProducts.Columns["ProductID"].HeaderText = "Mã sản phẩm";
            dgvProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            dgvProducts.Columns["Price"].HeaderText = "Giá";
            dgvProducts.Columns["CategoryName"].HeaderText = "Loại sản phẩm";
            dgvProducts.Columns["Description"].HeaderText = "Mô tả";
            dgvProducts.Columns["Images"].HeaderText = "Hình";

            dgvProducts.Columns["Images"].ValueType = typeof(Image);
            dgvProducts.Columns["Images"].Width = 150;
        }

        private void Product_Management_Load(object sender, EventArgs e)
        {
            loadData();
            LoadCategoriesIntoComboBox();
            CenterProgressBar();
            progressBarRefresh.Visible = false;
        }

        private void Product_Management_Resize(object sender, EventArgs e)
        {
            CenterProgressBar();
            progressBarRefresh.Visible = false;
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Images" && e.RowIndex >= 0)
            {
                if (e.Value != null)
                {
                    byte[] imageBytes = e.Value as byte[];
                    if (imageBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            Image img = Image.FromStream(ms);

                            int newWidth = 100;
                            int newHeight = 100;

                            Image resizedImg = new Bitmap(img, newWidth, newHeight);

                            e.Value = resizedImg;
                        }
                    }
                }
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                selectedProductId = (string)row.Cells["ProductID"].Value;

                txtProductID.Text = selectedProductId.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();

                if (row.Cells["Images"].Value != DBNull.Value && row.Cells["Images"].Value != null)
                {
                    byte[] imageBytes = (byte[])row.Cells["Images"].Value;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pbProduct.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbProduct.Image = null;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchID = txtCheckID.Text;
            string CategoryID = cmbCategory.SelectedValue.ToString();

            if (string.IsNullOrEmpty(searchID))
            {
                if (string.IsNullOrEmpty(CategoryID))
                {
                    MessageBox.Show("Hãy nhập loại sản phẩm/ mã sản phẩm!", "Thông báo");
                }
                else
                {
                    var product = product_BUS.Filter(CategoryID);
                    dgvProducts.DataSource = product;
                }
            }
            else
            {
                var products = product_BUS.SearchID(searchID);
                dgvProducts.DataSource = products;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarRefresh.Value = 0;
            progressBarRefresh.Visible = true;
            timerRefresh.Interval = 20;
            timerRefresh.Start();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (progressValue < 100)
            {
                progressValue += 1;
                progressBarRefresh.Value = progressValue;
            }
            else
            {
                timerRefresh.Stop();
                progressBarRefresh.Visible = false;
                MessageBox.Show("Làm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                LoadCategoriesIntoComboBox();
            }
        }

        private void CenterProgressBar()
        {
            int centerX = (this.ClientSize.Width - progressBarRefresh.Width) / 2;
            int centerY = (this.ClientSize.Height - progressBarRefresh.Height) / 2;
            progressBarRefresh.Location = new Point(centerX, centerY);
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
