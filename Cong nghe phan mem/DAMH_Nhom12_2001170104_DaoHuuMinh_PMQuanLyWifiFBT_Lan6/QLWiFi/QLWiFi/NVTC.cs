﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLWiFi
{
    public partial class NVTC : Form
    {
        SqlConnection cn;
        public NVTC()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            cn = new SqlConnection(cnn);
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangnhap dn = new dangnhap();
            dn.ShowDialog();
            this.Close();
        }

        private void thoat_Click_1(object sender, EventArgs e)
        {
            dangnhap dn = new dangnhap();
            dn.Show();
            this.Close();
        }

        private void NVTC_Load(object sender, EventArgs e)
        {
            //cn = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS; Initial Catalog=QL_INTERNET1; Integrated Security=True;");
            //cn = new SqlConnection(@"Data Source=TOSHIBA-SATELLI; Initial Catalog=QL_INTERNET1; Integrated Security=True;");

            cn.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sele = "Select nv.Manv, Tennv, gioitinh, luong, tencv, diachinv, sdtnv, ngaysinh from Nhanvien nv, Chucvu cv where SDTnv = '" + sdt + "' and nv.Macv = cv.Macv";
            //string sele = "Select nv.Manv, Tennv, gioitinh, luong, tencv, diachinv, sdtnv, ngaysinh from Nhanvien nv, Chucvu cv where SDTnv = '0919395758' and nv.Macv = cv.Macv";
            SqlCommand cm = new SqlCommand(sele, cn);
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                label1.Text = "Chào " + rd["Tennv"].ToString() + ",";
                label2.Text = label2.Text + " " + rd["Manv"].ToString();
                label9.Text = label9.Text + " " + rd["Tennv"].ToString();
                label3.Text = label3.Text + " " + rd["gioitinh"].ToString();
                label4.Text = label4.Text + " " + rd["luong"].ToString();
                label7.Text = label7.Text + " " + rd["tencv"].ToString();
                label6.Text = label6.Text + " " + rd["diachinv"].ToString();
                label8.Text = label8.Text + " " + rd["sdtnv"].ToString();
                label5.Text = label5.Text + " " + rd["ngaysinh"].ToString();
            }
            cn.Close();

            //richTextBox1.Text = "Đây là một tính năng.";
            cboTrangthai.SelectedIndex = 0;

            cn.Open();
            sele = "";
            sele = sele + "Select kh.makh 'Mã khách hàng', tenkh 'Họ tên', sdt 'SĐT', diachi 'Địa chỉ', ngayhen 'Ngày hẹn', cthd.magc 'Gói cước', thanhtien 'Thành tiền', ht.trangthai 'Trạng thái', yeucau 'Yêu cầu' ";
            sele = sele + "from hotro ht, khachhang kh, hoadon hd, cthd ";
            sele = sele + "where ht.makh = kh.makh and kh.makh = hd.makh and hd.mahd = cthd.mahd and ht.manv = '" + label2.Text.Substring(7) + "'";
            //1 hỗ trợ thu cước có 1 khách hàng 1 hóa đơn 1 nv hỗ trợ + lập hóa đơn; Hoadon, Chitiethoadon quan hệ 1-1
            SqlDataAdapter da = new SqlDataAdapter(sele, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView1.Enabled = false;
                txtMakh.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtHoten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtNgayhen.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtGoicuoc.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtThanhtien.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                cboTrangthai.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                dataGridView1.Enabled = true;
            }
        }
        void Khoaitimbungtay()
        {
            txtMakh.Text = txtHoten.Text = txtSDT.Text = txtDiachi.Text = txtNgayhen.Text = txtGoicuoc.Text = txtThanhtien.Text = "";
            cboTrangthai.SelectedItem = "Chưa hỗ trợ";
            txtMakh.Focus();

            string sele = "";
            sele = sele + "Select kh.makh 'Mã khách hàng', tenkh 'Họ tên', sdt 'SĐT', diachi 'Địa chỉ', ngayhen 'Ngày hẹn', cthd.magc 'Gói cước', thanhtien 'Thành tiền', ht.trangthai 'Trạng thái', yeucau 'Yêu cầu' ";
            sele = sele + "from hotro ht, khachhang kh, hoadon hd, cthd ";
            sele = sele + "where ht.makh = kh.makh and kh.makh = hd.makh and hd.mahd = cthd.mahd and ht.manv = '" + label2.Text.Substring(7) + "'";
            SqlDataAdapter da = new SqlDataAdapter(sele, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMakh.Text != "" && cboTrangthai.SelectedIndex == 1)
            {
                try
                {
                    cn.Open();

                    DateTime date = DateTime.UtcNow.Date;
                    string ngaythHientai = date.ToString("MM/dd/yyyy");

                    string sua = "Update hoadon set NgayLapHD = '" + ngaythHientai + "', trangthai = N'Đã thanh toán' where makh = '" + txtMakh.Text + "' and manv = '" + label2.Text.Substring(7) + "' and trangthai = 'Chưa thanh toán'; Update hotro set Trangthai = N'" + cboTrangthai.SelectedItem + "' where makh = '" + txtMakh.Text + "' and manv = '" + label2.Text.Substring(7) + "'";
                    SqlCommand cmd = new SqlCommand(sua, cn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Lưu thành công.");
                    Khoaitimbungtay();
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lưu thất bại.");
                    Khoaitimbungtay();
                    cn.Close();
                }
            }
        }
    }
}
