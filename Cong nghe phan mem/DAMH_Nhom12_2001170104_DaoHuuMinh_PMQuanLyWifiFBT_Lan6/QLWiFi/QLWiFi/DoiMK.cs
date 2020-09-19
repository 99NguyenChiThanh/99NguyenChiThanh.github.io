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
    public partial class DoiMK : Form
    {
        SqlConnection connsql;
        public DoiMK()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            connsql = new SqlConnection(cnn);
        }
        public bool KT_DN(string TenDN, string MK)
        {
            string loaidn;
            if (cbbloai.SelectedItem.ToString() == "Khách hàng")
            { loaidn = "select taikhoan from taikhoan,khachhang where khachhang.makh= taikhoan.makh and taikhoan = '" + TenDN + "' and matkhau ='" + MK + "'"; }
            else if (cbbloai.SelectedItem.ToString() == "Nhân viên kỹ thuật")
            { loaidn = "select taikhoan from taikhoan,nhanvien where taikhoan.manv= nhanvien.manv and taikhoan = '" + TenDN + "' and matkhau ='" + MK + "' and nhanvien.macv = 'CV01'"; }
            else if (cbbloai.SelectedItem.ToString() == "Nhân viên tổng đài")
            { loaidn = "select taikhoan from taikhoan,nhanvien where taikhoan.manv= nhanvien.manv and taikhoan = '" + TenDN + "' and matkhau ='" + MK + "' and nhanvien.macv = 'CV02'"; }
            else { loaidn = "select taikhoan from taikhoan,nhanvien where taikhoan.manv= nhanvien.manv and taikhoan = '" + TenDN + "' and matkhau ='" + MK + "' and nhanvien.macv = 'CV03'"; }
            
            string selectString = loaidn;
            connsql.Open();
            SqlCommand cmd = new SqlCommand(selectString, connsql);
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                rd.Close();
                connsql.Close();
                return true;

            }
            else
            {
                rd.Close();
                connsql.Close();
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (cbbloai.Text.ToString() == "chọn loại")
            {
                MessageBox.Show("Vui lòng chọn loại !!");
                this.Show();

            }
            else
            {
                
                
                string updateString;
                if (KT_DN(txtdtk.Text.ToString(), txtmkc.Text.ToString()) == true)
                {
                    connsql.Open();
                    if (txtmkm.Text.ToString() == txtmkm1.Text.ToString())
                    {

                        updateString = "update taikhoan set matkhau = '" + txtmkm1.Text.ToString() + "' where taikhoan ='" + txtdtk.Text.ToString() + "'";
                        SqlCommand cmd = new SqlCommand(updateString, connsql);
                        cmd.ExecuteNonQuery();
                        connsql.Close();
                        MessageBox.Show("Đổi mật khẩu thành công");
                        dangnhap dn = new dangnhap();
                        dn.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới và nhập lại phải giống nhau !!");
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại vui lòng nhập lại !!");
                    this.Show();
                }

                

            }            

            
            
            
                 
        }

        private void DoiMK_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dangnhap dn = new dangnhap();
            dn.Show();
            this.Close();
        }
    }
}
