using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace QuanLyCuaHangGiayDep
{
    public partial class FrmHoaDonNhap : Form
    {
        DataTable tblHDN;
        public FrmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void FrmHoaDonNhap_Load(object sender, EventArgs e)
        {
            
            Functions.FillCombo1("select MaNV, TenNV from NhanVien", cboMaNV, "MaNV", "TenNV");
            cboMaNV.SelectedIndex = -1;
            Functions.FillCombo1("select MaNCC, TenNCC from NhaCungCap", cboMaNCC, "MaNCC", "TenNCC");
            cboMaNCC.SelectedIndex = -1;
            txtSoHDN.Enabled = false;
            loadDataGridView();
        }
        private void loadDataGridView()
        {
            string sql = "select *from HoaDonNhap";
            tblHDN = Functions.GetDataToTable(sql);

            dataGridView1.DataSource = tblHDN;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaNV,MaNCC;
            txtSoHDN.Text = dataGridView1.CurrentRow.Cells["SoHDN"].Value.ToString();
            MaNV = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
            cboMaNV.Text = Functions.GetFieldValues("select TenNV from NhanVien where MaNV='" + MaNV + "'");
            MaNCC = dataGridView1.CurrentRow.Cells["MaNCC"].Value.ToString();
            cboMaNV.Text = Functions.GetFieldValues("select TenNV from NhanVien where MaNCC='" + MaNCC + "'");
            mskNgayNhap.Text= dataGridView1.CurrentRow.Cells["NgayNhap"].Value.ToString();
            txtTongTien.Text = dataGridView1.CurrentRow.Cells["TongTien"].Value.ToString();
            txtSoHDN.Enabled = false;
        }
        private void ResetValues()
        {
            txtSoHDN.Text = "";
            cboMaNCC.Text = "";
            cboMaNV.Text = "";
            txtTongTien.Text = "";
            mskNgayNhap.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            txtSoHDN.Enabled = true;
            txtSoHDN.Focus();
            btnLuu.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("không còn dữ liệu!!!");
            }
            if (cboMaNV.Text == "")
            {
                MessageBox.Show("bạn chưa nhập mã nhân viên");
                cboMaNV.Focus();
            }
            if (cboMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nhà cung cấp");
                cboMaNCC.Focus();
            }
            if(mskNgayNhap.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập ngày tháng");
                mskNgayNhap.Focus();
            }
            if (txtTongTien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền");
                txtTongTien.Focus();
            }
            sql = "update HoaDonNhap set MaNV= '" + cboMaNV.SelectedValue.ToString() + "', NgayNhap='" + mskNgayNhap.Text
                + "', MaNCC= '" + cboMaNCC.SelectedValue.ToString() + "', TongTien='" + txtTongTien.Text;
            Functions.RunSQL(sql);
            loadDataGridView();
            ResetValues();
            btnHuy.Enabled = false;
         }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtSoHDN.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtSoHDN.Enabled = false;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("không còn dữ liệu!!!");
            }
            if (cboMaNV.Text == "")
            {
                MessageBox.Show("bạn chưa nhập mã nhân viên");
                cboMaNV.Focus();
            }
            if (cboMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nhà cung cấp");
                cboMaNCC.Focus();
            }
            if (mskNgayNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày tháng");
                mskNgayNhap.Focus();
            }
            if (txtTongTien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền");
                txtTongTien.Focus();
            }
            sql = "select SoHDN from HoaDonNhap where SoHDN='" + txtSoHDN.Text.Trim() + "'";
            if(Functions.CheckKey(sql))
            {
                MessageBox.Show("Số hóa đơn này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHDN.Focus();
                return;
            }
            sql = "insert into HoaDonNhap values('" + txtSoHDN.Text + "', '" + cboMaNV.SelectedValue.ToString() + "', '"
                + cboMaNCC.SelectedValue.ToString() + "', '" + txtTongTien.Text + "'" +")";
            Functions.RunSQL(sql);
            loadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtSoHDN.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();      
         }
    }
}
