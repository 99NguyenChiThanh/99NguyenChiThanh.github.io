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
using System.IO;
using System.Threading;

namespace quanLyNhanSuTruongHoc
{
    public partial class frmTrangChu : Form
    {
        Thread th;
        KetNoi kn = new KetNoi();
        public frmTrangChu()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }
        public void tạoThêmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            th = new Thread(openNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openNewForm(object obj)
        {
            Application.Run(new addNhanVien());
        }

        public void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(returnHome);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void returnHome(object obj)
        {
            Application.Run(new frmTrangChu());
        }

        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs;
            rs = MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (rs == DialogResult.No)
                e.Cancel = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            th = new Thread(DangNhap);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void DangNhap(object obj)
        {
            Application.Run(new frmDangNhap());
        }

        private void button5_Click(object sender, EventArgs e)
        {
                this.Dispose();
                frmTrangChu tc = new frmTrangChu();
                tc.tạoThêmNhânViênToolStripMenuItem_Click(btnThem, e);
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            SqlConnection conn = kn.getConnection();
            string load = "select * from NHANVIEN,THONGTINKHAC where NHANVIEN.MANV = THONGTINKHAC.MANV AND NHANVIEN.MANV='" + session.username + "'";
            SqlDataAdapter da = new SqlDataAdapter(load, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                tbSDT.Text = dr["SDT"].ToString().Trim();
                tbMK.Text = dr["MATKHAU"].ToString().Trim();
                tbHonNhan.Text = dr["TTHONNHAN"].ToString().Trim();
                tbnoicap.Text = dr["NOICAP"].ToString();
                tbThue.Text = dr["MASOTHUE"].ToString().Trim();
                tbCMND.Text = dr["CMND"].ToString().Trim();
            }
            if (session.per == "user")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                tậpTinToolStripMenuItem.Enabled = false;
                btUngVien.Enabled = false;
                label1.Text = "Xin chào " + session.name;
            }
            else
            {
                label1.Text = "Xin chào " + session.name;
            }

            //pictureBox1.Image = Image.FromFile(@"C:\Users\DELL\Desktop\quanLyNhanSuTruongHoc\quanLyNhanSuTruongHoc\Resources\Hinh10.jpg");
            string path = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
            pictureBox1.Image = Image.FromFile( path + session.hinh);
            //pictureBox1.Image = Image.FromFile(@"C:\Users\DELL\Desktop\quanLyNhanSuTruongHoc\quanLyNhanSuTruongHoc\Resources\Hinh5.jpg");
            lbHoTen.Text = session.name;
            lbMa.Text = session.username;
            lbLuong.Text = session.bacluong;
            lbTDHV.Text = session.hocvan;
            lbChucVu.Text = session.chucvu;
            lbPhong.Text = session.phongban;
            lbSDT.Text = session.sdt;
            lbDT.Text = session.dantoc;
            lbNamSinh.Text = session.ngsinh;
            lbQue.Text = session.quequan;
            lbGT.Text = session.gioitinh;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.Dispose();
            th = new Thread(SUA);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void SUA(object obj)
        {
            Application.Run(new Sua());
        }

        private void btUngVien_Click(object sender, EventArgs e)
        {
            this.Dispose();
            th = new Thread(DIEMDANH);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void DIEMDANH(object obj)
        {
            Application.Run(new DiemDanh());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Dispose();
            th = new Thread(XOA);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void XOA(object obj)
        {
            Application.Run(new Xoa());
        }

        private void btSuaUser_Click(object sender, EventArgs e)
        {
            string strpass = "update NHANVIEN set MATKHAU = '" + tbMK.Text + "',SDT='" + tbSDT.Text + "' where MANV = '" + session.username + "'";
            string strTTK = "update THONGTINKHAC set CMND='"+tbCMND.Text+"',NGAYCAP='"+dateTimePicker1.Value.ToShortDateString()+"',NOICAP=N'"+tbnoicap.Text+"',MASOTHUE='"+tbThue.Text+"',NGAYVAOLAM='"+dateTimePicker2.Value.ToShortDateString()+"',TTHONNHAN=N'"+tbHonNhan.Text+"' where MANV='"+session.username+"'";
            SqlConnection connn = kn.getConnection();
            SqlCommand da = new SqlCommand(strTTK, connn);
            SqlCommand da2 = new SqlCommand(strpass, connn);
            if(connn.State == ConnectionState.Closed)
            {
                connn.Open();
            }
            da.ExecuteNonQuery();
            da2.ExecuteNonQuery();
            connn.Close();
            MessageBox.Show("Cập nhật thành công", "Thông báo");
        }
        //void load_textBoxLuong()
        /*{
            string str = "select count(*) as Luong from DIEMDANH where  MANV='"+session.username+"' and DD=N'Vắng' group by(MANV)" + session.username + "'";
            SqlConnection luong = kn.getConnection();
            DataTable tbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(str,luong);
            da.Fill(tbl);
                if (tbl.Rows.["Luong"] == null)
                    textBox1.Text = "0";
                else
                    textBox1.Text = dr.["Luong"].ToString();
        }*/
    }
}
