using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class FrmPhong : Form
    {
        
        SqlConnection con = new SqlConnection();
        public FrmPhong()
        {
            InitializeComponent();
        }
        private void FrmPhong_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ADMIN;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
            con.ConnectionString = connectionString;
            con.Open();

            loadDataGridview();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.Text = dataGridView1.CurrentRow.Cells["MaPhong"].Value.ToString();
            txtTenPhong.Text = dataGridView1.CurrentRow.Cells["TenPhong"].Value.ToString();
            txtDonGia.Text = dataGridView1.CurrentRow.Cells["DonGia"].Value.ToString();
            txtMaPhong.Enabled = false;
        }
        private void loadDataGridview()
        {
            string sql = "select * from Phong";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tablePhong = new DataTable();
            adp.Fill(tablePhong);

            dataGridView1.DataSource = tablePhong;
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
                string sql = "Delete from Phong where MaPhong = '" + txtMaPhong.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                loadDataGridview();
            
            
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(((e.KeyChar>='0')&& (e.KeyChar<='9'))||
            (Convert.ToInt32(e.KeyChar)==8)|| (Convert.ToInt32(e.KeyChar)==13))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            txtDonGia.Text = "";
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtMaPhong.Enabled = true;
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            if(txtMaPhong.Text=="")
            {
                MessageBox.Show("Bạn cần phải nhập mã phòng");
                txtMaPhong.Focus();
                return;
            }
            if(txtTenPhong.Text =="")
            {
                MessageBox.Show("Bạn cần phải nhập tên phòng");
                txtTenPhong.Focus();
            }
            if(txtDonGia.Text=="")
            {
                MessageBox.Show("Bạn cần phải nhập đơn giá");
                txtDonGia.Focus();
            }

            string sql = "select MaPhong from Phong where MaPhong = '" + txtMaPhong.Text + "'";
            if(CheckKey(sql))
            {
                MessageBox.Show("Mã phòng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                txtMaPhong.Text = "";
                return;
            }
            else
            {
                 sql = "insert into Phong values('" + txtMaPhong.Text + "', '" + txtTenPhong.Text + "'";
                if (txtDonGia.Text != "")
                    sql = sql + ", " + txtDonGia.Text.Trim();
                sql = sql + ")";
            }
            MessageBox.Show(sql);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loadDataGridview();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            txtMaPhong.ReadOnly = true;

            string sql = "update Phong set TenPhong = '" + txtTenPhong.Text.ToString() + "', "
                + "DonGia = '" + txtDonGia.Text.ToString() + "'where MaPhong = '" + txtMaPhong.Text + "'";
            MessageBox.Show(sql);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            loadDataGridview();
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            bntHuy.Enabled = false;
            bntThem.Enabled = true;
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtDonGia.Text = ""; 
            loadDataGridview();
        }
        private bool CheckKey(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tablePhong = new DataTable();
            adp.Fill(tablePhong);
            if (tablePhong.Rows.Count > 0)
                return true;
            else return false;
        }
    }
}
