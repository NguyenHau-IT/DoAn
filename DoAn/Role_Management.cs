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
    public partial class Role_Management : Form
    {
        private Role_BUS role_BUS = new Role_BUS();

        private string selectedRoleId = "";

        public Role_Management()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            var role = role_BUS.GetALLRole();
            dgvRole.DataSource = role;
        }

        private void Role_Management_Load(object sender, EventArgs e)
        {
            var role = role_BUS.GetALLRole();
            dgvRole.DataSource = role;

            dgvRole.Columns["RoleID"].HeaderText = "Mã chức vụ";
            dgvRole.Columns["RoleName"].HeaderText = "Chức vụ";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var role = new Role
            {
                RoleID = txtID.Text,
                RoleName = txtRole.Text
            };

            role_BUS.AddRole(role);
            MessageBox.Show("Đã thêm chức vụ thành công!");
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRole.SelectedRows.Count > 0)
            {
                var selectedRow = dgvRole.SelectedRows[0];
                string roleId = (string)selectedRow.Cells["RoleID"].Value;

                role_BUS.DeleteRole(roleId);
                MessageBox.Show("Xoá chức vụ thành công!");
                loadData();
                txtID.Clear();
                txtRole.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRoleId != "")
            {
                try
                {
                    var role = new Role()
                    {
                        RoleName = txtRole.Text,
                    };

                    role_BUS.UpdateRole(role);
                    MessageBox.Show("Product updated successfully!");
                    loadData();

                    selectedRoleId = "";
                    txtID.Clear();
                    txtRole.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update by clicking on it in the list.");
            }
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRole.Rows[e.RowIndex];

                selectedRoleId = (string)row.Cells["RoleID"].Value;

                txtID.Text = row.Cells["RoleID"].Value.ToString();
                txtRole.Text = row.Cells["RoleName"].Value.ToString();
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
