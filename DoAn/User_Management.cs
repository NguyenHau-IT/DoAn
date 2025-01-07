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
using BUS;
using DAL.Entities;

namespace DoAn
{
    public partial class User_Management : Form
    {
        private User_BUS user_BUS = new User_BUS();
        private Role_BUS role_BUS = new Role_BUS();
        public string selectedUsername = "";

        public User_Management()
        {
            InitializeComponent();
        }

        private void User_Management_Load(object sender, EventArgs e)
        {
            try
            {

                var listEmployees = user_BUS.GetALLUser();
                var listRoles = role_BUS.GetALLRole();
                loaddata();
                FillRole(listRoles);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FillRole(List<Role> roles)
        {

            this.cmb_01.DataSource = roles;
            this.cmb_01.DisplayMember = "RoleName";
            this.cmb_01.ValueMember = "RoleID";
        }

        private void loaddata()
        {
            var user = user_BUS.GetALLUser();
            dgv_displayemployee.DataSource = user;

            dgv_displayemployee.Columns["UserName"].HeaderText = "Tên đăng nhập";
            dgv_displayemployee.Columns["Userpassword"].HeaderText = "Mật khẩu";
            dgv_displayemployee.Columns["FullName"].HeaderText = "Họ và tên";
            dgv_displayemployee.Columns["Phone"].HeaderText = "SĐT";
            dgv_displayemployee.Columns["IdentityCard"].HeaderText = "ID Card";
            dgv_displayemployee.Columns["RoleName"].HeaderText = "Chức vụ";
        }

        private bool TypeInputCheck()
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                MessageBox.Show("Mã số không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_hoten.Text))
            {
                MessageBox.Show("Vui lòng điên tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_sdt.Text) || txt_sdt.Text.Length < 10)
            {
                MessageBox.Show("Vui lòng nhập đúng số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_displaypassword.Text) || txt_displaypassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải ít nhất 6 kí tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmb_01.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TypeInputCheck()) { return; }

                var user = new User();
                {
                    user.UserName = txt_username.Text;
                    user.Userpassword = txt_displaypassword.Text;
                    user.FullName = txt_hoten.Text;
                    user.Phone = txt_sdt.Text;
                    user.IdentityCard = txt_idcard.Text;
                    user.RoleID = cmb_01.SelectedValue.ToString();
                };

                user_BUS.AddUser(user);

                MessageBox.Show("Thêm nhân viên thành công!");
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.ToString();
                var result = user_BUS.FindByID(keyword);
                dgv_displayemployee.DataSource = result;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User_BUS();
                var selectedID = txt_idcard.Text;
                var employeeName = txt_username.Text;
                var employeeID = user.FindByID(selectedID);
                if (employeeID != null)
                {
                    user.DeleteUser(employeeName);
                    MessageBox.Show($"Đã xóa nhân viên {employeeName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loaddata();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phát sinh: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            var user = new User();
            {
                user.UserName = txt_username.Text;
                user.Userpassword = txt_displaypassword.Text;
                user.FullName = txt_hoten.Text;
                user.Phone = txt_sdt.Text;
                user.IdentityCard = txt_idcard.Text;
                user.RoleID = cmb_01.SelectedValue.ToString();
            };

            user_BUS.UpdateUser(user);

            MessageBox.Show("Cập nhật nhân viên thành công!");

            loaddata();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_displayemployee.Rows[e.RowIndex];

                selectedUsername = (string)row.Cells["UserName"].Value;

                txt_username.Text = selectedUsername;
                txt_displaypassword.Text = row.Cells["Userpassword"].Value.ToString();
                txt_hoten.Text = row.Cells["FullName"].Value.ToString();
                txt_idcard.Text = (string)row.Cells["IdentityCard"].Value.ToString();
                txt_sdt.Text = (string)row.Cells["Phone"].Value.ToString();
                cmb_01.Text = row.Cells["RoleName"].Value.ToString();
            }
        }
    }
}
