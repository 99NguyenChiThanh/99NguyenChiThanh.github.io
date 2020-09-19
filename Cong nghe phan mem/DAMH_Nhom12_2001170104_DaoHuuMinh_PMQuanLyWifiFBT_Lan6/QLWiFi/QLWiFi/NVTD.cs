using System;
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
    public partial class NVTD : Form
    {
        SqlConnection cn;
        public NVTD()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            cn = new SqlConnection(cnn);
        }

        private void NVTD_Load(object sender, EventArgs e)
        {

            //cn = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS; Initial Catalog=QL_INTERNET1; Integrated Security=True;");

            cn.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sele = "Select nv.Manv, Tennv, gioitinh, luong, tencv, diachinv, sdtnv, ngaysinh from Nhanvien nv, Chucvu cv where SDTnv = '" + sdt + "' and nv.Macv = cv.Macv";
            //string sele = "Select nv.Manv, Tennv, gioitinh, luong, tencv, diachi, sdt, ngaysinh from Nhanvien nv, Chucvu cv where SDT = '0856218771' and nv.Macv = cv.Macv";
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
        }

        private void ttnv_Click(object sender, EventArgs e)
        
        {
            
        }

        private void dskh_Click(object sender, EventArgs e)
        {
         
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            dangnhap dn = new dangnhap();
            dn.Show();
            this.Close();
        }
        void Khoaitimbungtay()
        {
            txtMakh.Text = txtHoten.Text = txtGoicuoc.Text = txtDiachi.Text = txtSDT.Text = "";
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            Khoaitimbungtay();
            try
            {
                cn.Open();
                string sele = "Select count(*) from KhachHang where Makh = '" + txtTimkiem.Text.Trim() + "'";
                SqlCommand cm = new SqlCommand(sele, cn);
                int n = (int)cm.ExecuteScalar();
                if (n > 0)
                {
                    sele = "Select Makh, Tenkh, diachi, sdt from KhachHang where Makh = '" + txtTimkiem.Text.Trim() + "'";
                    cm = new SqlCommand(sele, cn);
                    SqlDataReader rd = cm.ExecuteReader();
                    while (rd.Read())
                    {
                        txtMakh.Text = rd["MAKH"].ToString();
                        txtHoten.Text = rd["TENKH"].ToString();
                        txtDiachi.Text = rd["DIACHI"].ToString();
                        txtSDT.Text = rd["SDT"].ToString();
                        txtMakh2.Text = rd["MAKH"].ToString();
                    }
                    cn.Close();

                    cn.Open();
                    sele = "Select Magc from Hoadon hd, cthd where hd.mahd = cthd.mahd and Makh = '" + txtTimkiem.Text.Trim() + "'";
                    cm = new SqlCommand(sele, cn);
                    rd = cm.ExecuteReader();
                    while (rd.Read())
                    {
                        txtGoicuoc.Text = rd["MAGC"].ToString();
                    }
                }
                else
                    throw new Exception();
                txtTimkiem.Text = "";
                txtTimkiem.Focus();
                cn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Khách hàng không tồn tại.");
                txtTimkiem.Text = "";
                txtTimkiem.Focus();
                cn.Close();
            }
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (txtMakh.Text != "")
            {
                try
                {
                    cn.Open();

                    string sua = "Update KhachHang set Tenkh = N'" + txtHoten.Text.Trim() + "', Diachi = N'" + txtDiachi.Text.Trim() + "', sdt = '" + txtSDT.Text.Trim() + "' where makh = '" + txtMakh.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(sua, cn);
                    cmd.ExecuteNonQuery();

                    sua = "Update Taikhoan set Taikhoan = '" + txtSDT.Text.Trim() + "' where makh = '" + txtMakh.Text.Trim() + "'";
                    cmd = new SqlCommand(sua, cn);
                    cmd.ExecuteNonQuery();

                    sua = "Update wifi set Taikhoanwifi = '" + txtSDT.Text.Trim() + "' where makh = '" + txtMakh.Text.Trim() + "'";
                    cmd = new SqlCommand(sua, cn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Lưu thành công.");
                    Khoaitimbungtay();
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lưu thất bại.");
                    txtMakh.Focus();
                    cn.Close();
                }
            }
            else
                Khoaitimbungtay();
        }

        private void btnYeucau_Click(object sender, EventArgs e)
        {
            if (txtMakh2.Text != "" && txtGoicuoc.Text != "" && cboYeucau.Text != "" && txtNgayhen.Text != "")
            {
                try
                {
                    cn.Open();
                    string sele = "Select count(*) from Hotro where Makh = '" + txtMakh2.Text.Trim() + "' and manv = 'nv001' and TrangThai = N'Chưa hỗ trợ'";
                    SqlCommand cm = new SqlCommand(sele, cn);
                    int n = (int)cm.ExecuteScalar();
                    if (n > 0)
                    {
                        MessageBox.Show("Yêu cầu đã tồn tại.");
                        txtNgayhen.Text = cboYeucau.Text = "";
                    }
                    else
                    {
                        string insert = "SET DATEFORMAT DMY INSERT INTO HoTro(MaNV,MaKH,NgayHen,TrangThai,YeuCau) values ('NV001','" + txtMakh2.Text.Trim() + "','" + txtNgayhen.Text + "',N'Chưa hỗ trợ',N'" + cboYeucau.SelectedItem + "')";
                        SqlCommand cmd = new SqlCommand(insert, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Lưu thành công.");
                        txtNgayhen.Text = cboYeucau.Text = "";
                    }
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lưu thất bại.");
                    cn.Close();
                }
            }
            else
                MessageBox.Show("Mã khách hàng, mã gói cước, yêu cầu, ngày hẹn không được trống.");
        }
    }
}
