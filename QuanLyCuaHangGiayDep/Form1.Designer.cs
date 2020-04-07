namespace QuanLyCuaHangGiayDep
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SoHDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bntSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhapMaGD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoHDN,
            this.MaGD,
            this.SoLuong,
            this.DonGia,
            this.GiamGia,
            this.ThanhTien});
            this.dataGridView1.Location = new System.Drawing.Point(12, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(627, 150);
            this.dataGridView1.TabIndex = 11;
            // 
            // SoHDN
            // 
            this.SoHDN.DataPropertyName = "SoHDN";
            this.SoHDN.HeaderText = "Số Hóa Đơn Nhập";
            this.SoHDN.Name = "SoHDN";
            // 
            // MaGD
            // 
            this.MaGD.DataPropertyName = "MaGD";
            this.MaGD.HeaderText = "Mã Giày Dép";
            this.MaGD.Name = "MaGD";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.Name = "DonGia";
            // 
            // GiamGia
            // 
            this.GiamGia.DataPropertyName = "GiamGia";
            this.GiamGia.HeaderText = "Giảm Giá";
            this.GiamGia.Name = "GiamGia";
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.Name = "ThanhTien";
            // 
            // bntSearch
            // 
            this.bntSearch.Location = new System.Drawing.Point(169, 109);
            this.bntSearch.Name = "bntSearch";
            this.bntSearch.Size = new System.Drawing.Size(75, 23);
            this.bntSearch.TabIndex = 12;
            this.bntSearch.Text = "Search";
            this.bntSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nhập mã GD";
            // 
            // txtNhapMaGD
            // 
            this.txtNhapMaGD.Location = new System.Drawing.Point(143, 66);
            this.txtNhapMaGD.Name = "txtNhapMaGD";
            this.txtNhapMaGD.Size = new System.Drawing.Size(143, 20);
            this.txtNhapMaGD.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(219, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tìm kiếm thông tin sản phẩm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNhapMaGD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.Button bntSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNhapMaGD;
        private System.Windows.Forms.Label label2;
    }
}

