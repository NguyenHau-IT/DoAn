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
    public partial class Area_Management : Form
    {
        public Area_Management()
        {
            InitializeComponent();
        }
        private Area_BUS area_BUS = new Area_BUS();

        private string selectedAreaId = "";

        public void loadData()
        {
            var area = area_BUS.GetAreas();
            dgvArea.DataSource = area;

            dgvArea.Columns["AreaID"].HeaderText = "Mã khu";
            dgvArea.Columns["AreaName"].HeaderText = "Tên khu";
        }

        private void Area_Management_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var area = new Area
            {
                AreaID = txtID.Text,
                AreaName = txtName.Text
            };

            area_BUS.AddArea(area);
            MessageBox.Show("Đã thêm khu vực thành công!");
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvArea.SelectedRows.Count > 0)
            {
                var selectedRow = dgvArea.SelectedRows[0];
                string areaID = (string)selectedRow.Cells["AreaID"].Value;

                area_BUS.DeleteArea(areaID);
                MessageBox.Show("Xoá khu vực thành công!");
                loadData();
                txtName.Clear();
                txtID.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(selectedAreaId))
            {
                var area = new Area
                {
                    AreaName = txtName.Text.Trim(),
                };
                area_BUS.UpdateArea(area);
                MessageBox.Show("Cập nhật kích cỡ thành công!");

                loadData();
                selectedAreaId = "";
                txtName.Clear();
                txtID.Clear();
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
                DataGridViewRow row = dgvArea.Rows[e.RowIndex];

                selectedAreaId = (string)row.Cells["AreaID"].Value;

                txtID.Text = row.Cells["AreaID"].Value.ToString();
                txtName.Text = row.Cells["AreaName"].Value.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
