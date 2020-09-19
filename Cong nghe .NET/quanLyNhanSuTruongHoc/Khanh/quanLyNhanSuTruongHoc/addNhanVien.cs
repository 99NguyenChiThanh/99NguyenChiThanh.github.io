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
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
namespace quanLyNhanSuTruongHoc
{
    public partial class addNhanVien : Form
    {
        Thread th;
        SqlCommand cmd,cmd2;
        DataTable dt;
        OpenFileDialog openFile = new OpenFileDialog();
        KetNoi kn = new KetNoi();
        public addNhanVien()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
        }

        private void addNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs;
            rs = MessageBox.Show("Chăc chắn thoát","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);

            if (rs == DialogResult.No)
                e.Cancel = true;
            else
            {
                this.Dispose();
                th = new Thread(openNewForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }
        private void openNewForm(object obj)
        {
            Application.Run(new frmTrangChu());
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmTrangChu tc = new frmTrangChu();
            tc.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNhanVien_Load(object sender, EventArgs e)
        {
            txtMK.Text = txtTaiKhoan.Text=tuTangMa();
            Load_cboChucVu();
            Load_cboHocVan();
            Load_cboPhongBan();
            load_cboGIOITINH();
            load_dtgridview();
            load_cbLuong();
            load_cbDanToc();
            load_quyen();
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLuu_Click_1(sender,e);
        }

        void load_quyen()
        {
            DataSet ds = new DataSet();
            string strselect = "SELECT * FROM Quyen";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.getConnection());
            da.Fill(ds, "Quyen");
            cbQuyen.DataSource = ds.Tables[0];
            cbQuyen.DisplayMember = "Quyen";
            cbQuyen.ValueMember = "Quyen";
        }
        void Load_cboPhongBan()
        {
            DataSet ds = new DataSet();
            string strselect = "SELECT * FROM PHONGBAN";
            SqlDataAdapter da = new SqlDataAdapter(strselect,kn.getConnection());
            da.Fill(ds, "PHONGBAN");
            cbo_phongban.DataSource = ds.Tables[0];
            cbo_phongban.DisplayMember = "TENPB";
            cbo_phongban.ValueMember = "MAPB";
        }

        void Load_cboChucVu()
        {
            DataSet ds = new DataSet();
            string strselect = "SELECT * FROM CHUCVU";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.getConnection());
            da.Fill(ds, "CHUCVU");
            cbo_chucvu.DataSource = ds.Tables[0];
            cbo_chucvu.DisplayMember = "TENCV";
            cbo_chucvu.ValueMember = "MACV";
        }

        void Load_cboHocVan()
        {
            DataSet ds = new DataSet();
            string strselect = "SELECT * FROM TDHV";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.getConnection());
            da.Fill(ds, "TDHV");
            cbo_hocvan.DataSource = ds.Tables[0];
            cbo_hocvan.DisplayMember = "TENTDHV";
            cbo_hocvan.ValueMember = "MATDHV";
        }
        void load_cboGIOITINH()
        {
            DataSet ds = new DataSet();
            string strselect = "SELECT DISTINCT(GT) FROM NHANVIEN";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.getConnection());
            da.Fill(ds, "NHANVIEN");
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "GT";
            comboBox1.ValueMember = "GT";
        }

    
        void load_dtgridview()
        {
            dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT MANV,TENNV,GT,QUEQUAN,NGSINH,DANTOC,SDT,TENPB,TENCV,TENTDHV,BACLUONG,MATKHAU,HINH,QUYEN from NHANVIEN,CHUCVU,TDHV,PHONGBAN where PHONGBAN.MAPB = NHANVIEN.MAPB AND CHUCVU.MACV = NHANVIEN.MACV AND TDHV.MATDHV = NHANVIEN.MATDHV", kn.getConnection());
            da.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
       
            dataGridView1.DataSource = dt;
        }

        void load_cbLuong()
        {
            DataSet ds = new DataSet();
            string strselect = "SELECT * FROM CHAMCONG";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.getConnection());
            da.Fill(ds, "CHAMCONG");
            cb_Luong.DataSource = ds.Tables[0];
            cb_Luong.DisplayMember = "BACLUONG";
            cb_Luong.ValueMember = "LUONGCOBAN";
        }
        void load_cbDanToc()
        {
            DataSet ds = new DataSet();
            string strselect = "SELECT * FROM DANTOC";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.getConnection());
            da.Fill(ds, "DANTOC");
            cbDantoc.DataSource = ds.Tables[0];
            cbDantoc.DisplayMember = "TENDT";
            cbDantoc.ValueMember = "DANTOC";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (p!=null)
            {
                openFile.InitialDirectory = "D:\\";
                openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (openFile.CheckFileExists)
                    {
                        pictureBox1.Image = new Bitmap(openFile.FileName);
                    }
                }
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            SqlConnection sql = kn.getConnection();
            string correct = Path.GetFileName(openFile.FileName);

            string ma = txtTaiKhoan.Text,
                ten = txt_tennv.Text,
                gt = comboBox1.Text,
                que = textBox3.Text,
                ngaysinh = dateTimePicker1.Value.ToShortDateString(),
                dantoc = cbDantoc.SelectedValue.ToString(),
                sdt = txt_sdt.Text,
                phong = cbo_phongban.SelectedValue.ToString(),
                chucvu = cbo_chucvu.SelectedValue.ToString(),
                tdhv = cbo_hocvan.SelectedValue.ToString(),
                bacluong = cb_Luong.Text,
                mk = txtMK.Text,
                quyen = cbQuyen.Text;
            string str = "Insert into NHANVIEN(MANV,TENNV,GT,QUEQUAN,NGSINH,DANTOC,SDT,MAPB,MACV,MATDHV,BACLUONG,MATKHAU,HINH,QUYEN)VALUES('" + ma + "',N'" + ten + "',N'" + gt + "',N'" + que + "','" + ngaysinh + "',N'" + dantoc + "','" + sdt + "','" + phong + "','" + chucvu + "','" + tdhv + "','" + bacluong + "','" + mk + "','\\Resources\\" + correct + "','" + quyen + "')";
            string str2 = "Insert into DIEMDANH(MaNV) Values('" + ma + "')";
            if (sql.State == ConnectionState.Closed)
            {
                sql = kn.getConnection();
                sql.Open();
            }
            cmd = new SqlCommand(str,sql);
            cmd2 = new SqlCommand(str2, sql);
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            sql.Close();
            string path = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
            File.Copy(openFile.FileName, path + "\\Resources\\" + correct);
            MessageBox.Show("Thêm thành công", "Thông báo");

            pictureBox1.Image = null;
            txt_tennv.Clear();
            txt_sdt.Clear();
            cb_Luong.Text = "";
            cbDantoc.Text = "";
            load_dtgridview();
        }
        private string tuTangMa()
        {
            SqlConnection matang = kn.getConnection();
            if (matang.State == ConnectionState.Closed)
            {
                matang.Open();
            }
            string str = "select MANV from NHANVIEN ORDER BY MANV DESC";
            SqlDataAdapter da = new SqlDataAdapter(str, matang);
            DataTable dt = new DataTable();
            da.Fill(dt);
            matang.Close();
            int i = dt.Rows.Count + 1;
            string s = "NV";
            s = s + i.ToString();
            return s;
        }

    }
}
