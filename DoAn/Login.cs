using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        public bool kt;

        public bool role;

        public string usernames;

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            var user_BUS = new User_BUS();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập/ mật khẩu!", "Thông báo");
            }
            else
            {
                kt = false;
                role = false;
                if (user_BUS.Login(username, password))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    kt = true;
                    usernames = username;

                    if(user_BUS.CheckRole(username))
                    {
                        role = true;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai username hoặc password!");
                }
            }
        }
    }
}
