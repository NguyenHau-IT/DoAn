using System.Windows.Forms;

namespace DoAn
{
    partial class Cafe_Management
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cafe_Management));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnInfor = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnProductSize = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnODT = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnArea = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnSize = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnRole = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnThongKeBill = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.progressBarInit = new System.Windows.Forms.ProgressBar();
            this.timerInit = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1050, 157);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage1.Controls.Add(this.btnInfor);
            this.tabPage1.Controls.Add(this.btnChange);
            this.tabPage1.Controls.Add(this.btnLogin);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1042, 119);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hệ Thống";
            // 
            // btnInfor
            // 
            this.btnInfor.Location = new System.Drawing.Point(8, 63);
            this.btnInfor.Name = "btnInfor";
            this.btnInfor.Size = new System.Drawing.Size(335, 28);
            this.btnInfor.TabIndex = 8;
            this.btnInfor.Text = "Thông tin";
            this.btnInfor.UseVisualStyleBackColor = true;
            this.btnInfor.Click += new System.EventHandler(this.btnInfor_Click);
            // 
            // btnChange
            // 
            this.btnChange.Image = global::DoAn.Properties.Resources.change;
            this.btnChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChange.Location = new System.Drawing.Point(191, 8);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(144, 49);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Đổi tài khoản";
            this.btnChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::DoAn.Properties.Resources.login;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(8, 8);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(132, 49);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage2.Controls.Add(this.btnProductSize);
            this.tabPage2.Controls.Add(this.btnCategory);
            this.tabPage2.Controls.Add(this.btnODT);
            this.tabPage2.Controls.Add(this.btnOrder);
            this.tabPage2.Controls.Add(this.btnArea);
            this.tabPage2.Controls.Add(this.btnTable);
            this.tabPage2.Controls.Add(this.btnProduct);
            this.tabPage2.Controls.Add(this.btnSize);
            this.tabPage2.Controls.Add(this.btnBill);
            this.tabPage2.Controls.Add(this.btnRole);
            this.tabPage2.Controls.Add(this.btnUser);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1042, 119);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản Lý";
            // 
            // btnProductSize
            // 
            this.btnProductSize.Image = global::DoAn.Properties.Resources.images;
            this.btnProductSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductSize.Location = new System.Drawing.Point(673, 62);
            this.btnProductSize.Name = "btnProductSize";
            this.btnProductSize.Size = new System.Drawing.Size(187, 51);
            this.btnProductSize.TabIndex = 11;
            this.btnProductSize.Text = "Quản lý cở sản phẩm";
            this.btnProductSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductSize.UseVisualStyleBackColor = true;
            this.btnProductSize.Click += new System.EventHandler(this.btnProductSize_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Image = global::DoAn.Properties.Resources.images;
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.Location = new System.Drawing.Point(8, 62);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(126, 51);
            this.btnCategory.TabIndex = 10;
            this.btnCategory.Text = "Quản lý loại";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnODT
            // 
            this.btnODT.Image = global::DoAn.Properties.Resources.images;
            this.btnODT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnODT.Location = new System.Drawing.Point(466, 62);
            this.btnODT.Name = "btnODT";
            this.btnODT.Size = new System.Drawing.Size(201, 51);
            this.btnODT.TabIndex = 9;
            this.btnODT.Text = "Quản lý chi tiết mua hàng";
            this.btnODT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnODT.UseVisualStyleBackColor = true;
            this.btnODT.Click += new System.EventHandler(this.btnODT_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Image = global::DoAn.Properties.Resources.images;
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(297, 62);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(163, 51);
            this.btnOrder.TabIndex = 8;
            this.btnOrder.Text = "Quản lý mua hàng";
            this.btnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnArea
            // 
            this.btnArea.Image = global::DoAn.Properties.Resources.images;
            this.btnArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArea.Location = new System.Drawing.Point(140, 63);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(151, 51);
            this.btnArea.TabIndex = 7;
            this.btnArea.Text = "Quản lý khu vực";
            this.btnArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArea.UseVisualStyleBackColor = true;
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // btnTable
            // 
            this.btnTable.Image = global::DoAn.Properties.Resources.images;
            this.btnTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTable.Location = new System.Drawing.Point(810, 6);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(127, 51);
            this.btnTable.TabIndex = 6;
            this.btnTable.Text = "Quản lý bàn";
            this.btnTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Image = global::DoAn.Properties.Resources.images;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(336, 6);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(161, 51);
            this.btnProduct.TabIndex = 5;
            this.btnProduct.Text = "Quản lý sản phẩm";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnSize
            // 
            this.btnSize.Image = global::DoAn.Properties.Resources.Ly;
            this.btnSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSize.Location = new System.Drawing.Point(503, 6);
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(141, 51);
            this.btnSize.TabIndex = 4;
            this.btnSize.Text = "Quản lý kích cở";
            this.btnSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSize.UseVisualStyleBackColor = true;
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // btnBill
            // 
            this.btnBill.Image = global::DoAn.Properties.Resources.bill;
            this.btnBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.Location = new System.Drawing.Point(650, 6);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(154, 51);
            this.btnBill.TabIndex = 3;
            this.btnBill.Text = "Quản lý hoá đơn";
            this.btnBill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // btnRole
            // 
            this.btnRole.Image = global::DoAn.Properties.Resources.menu_icon;
            this.btnRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRole.Location = new System.Drawing.Point(180, 6);
            this.btnRole.Name = "btnRole";
            this.btnRole.Size = new System.Drawing.Size(150, 51);
            this.btnRole.TabIndex = 2;
            this.btnRole.Text = "Quản lý chức vụ";
            this.btnRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRole.UseVisualStyleBackColor = true;
            this.btnRole.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnUser
            // 
            this.btnUser.Image = global::DoAn.Properties.Resources.free_user_group;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(8, 6);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(166, 51);
            this.btnUser.TabIndex = 1;
            this.btnUser.Text = "Quản lý nhân viên";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage3.Controls.Add(this.btnThongKeBill);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1042, 119);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Thống kê";
            // 
            // btnThongKeBill
            // 
            this.btnThongKeBill.Image = global::DoAn.Properties.Resources.chart;
            this.btnThongKeBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKeBill.Location = new System.Drawing.Point(6, 4);
            this.btnThongKeBill.Name = "btnThongKeBill";
            this.btnThongKeBill.Size = new System.Drawing.Size(306, 109);
            this.btnThongKeBill.TabIndex = 0;
            this.btnThongKeBill.Text = "Thống kê theo hoá đơn";
            this.btnThongKeBill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKeBill.UseVisualStyleBackColor = true;
            this.btnThongKeBill.Click += new System.EventHandler(this.btnThongKeBill_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1042, 119);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Trợ giúp";
            // 
            // progressBarInit
            // 
            this.progressBarInit.Location = new System.Drawing.Point(313, 313);
            this.progressBarInit.Name = "progressBarInit";
            this.progressBarInit.Size = new System.Drawing.Size(368, 23);
            this.progressBarInit.TabIndex = 6;
            // 
            // timerInit
            // 
            this.timerInit.Tick += new System.EventHandler(this.timerInit_Tick);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(12, 163);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Cafe_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1050, 638);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.progressBarInit);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Cafe_Management";
            this.Text = "Cafe Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cafe_Management_FormClosing);
            this.Load += new System.EventHandler(this.Cafe_Management_Load);
            this.Resize += new System.EventHandler(this.Cafe_Management_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnLogin;
        private Button btnBill;
        private Button btnRole;
        private Button btnUser;
        private Button btnProduct;
        private Button btnSize;
        private Button btnChange;
        private TabPage tabPage3;
        private ProgressBar progressBarInit;
        private Timer timerInit;
        private Button btnExit;
        private TabPage tabPage4;
        private Button btnTable;
        private Button btnArea;
        private Button btnInfor;
        private Button btnODT;
        private Button btnOrder;
        private Button btnCategory;
        private Button btnProductSize;
        private Button btnThongKeBill;
    }
}