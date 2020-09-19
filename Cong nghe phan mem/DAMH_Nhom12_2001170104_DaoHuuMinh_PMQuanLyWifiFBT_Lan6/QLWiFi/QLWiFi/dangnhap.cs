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
    public partial class dangnhap : Form
    {
        
        KH kh = new KH();
        NVKT nvkt = new NVKT();
        NVTC nvtc = new NVTC();
        NVTD nvtd = new NVTD();
        Admin ad = new Admin();
        SqlConnection connsql;
        
        public dangnhap()
        {
            
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
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
            else if (cbbloai.SelectedItem.ToString() == "Admin")
            { loaidn = "select taikhoan from taikhoan,nhanvien where taikhoan.manv= nhanvien.manv and taikhoan = '" + TenDN + "' and matkhau ='" + MK + "' and nhanvien.macv = 'CV04'"; }
            else { loaidn = "select taikhoan from taikhoan,nhanvien where taikhoan.manv= nhanvien.manv and taikhoan = '" + TenDN + "' and matkhau ='" + MK + "' and nhanvien.macv = 'CV03'"; }
            connsql.Open();
            string selectString = loaidn;

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
        public void loai(string cbl)
        {

            if (cbl == "Khách hàng") 
            {
                kh.Show();
                this.Hide();
            
            }
            else if (cbl == "Nhân viên kỹ thuật")
            {
                nvkt.Show();
                this.Hide();
            }
            else if (cbl == "Nhân viên tổng đài")
            {
                nvtd.Show();
                this.Hide();
            }
            else if (cbl == "Admin")
            {
                ad.Show();
                this.Hide();
            }
            else {
                nvtc.Show();
                this.Hide();
            }
        }
        private void dangnhap_Load(object sender, EventArgs e)
        {

        }
        public static string tk;
        
        
        public string gan_sdt()
        {
            return tk;
        }

        private void btdangnhap_Click(object sender, EventArgs e)
        {
            tk = txttk.Text.Trim();
            if (cbbloai.Text.ToString() == "chọn loại")
            {
                MessageBox.Show("Vui lòng chọn loại đăng nhập !!");

            }
            else
            {
                string cbl = cbbloai.SelectedItem.ToString();
                if (KT_DN(txttk.Text.ToString(), txtmk.Text.ToString()) == true)
                {
                    loai(cbl);
                }
                else MessageBox.Show("Tài khoản hoặc mật khẩu sai !!");
            }
        }

        private void dmk_Click(object sender, EventArgs e)
        {
            DoiMK dmk = new DoiMK();
            dmk.Show();
            this.Hide();
        }

       

       
    }
}
