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

    public partial class FrmChiTietHDN : Form
    {
        DataTable tableChiTietHDN;
        
        public FrmChiTietHDN()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaGD;
            cboSoHDN.Text = dataGridView1.CurrentRow.Cells["SoHDN"].Value.ToString();
            MaGD = dataGridView1.CurrentRow.Cells["MaGD"].Value.ToString();
            cboMaGD.Text = Functions.GetFieldValues("select MaGD, TenGD from SanPham where MaGD='" + MaGD + "'");
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGia.Text = dataGridView1.CurrentRow.Cells["DonGia"].Value.ToString();
            txtGiamGia.Text = dataGridView1.CurrentRow.Cells["GiamGia"].Value.ToString();
            txtThanhTien.Text = dataGridView1.CurrentRow.Cells["ThanhTien"].Value.ToString();
            cboSoHDN.Enabled = false;
            
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            cboSoHDN.Enabled = true;
            cboSoHDN.Focus();
            btnLuu.Enabled = true;
        }
        private void ResetValues()
        {
            cboSoHDN.Text = "";
            cboMaGD.Text = "";
            txtGiamGia.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            string sql;
            if(tableChiTietHDN.Rows.Count==0)
            {
                MessageBox.Show("không còn dữ liệu!!!");
            }
            if(cboMaGD.Text=="")
            {
                MessageBox.Show("bạn chưa nhập mã giày dép");
                cboMaGD.Focus();
            }
            if(txtDonGia.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá");
                txtDonGia.Focus();
            }
            if (txtGiamGia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giảm giá");
                txtGiamGia.Focus();
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng");
                txtSoLuong.Focus();
            }
            if (txtThanhTien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thành tiền");
                txtThanhTien.Focus();
            }
            sql="update ChiTietHDN set SoHDN='" +cboSoHDN+"', '" + cboMaGD.Text + "', '"
                   + txtSoLuong.Text + "', '" + txtDonGia.Text + "', '" + txtGiamGia.Text + "', '" + txtThanhTien.Text + "'";
            Functions.RunSQL(sql);
            loadDataGridView();
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            if(tableChiTietHDN.Rows.Count==0)
            {
                MessageBox.Show("không có dữ liệu");
            }
            if(cboSoHDN.Text=="")
            {
                MessageBox.Show("bạn chưa chọn bản ghi nào");
            }
            string sql = "delete from ChiTietHDN where SoHDN= '" + cboSoHDN.Text + "'";
            Functions.RunSqlDel(sql);
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            cboSoHDN.Enabled = false;
            cboMaGD.Enabled = false;
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            string sql, sql1, sql2;
            if (cboSoHDN.Text == "")
            {
                MessageBox.Show("Hãy nhập số hóa đơn nhập");
                cboSoHDN.Focus();
                return;
            }
            if (cboMaGD.Text == "")
            {
                MessageBox.Show("Hãy nhập mã giày dép");
                cboMaGD.Focus();
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Hãy nhập số lượng");
                txtSoLuong.Focus();
            }
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Hãy nhập đơn giá");
                txtDonGia.Focus();
            }
            if (txtGiamGia.Text == "")
            {
                MessageBox.Show("Hãy nhập số tiền giảm giá");
                txtGiamGia.Focus();
            }
            if (txtThanhTien.Text == "")
            {
                MessageBox.Show("Hãy nhập số tiền khách hàng phải trả");
                txtThanhTien.Focus();
            }
            
            sql1 = "Select SoHDN from ChiTietHDN where SoHDN='" + cboSoHDN.Text + "'";
            sql2 = "select MaGD from ChiTietHDN where MaGD= '" + cboMaGD.Text + "'";
            if (Functions.CheckKey(sql1)&&(Functions.CheckKey(sql2)))
            {
                MessageBox.Show("Số hóa đơn này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSoHDN.Focus();
                return;
            }
            sql = "Insert into ChiTietHDN values ('" + cboSoHDN.Text + "', '" + cboMaGD.Text + "', '"
                   + txtSoLuong.Text + "', '" + txtDonGia.Text + "', '" + txtGiamGia.Text + "', '" + txtThanhTien.Text + "'";
            Functions.RunSQL(sql);
            loadDataGridView();
            ResetValues();
            
        }

        private void FrmChiTietHDN_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("select SoHDN from HoaDonNhap", cboSoHDN, "SoHDN");
            cboSoHDN.SelectedIndex = -1;
            Functions.FillCombo1("select MaGD, TenGD from SanPham", cboMaGD, "MaGD", "TenGD");
            cboMaGD.SelectedIndex = -1;
            cboSoHDN.Enabled = false;
            loadDataGridView();
        }
        private void loadDataGridView()
        {
            string sql = "select *from ChiTietHDN";
            tableChiTietHDN = Functions.GetDataToTable(sql);
            
            dataGridView1.DataSource = tableChiTietHDN;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}

    

    
       

