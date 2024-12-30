namespace DoAn
{
    partial class User_Management
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
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_displayemployee = new System.Windows.Forms.DataGridView();
            this.grp_employeeinfo = new System.Windows.Forms.GroupBox();
            this.txt_idcard = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_displaypassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_01 = new System.Windows.Forms.ComboBox();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_displayemployee)).BeginInit();
            this.grp_employeeinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_search.Location = new System.Drawing.Point(384, 273);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(97, 29);
            this.btn_search.TabIndex = 24;
            this.btn_search.Text = "Tìm";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_search.Location = new System.Drawing.Point(125, 275);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(253, 23);
            this.txt_search.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(18, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Tìm kiếm:";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_refresh.Location = new System.Drawing.Point(744, 181);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(111, 34);
            this.btn_refresh.TabIndex = 21;
            this.btn_refresh.Text = "Làm mới";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_delete.Location = new System.Drawing.Point(744, 128);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(111, 34);
            this.btn_delete.TabIndex = 20;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_edit.Location = new System.Drawing.Point(744, 67);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(111, 34);
            this.btn_edit.TabIndex = 19;
            this.btn_edit.Text = "Sửa";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_add.Location = new System.Drawing.Point(744, 11);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(111, 34);
            this.btn_add.TabIndex = 18;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgv_displayemployee
            // 
            this.dgv_displayemployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_displayemployee.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_displayemployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_displayemployee.Location = new System.Drawing.Point(12, 313);
            this.dgv_displayemployee.Name = "dgv_displayemployee";
            this.dgv_displayemployee.RowHeadersWidth = 51;
            this.dgv_displayemployee.RowTemplate.Height = 24;
            this.dgv_displayemployee.Size = new System.Drawing.Size(861, 311);
            this.dgv_displayemployee.TabIndex = 17;
            this.dgv_displayemployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // grp_employeeinfo
            // 
            this.grp_employeeinfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grp_employeeinfo.Controls.Add(this.txt_idcard);
            this.grp_employeeinfo.Controls.Add(this.label7);
            this.grp_employeeinfo.Controls.Add(this.txt_displaypassword);
            this.grp_employeeinfo.Controls.Add(this.btn_refresh);
            this.grp_employeeinfo.Controls.Add(this.label5);
            this.grp_employeeinfo.Controls.Add(this.btn_delete);
            this.grp_employeeinfo.Controls.Add(this.cmb_01);
            this.grp_employeeinfo.Controls.Add(this.btn_edit);
            this.grp_employeeinfo.Controls.Add(this.txt_sdt);
            this.grp_employeeinfo.Controls.Add(this.btn_add);
            this.grp_employeeinfo.Controls.Add(this.txt_hoten);
            this.grp_employeeinfo.Controls.Add(this.txt_username);
            this.grp_employeeinfo.Controls.Add(this.label4);
            this.grp_employeeinfo.Controls.Add(this.label3);
            this.grp_employeeinfo.Controls.Add(this.label2);
            this.grp_employeeinfo.Controls.Add(this.label1);
            this.grp_employeeinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grp_employeeinfo.Location = new System.Drawing.Point(12, 12);
            this.grp_employeeinfo.Name = "grp_employeeinfo";
            this.grp_employeeinfo.Size = new System.Drawing.Size(861, 246);
            this.grp_employeeinfo.TabIndex = 16;
            this.grp_employeeinfo.TabStop = false;
            this.grp_employeeinfo.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // txt_idcard
            // 
            this.txt_idcard.Location = new System.Drawing.Point(163, 174);
            this.txt_idcard.Name = "txt_idcard";
            this.txt_idcard.Size = new System.Drawing.Size(203, 23);
            this.txt_idcard.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "ID Card";
            // 
            // txt_displaypassword
            // 
            this.txt_displaypassword.Location = new System.Drawing.Point(163, 54);
            this.txt_displaypassword.Name = "txt_displaypassword";
            this.txt_displaypassword.Size = new System.Drawing.Size(203, 23);
            this.txt_displaypassword.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mật khẩu tài khoản:";
            // 
            // cmb_01
            // 
            this.cmb_01.FormattingEnabled = true;
            this.cmb_01.Location = new System.Drawing.Point(163, 81);
            this.cmb_01.Name = "cmb_01";
            this.cmb_01.Size = new System.Drawing.Size(203, 25);
            this.cmb_01.TabIndex = 3;
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(163, 110);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(203, 23);
            this.txt_sdt.TabIndex = 6;
            // 
            // txt_hoten
            // 
            this.txt_hoten.Location = new System.Drawing.Point(163, 141);
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(203, 23);
            this.txt_hoten.TabIndex = 5;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(163, 25);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(203, 23);
            this.txt_username.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chức vụ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ tên nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đăng nhập";
            // 
            // User_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(882, 632);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_displayemployee);
            this.Controls.Add(this.grp_employeeinfo);
            this.Name = "User_Management";
            this.Text = "User_Management";
            this.Load += new System.EventHandler(this.User_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_displayemployee)).EndInit();
            this.grp_employeeinfo.ResumeLayout(false);
            this.grp_employeeinfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_displayemployee;
        private System.Windows.Forms.GroupBox grp_employeeinfo;
        private System.Windows.Forms.TextBox txt_idcard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_displaypassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_01;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}