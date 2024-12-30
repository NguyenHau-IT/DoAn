namespace DoAn
{
    partial class OrderDetail_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetail_Management));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbProductSize = new System.Windows.Forms.ComboBox();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblProductSizeID = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblOrderDetailID = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProductSize = new System.Windows.Forms.DataGridView();
            this.btnBill = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btnBill);
            this.groupBox1.Controls.Add(this.cmbProductSize);
            this.groupBox1.Controls.Add(this.cmbOrder);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.lblQuantity);
            this.groupBox1.Controls.Add(this.lblProductSizeID);
            this.groupBox1.Controls.Add(this.lblOrderID);
            this.groupBox1.Controls.Add(this.lblOrderDetailID);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1148, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // cmbProductSize
            // 
            this.cmbProductSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbProductSize.FormattingEnabled = true;
            this.cmbProductSize.Location = new System.Drawing.Point(205, 139);
            this.cmbProductSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbProductSize.Name = "cmbProductSize";
            this.cmbProductSize.Size = new System.Drawing.Size(160, 33);
            this.cmbProductSize.TabIndex = 25;
            // 
            // cmbOrder
            // 
            this.cmbOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Location = new System.Drawing.Point(205, 90);
            this.cmbOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(160, 33);
            this.cmbOrder.TabIndex = 24;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(205, 42);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(160, 34);
            this.txtID.TabIndex = 23;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(431, 48);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(109, 29);
            this.lblQuantity.TabIndex = 22;
            this.lblQuantity.Text = "Số lượng";
            // 
            // lblProductSizeID
            // 
            this.lblProductSizeID.AutoSize = true;
            this.lblProductSizeID.Location = new System.Drawing.Point(8, 138);
            this.lblProductSizeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductSizeID.Name = "lblProductSizeID";
            this.lblProductSizeID.Size = new System.Drawing.Size(181, 29);
            this.lblProductSizeID.TabIndex = 21;
            this.lblProductSizeID.Text = "Mã thông tin SP";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(8, 89);
            this.lblOrderID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(144, 29);
            this.lblOrderID.TabIndex = 20;
            this.lblOrderID.Text = "Mã đặt hàng";
            // 
            // lblOrderDetailID
            // 
            this.lblOrderDetailID.AutoSize = true;
            this.lblOrderDetailID.Location = new System.Drawing.Point(8, 44);
            this.lblOrderDetailID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderDetailID.Name = "lblOrderDetailID";
            this.lblOrderDetailID.Size = new System.Drawing.Size(121, 29);
            this.lblOrderDetailID.TabIndex = 19;
            this.lblOrderDetailID.Text = "Mã chi tiết";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(769, 135);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 38);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(629, 137);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(108, 37);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(489, 135);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 37);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(556, 44);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(127, 34);
            this.txtQuantity.TabIndex = 15;
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvOrderDetails.Location = new System.Drawing.Point(13, 213);
            this.dgvOrderDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.Size = new System.Drawing.Size(1151, 256);
            this.dgvOrderDetails.TabIndex = 1;
            this.dgvOrderDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDTs_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(11, 473);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh sách thông tin sản phẩm";
            // 
            // dgvProductSize
            // 
            this.dgvProductSize.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductSize.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvProductSize.Location = new System.Drawing.Point(16, 506);
            this.dgvProductSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProductSize.Name = "dgvProductSize";
            this.dgvProductSize.RowHeadersWidth = 51;
            this.dgvProductSize.Size = new System.Drawing.Size(1148, 256);
            this.dgvProductSize.TabIndex = 3;
            // 
            // btnBill
            // 
            this.btnBill.Location = new System.Drawing.Point(915, 134);
            this.btnBill.Margin = new System.Windows.Forms.Padding(4);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(190, 38);
            this.btnBill.TabIndex = 26;
            this.btnBill.Text = "Xuát hoá đơn";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // OrderDetail_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1180, 779);
            this.Controls.Add(this.dgvProductSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOrderDetails);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OrderDetail_Management";
            this.Text = "OrderDetail_Management";
            this.Load += new System.EventHandler(this.OrderDetail_Management_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblProductSizeID;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblOrderDetailID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cmbProductSize;
        private System.Windows.Forms.ComboBox cmbOrder;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProductSize;
        private System.Windows.Forms.Button btnBill;
    }
}