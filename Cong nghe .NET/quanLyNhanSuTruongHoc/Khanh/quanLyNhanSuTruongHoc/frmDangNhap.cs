using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace quanLyNhanSuTruongHoc
{
    public partial class frmDangNhap : Form
    {
        DataTable dt;
        SqlDataAdapter da;
        KetNoi kn = new KetNoi();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public void btnDangNhap_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = check(txtTenDangNhap.Text, txtMatKhau.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công ");
                this.Close();
                foreach (DataRow row in dt.Rows)
                {
                    session.username = row["MANV"].ToString().Trim();
                    session.pass = row["MATKHAU"].ToString().Trim();
                    session.name = row["TENNV"].ToString().Trim();
                    session.per = row["QUYEN"].ToString().Trim();
                    session.hinh = row["HINH"].ToString().Trim();
                    session.bacluong = row["BACLUONG"].ToString().Trim();
                    session.hocvan = row["TENTDHV"].ToString().Trim();
                    session.chucvu = row["TENCV"].ToString().Trim();
                    session.phongban = row["TENPB"].ToString().Trim();
                    session.sdt = row["SDT"].ToString().Trim();
                    session.dantoc = row["DANTOC"].ToString().Trim();
                    session.ngsinh = row["NGSINH"].ToString().Trim();
                    session.quequan = row["QUEQUAN"].ToString().Trim();
                    session.gioitinh = row["GT"].ToString().Trim();
                    frmTrangChu fr = new frmTrangChu();
                    fr.trangChủToolStripMenuItem_Click(btnDangNhap, e);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                txtTenDangNhap.Clear();
                txtMatKhau.Clear();
                txtTenDangNhap.Focus();
            }
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
        
        }
        
        public DataTable check(string user, string pass)
        {
            string str = "select * from NHANVIEN nv, PHONGBAN pb, CHUCVU cv, TDHV hv where MANV = '" + txtTenDangNhap.Text + "' and MATKHAU = '" + txtMatKhau.Text + "' and nv.MAPB = pb.MAPB and nv.MACV=cv.MACV and nv.MATDHV = hv.MATDHV";
            da = new SqlDataAdapter(str, kn.getConnection());
            da.Fill(dt);
            return dt;
        }

    }
}
