namespace DoAn
{
    partial class Category_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Category_Management));
            this.dgv_frmCategory = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.txt_catename = new System.Windows.Forms.TextBox();
            this.txt_cateid = new System.Windows.Forms.TextBox();
            this.btn_out = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_frmCategory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_frmCategory
            // 
            this.dgv_frmCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_frmCategory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_frmCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_frmCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_frmCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_frmCategory.Location = new System.Drawing.Point(0, 221);
            this.dgv_frmCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_frmCategory.Name = "dgv_frmCategory";
            this.dgv_frmCategory.RowHeadersWidth = 51;
            this.dgv_frmCategory.RowTemplate.Height = 24;
            this.dgv_frmCategory.Size = new System.Drawing.Size(1067, 385);
            this.dgv_frmCategory.TabIndex = 1;
            this.dgv_frmCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_frmCategory_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_description);
            this.groupBox1.Controls.Add(this.txt_catename);
            this.groupBox1.Controls.Add(this.txt_cateid);
            this.groupBox1.Controls.Add(this.btn_out);
            this.groupBox1.Controls.Add(this.btn_xoa);
            this.groupBox1.Controls.Add(this.btn_edit);
            this.groupBox1.Controls.Add(this.btn_them);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1067, 214);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mô tả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tên Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mã Loại";
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(116, 140);
            this.txt_description.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(304, 30);
            this.txt_description.TabIndex = 14;
            // 
            // txt_catename
            // 
            this.txt_catename.Location = new System.Drawing.Point(116, 87);
            this.txt_catename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_catename.Name = "txt_catename";
            this.txt_catename.Size = new System.Drawing.Size(304, 30);
            this.txt_catename.TabIndex = 13;
            // 
            // txt_cateid
            // 
            this.txt_cateid.Location = new System.Drawing.Point(116, 42);
            this.txt_cateid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_cateid.Name = "txt_cateid";
            this.txt_cateid.Size = new System.Drawing.Size(304, 30);
            this.txt_cateid.TabIndex = 12;
            // 
            // btn_out
            // 
            this.btn_out.Location = new System.Drawing.Point(609, 92);
            this.btn_out.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new System.Drawing.Size(139, 31);
            this.btn_out.TabIndex = 11;
            this.btn_out.Text = "Thoát";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(444, 92);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(139, 31);
            this.btn_xoa.TabIndex = 10;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(609, 44);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(139, 31);
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Text = "Sửa";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(444, 44);
            this.btn_them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(139, 31);
            this.btn_them.TabIndex = 8;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // Category_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1067, 606);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_frmCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Category_Management";
            this.Text = "Category_Management";
            this.Load += new System.EventHandler(this.Category_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_frmCategory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_frmCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.TextBox txt_catename;
        private System.Windows.Forms.TextBox txt_cateid;
        private System.Windows.Forms.Button btn_out;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}