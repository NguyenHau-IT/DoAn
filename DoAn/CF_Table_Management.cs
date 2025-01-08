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
    public partial class CF_Table_Management : Form
    {
        private CF_Table_BUS table_BUS = new CF_Table_BUS();

        private string selectedTableId = "";

        public CF_Table_Management()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            var table = table_BUS.GetALLTables();
            dgvTable.DataSource = table;

            dgvTable.Columns["TableID"].HeaderText = "Mã bàn";
            dgvTable.Columns["TableName"].HeaderText = "Tên bàn";
            dgvTable.Columns["AreaName"].HeaderText = "Khu vực";
            dgvTable.Columns["Status"].HeaderText = "Trạng thái";
        }

        private Area_BUS area_BUS = new Area_BUS();

        public void loadcmb()
        {
            var area = area_BUS.GetAreas();

            if (area != null && area.Any())
            {
                cmbArea.DataSource = area;
                cmbArea.DisplayMember = "AreaName";
                cmbArea.ValueMember = "AreaID";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var table = new CF_Table
            {
                TableID = txtID.Text.Trim(),
                TableName = txtName.Text.Trim(),
                AreaID = cmbArea.SelectedValue?.ToString() ?? "",  // Avoid null reference
                Status = cmbStatus.Text // Avoid null reference
            };

            try
            {
                table_BUS.AddTable(table);
                MessageBox.Show("Đã thêm bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData(); // Reload UI
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                var selectedRow = dgvTable.SelectedRows[0];
                string tableId = (string)selectedRow.Cells["TableID"].Value;

                table_BUS.DeleteTable(tableId);
                MessageBox.Show("Xoá bàn thành công!");
                loadData();
                txtID.Clear();
                txtName.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedTableId))
            {
                try
                {
                    if (cmbArea.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn khu vực hợp lệ.");
                        return;
                    }

                    if (cmbStatus.SelectedItem == null)
                    {
                        MessageBox.Show("Vui lòng chọn trạng thái hợp lệ.");
                        return;
                    }

                    var table = new CF_Table
                    {
                        TableID = selectedTableId,
                        TableName = txtName.Text,
                        AreaID = cmbArea.SelectedValue.ToString(),
                        Status = cmbStatus.SelectedItem.ToString(),
                    };

                    table_BUS.UpdateTable(table);
                    MessageBox.Show("Cập nhật bàn thành công!");

                    loadData();

                    selectedTableId = "";
                    txtID.Clear();
                    txtName.Clear();
                    cmbArea.SelectedIndex = -1;
                    cmbStatus.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn trong danh sách.");
            }

        }


        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTable.Rows[e.RowIndex];

                selectedTableId = (string)row.Cells["TableID"].Value;

                txtID.Text = row.Cells["TableID"].Value.ToString();
                txtName.Text = row.Cells["TableName"].Value.ToString();
                cmbArea.Text = row.Cells["AreaName"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
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

        private void loadstatus()
        {
            // Thêm các trạng thái vào ComboBox
            cmbStatus.Items.Add("Trống");
            cmbStatus.Items.Add("Có khách");

            // Chọn một mục mặc định (tùy chọn)
            cmbStatus.SelectedIndex = 0; // Chọn "Trống" làm mặc định
        }


        private void CF_Table_Management_Load(object sender, EventArgs e)
        {
            loadData();
            loadcmb();
            loadstatus();
        }
    }
}
