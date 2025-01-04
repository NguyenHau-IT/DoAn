using System;
using System.Drawing;
using System.Windows.Forms;
using BUS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAn
{
    public partial class Cafe_Management : Form
    {
        private User_BUS user = new User_BUS();

        private int progressValue = 0;

        public string name;

        public Cafe_Management()
        {
            InitializeComponent();
        }

        private void Cafe_Management_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không?", "Thoát khỏi chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            { e.Cancel = false; }
            else e.Cancel = true;
        }

        private void Cafe_Management_Load(object sender, EventArgs e)
        {
            loginfail();
            CenterProgressBar();
            progressBarInit.Visible = false;
        }

        private void Cafe_Management_Resize(object sender, EventArgs e)
        {
            CenterProgressBar();
        }

        private void loginfail()
        {
            btnBill.Enabled = false;
            btnRole.Enabled = false;
            btnSize.Enabled = false;
            btnUser.Enabled = false;
            btnChange.Enabled = false;
            btnProduct.Enabled = false;
            btnInfor.Enabled = false;
            btnArea.Enabled = false;
            btnTable.Enabled = false;
            btnCategory.Enabled = false;
            btnODT.Enabled = false;
            btnOrder.Enabled = false;
            btnProductSize.Enabled = false;
            btnThongKeBill.Enabled = false;
        }

        private void loginuser()
        {
            btnBill.Enabled = true;
            btnChange.Enabled = true;
            btnODT.Enabled = true;
            btnOrder.Enabled = true;
            btnProductSize.Enabled = true;
            btnInfor.Enabled = true;
        }

        private void loginsuccess()
        {
            btnBill.Enabled = true;
            btnRole.Enabled = true;
            btnSize.Enabled = true;
            btnUser.Enabled = true;
            btnChange.Enabled = true;
            btnProduct.Enabled = true;
            btnInfor.Enabled = true;
            btnArea.Enabled = true;
            btnTable.Enabled = true;
            btnCategory.Enabled = true;
            btnODT.Enabled = true;
            btnOrder.Enabled = true;
            btnProductSize.Enabled = true;
            btnThongKeBill.Enabled = true;  
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            if (login.kt)
            {
                name = Properties.Settings.Default.Name;
                btnInfor.Text = user.GetName(name);
                btnLogin.Enabled = false;
                if (login.role)
                {
                    loginsuccess();
                }
                else
                {
                    loginuser();
                }

            }
            else
            {
                MessageBox.Show("Đăng nhập để sử dụng!", "Thông báo");
                loginfail();
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "User";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Bill";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Role";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Sizes";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            loginfail();
            Properties.Settings.Default.Name ="";
            Properties.Settings.Default.Save();
            btnLogin.Enabled = true;
            btnInfor.Text = "Thông tin";
            btnLogin_Click(sender, e);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Product";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Table";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Area";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnInfor_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Infor";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Order";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnODT_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "ODT";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "Category";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnProductSize_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "ProductSize";
            timerInit.Interval = 30;
            timerInit.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerInit_Tick(object sender, EventArgs e)
        {
            if (progressValue < 100)
            {
                progressValue += 1;
                progressBarInit.Value = progressValue;
            }
            else
            {
                timerInit.Stop();
                progressBarInit.Visible = false;

                string formToOpen = timerInit.Tag as string;
                switch (formToOpen)
                {
                    case "Bill":
                        Bill_Management bill_Management = new Bill_Management();
                        bill_Management.Show();
                        break;

                    case "Role":
                        Role_Management role_Management = new Role_Management();
                        role_Management.Show();
                        break;

                    case "Sizes":
                        Sizes_Management sizes_Management = new Sizes_Management();
                        sizes_Management.Show();
                        break;

                    case "Product":
                        Product_Management product_Management = new Product_Management();
                        product_Management.Show();
                        break;

                    case "Table":
                        CF_Table_Management cf_Table_Management = new CF_Table_Management();
                        cf_Table_Management.Show();
                        break;

                    case "Area":
                        Area_Management area_Management = new Area_Management();
                        area_Management.Show();
                        break;

                    case "Infor":
                        MessageBox.Show($"Name {name}");
                        InforUser inforUser = new InforUser();
                        inforUser.Show();
                        break;

                    case "Order":
                        Order_Management order_Management = new Order_Management();
                        order_Management.Show();
                        break;

                    case "ODT":
                        OrderDetail_Management orderDetail_Management = new OrderDetail_Management();
                        orderDetail_Management.Show();
                        break;

                    case "Category":
                        Category_Management category_Management = new Category_Management();
                        category_Management.Show();
                        break;

                    case "ProductSize":
                        ProductSize_Management productSize_Management = new ProductSize_Management();
                        productSize_Management.Show();
                        break;

                    case "User":
                        User_Management user_Management = new User_Management();
                        user_Management.Show();
                        break;
                    case "ThongkeBill":
                        Bill_Statistics bill_Statistics = new Bill_Statistics();
                        bill_Statistics.Show();
                        break;
                }
            }
        }

        private void CenterProgressBar()
        {
            int centerX = (this.ClientSize.Width - progressBarInit.Width) / 2;
            int centerY = (this.ClientSize.Height - progressBarInit.Height) / 2;
            progressBarInit.Location = new Point(centerX, centerY);
        }

        private void btnThongKeBill_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBarInit.Value = 0;
            progressBarInit.Visible = true;
            timerInit.Tag = "ThongkeBill";
            timerInit.Interval = 30;
            timerInit.Start();

        }
    }
}
