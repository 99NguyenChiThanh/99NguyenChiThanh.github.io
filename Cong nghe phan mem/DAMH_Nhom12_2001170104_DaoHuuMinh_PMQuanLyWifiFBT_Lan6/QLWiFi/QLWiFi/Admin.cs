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
using System.Text.RegularExpressions;

namespace QLWiFi
{
    public partial class Admin : Form
    {
        SqlConnection connsql;
        public Admin()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            connsql = new SqlConnection(cnn);
        }
        void load_KH()
        {
            connsql.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sel = "SELECT *FROM KHACHHANG where makh='" + txtkhhd.Text.ToString() +"'";
            SqlCommand cm = new SqlCommand(sel, connsql);
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                txttenkhhd.Text = rd["tenkh"].ToString();
                txttenkhhd.Enabled = false;
                txtdiackh.Text =rd["diachi"].ToString();
                txtdiackh.Enabled = false;
                txtsdtkh.Text = rd["SDT"].ToString();
                txtsdtkh.Enabled = false;
            }
            connsql.Close();

        }
        public bool KT_KH(string MAKH)
        {
            connsql.Open();
            string selectString = "select makh from khachhang where makh= '" + MAKH + "'";

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
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        void load_goi()
        {
            connsql.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select  MAGC from GoiCuoc ", connsql);
            da.Fill(ds, "GoiCuoc");
            cbbgoi.DataSource = ds.Tables[0];
            cbbgoi.DisplayMember = "MAGC";
            cbbgoi.ValueMember = "MAGC";
            cbbgoi.SelectedIndex = 0;
            connsql.Close();
        }
        void load_NV()
        {
            connsql.Open();
            DataSet ds = new DataSet();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM Nhanvien", connsql);
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView2.DataSource = tb;
            connsql.Close();
           
        }
        void load_tennv()
        {
            connsql.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sel = "SELECT tennv FROM Nhanvien where sdtnv='" + sdt + "'";
            SqlCommand cm = new SqlCommand(sel, connsql);
            SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            txtnvhd.Text = rd["tennv"].ToString();
            txtnvhd.Enabled = false;
            connsql.Close();
        }
        void load_manv()
        {

            connsql.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sel = "SELECT manv FROM Nhanvien where sdtnv='" + sdt + "'";
            SqlCommand cm = new SqlCommand(sel, connsql);
            SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            txtnvhd.Text = rd["manv"].ToString();
            txtnvhd.Enabled = false;
            connsql.Close();
            
        }
        void load_HD()
        {
            connsql.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select hoadon.MaHD,khachhang.MaKH,MaNV as 'nv',NgayLapHD,trangthai,MaGC,DonGia,GiamGia,ThanhTien,TenKH,DiaChi,SDT from HOADON,CTHD,KHACHHANG where HOADON.MaHD=CTHD.MaHD and KHACHHANG.MaKH=HOADON.MaKH", connsql);
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView3.DataSource = tb;
            connsql.Close();
        }
        
        void load_cv()
        {
            connsql.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM ChucVu;", connsql);
            da.Fill(ds, "ChucVu");
            cbbcv.DataSource = ds.Tables[0];
            cbbcv.DisplayMember = "TenCV";
            cbbcv.ValueMember = "MACV";
            cbbcv.SelectedIndex = 0;
            connsql.Close();
            

        }
        void load_dongia()
        {
            connsql.Open();
            string sel = "select GiaCuoc from GoiCuoc where magc = '"+cbbgoi.SelectedValue+"'";
            SqlCommand cm = new SqlCommand(sel, connsql);
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                txtdongia.Text = rd["GiaCuoc"].ToString();
                txtdongia.Enabled = false;
            }
            connsql.Close();
  
        }
        //public bool kt_makh(string makh)
        //{
        //    connsql.Open();
        //    string selectString = "select makh from khachhang where makh = '" + makh + "'";

        //    SqlCommand cmd = new SqlCommand(selectString, connsql);
        //    SqlDataReader rd = cmd.ExecuteReader();

        //    if (rd.HasRows)
        //    {
        //        rd.Close();
        //        connsql.Close();
        //        return true;

        //    }
        //    else
        //    {
        //        rd.Close();
        //        connsql.Close();
        //        return false;
        //    }
        //}
        public bool kt_manv(string manv)
        {
            connsql.Open();
            string selectString = "select MANV from NHANVIEN where MANV = '" + manv + "'";

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
        public bool kt_mahd(string mahd)
        {
            connsql.Open();
            string selectString = "select mahd from HOADON where MAHD = '" + mahd + "'";

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
        public bool kt_sdt(String sdt)
        {
            connsql.Open();
            string selectString = "select sdtnv from nhanvien where sdtnv = '" + sdt + "'";
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
        public bool kt_sdtkh(string sdt)
        {
            connsql.Open();
            string selectString = "select sdt from khachhang where sdt = '" + sdt + "'";
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
        //public bool checktime(DateTime a)
        //{
        //    int ngay = DateTime.Now.Day;
        //    int thang = DateTime.Now.Month;
        //    int nam = DateTime.Now.Year;
        //    if (thang <= 0 && thang > 12) return false;
        //    else if (ngay <= 0 && ngay > 31) return false;
        //    else if (nam <= 0) return false;
        //    else return true;
        //}
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            //load_KH();
            load_NV();
            load_tennv();
            load_HD();
            load_goi();
            load_cv();
            button1.Enabled = false;
            txtmahd.Enabled = false;
            cbbgoi.Enabled = false;
            cbbgg.Enabled = false;
            btktkh.Enabled = false;
            btluuknv.Enabled = false;
            button6.Enabled = false;
            //nhân viên
            txtmanv.Enabled = false;          
            txttennv.Enabled = false;
            txtsdtnv.Enabled = false;
            txtdcnv.Enabled = false;
            txtluong.Enabled = false;
            
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //connsql.Open();
            //DataTable bang = new DataTable();
            //bang = (DataTable)dataGridView1.DataSource;
            //int chiso = dataGridView1.SelectedCells[0].RowIndex;
            //DataRow hang = bang.Rows[chiso];
            //txtmakh.Text = hang["MAKH"].ToString();
            //txtten.Text = hang["TENKH"].ToString();
            //txtdc.Text = hang["DIACHI"].ToString();
            //txtsdt.Text = hang["SDT"].ToString();
            //connsql.Close();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            //txtmakh.Enabled = true;
            //txtmakh.Clear();
            //txtten.Clear();
            //txtdc.Clear();
            //txtdc.Clear();
            //txtmakh.Focus();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            //txtmakh.Enabled = false;
            //txtmakh.Clear();
            //txtten.Clear();
            //txtdc.Clear();
            //txtdc.Clear();
            //txtten.Focus();
        }

        //private void btluu_Click(object sender, EventArgs e)
        //{
        //    if (txtmakh.Enabled == true)
        //    {

        //        if (kt_makh(txtmakh.Text.ToString()) == true)
        //        {
        //            MessageBox.Show("mã khách hàng đã đó");
        //            this.Show();
        //        }
        //        else
        //        {
        //            connsql.Open();
        //            string insertString;
        //            insertString = "INSERT INTO KHACHHANG(MAKH, TENKH, DiaChi, SDT) VALUES ('" + txtmakh.Text.ToString() + "',N'" + txtten.Text.ToString() + "',N'" + txtdc.Text.ToString() + "','" + txtsdt.Text.ToString() + "')";
        //            SqlCommand cmd = new SqlCommand(insertString, connsql);
        //            cmd.ExecuteNonQuery();
        //            connsql.Close();
        //            MessageBox.Show("Thêm thành công");
        //        }

        //    }
        //    else
        //    {
        //        connsql.Open();
        //        string updateString = "update KHACHHANG set TenKH=N'" + txtten.Text.ToString() + "',DiaChi=N'" + txtdc.Text.ToString() + "',SDT='" + txtsdt.Text.ToString() + "' where MaKH = '" + txtmakh.Text.ToString() + "'";

        //        SqlCommand cmd = new SqlCommand(updateString, connsql);

        //        cmd.ExecuteNonQuery();

        //        connsql.Close();
        //        MessageBox.Show("Cập nhật thành công");
        //    }

        //    load_KH();
        //}

        //private void btxoa_Click(object sender, EventArgs e)
        //{
        //    if (connsql.State == ConnectionState.Closed)
        //    {
        //        connsql.Open();
        //    }

        //    string deleteString = "delete khachhang where MAHD = '" + txtmakh.Text.ToString() + "''";

        //    SqlCommand cmd = new SqlCommand(deleteString, connsql);

        //    cmd.ExecuteNonQuery();

        //    if (connsql.State == ConnectionState.Open)
        //    {
        //        connsql.Close();
        //    }

        //    MessageBox.Show("Xóa thành công.");
        //    load_KH();
        //}

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            DataTable bang = new DataTable();

            bang = (DataTable)dataGridView2.DataSource;
            int chiso = dataGridView2.SelectedCells[0].RowIndex;
            DataRow hang = bang.Rows[chiso];
            txtmanv.Text = hang["manv"].ToString();
            txttennv.Text = hang["tennv"].ToString();
            cbbgt.Text = hang["gioitinh"].ToString();
            txtluong.Text = hang["luong"].ToString();
            cbbcv.SelectedValue = hang["macv"].ToString();
            txtdcnv.Text = hang["diachinv"].ToString();
            txtsdtnv.Text = hang["sdtnv"].ToString();
            dateTimePicker1.Text = hang["ngaysinh"].ToString();
            load_NV();

        }

        private void btthemnv_Click(object sender, EventArgs e)
        {
            txtmanv.Enabled = true;
            txtmanv.Clear();
            txttennv.Clear();
            
            txtluong.Text = "0";
            btluuknv.Enabled = true;
            txtdcnv.Clear();
            txtsdtnv.Clear();
            
            txtmanv.Focus();
            txttennv.Enabled = true;
            txtsdtnv.Enabled = true;
            txtdcnv.Enabled = true;
            txtluong.Enabled = true;
        }

        private void btsuanv_Click(object sender, EventArgs e)
        {
            
            txtmanv.Clear();
            txttennv.Clear();
            txtmanv.Enabled = false;
            txtluong.Text = "0";
            btluuknv.Enabled = true;
            txtdcnv.Clear();
            txtsdtnv.Clear();
            
            txttennv.Focus();
            txttennv.Enabled = true;
            txtsdtnv.Enabled = true;
            txtdcnv.Enabled = true;
            txtluong.Enabled = true;
        }

        private void btxoanv_Click(object sender, EventArgs e)
        {
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }

            string deleteString = "delete taikhoan where MaNV='" + txtmanv.Text.ToString() + "';delete nhanvien where manv = '" + txtmanv.Text.ToString() + "'";

            SqlCommand cmd = new SqlCommand(deleteString, connsql);

            cmd.ExecuteNonQuery();

            if (connsql.State == ConnectionState.Open)
            {
                connsql.Close();
            }

            MessageBox.Show("Xóa thành công.");
            load_NV();
        }

        private void btluuknv_Click(object sender, EventArgs e)
        {
            if (txtsdtnv.Text.ToString() == "" || IsNumber(txtsdtnv.Text)== false)
            {
                MessageBox.Show("Chưa nhập số điện thoại hoặc không đúng !");
                load_NV();
                load_tennv();
                this.Show();

            }
            else if(cbbgt.Text=="")
            {
                MessageBox.Show("vui lòng chọn giới tính");
                load_NV();
                load_tennv();
                this.Show();
            }
            //else if (kt_null(txtngaysinh.Text.ToString()) == true)
            //{
            //    MessageBox.Show("không được bỏ trống ngày sinh !");
            //    load_NV();
            //    load_tennv();
            //}
            //else if (checktime(DateTime.Parse(txtngaysinh.Mask)) == false)
            //{
            //    MessageBox.Show("ngày nhập không hợp lệ");
            //    load_NV();
            //    load_tennv();
            //}
            //else if (txtngaysinh.MaskFull)
            //{
            else if (txtluong.Text.ToString() == "")
                {
                    MessageBox.Show("không được bỏ trống lương !");
                    load_NV();
                    load_tennv();
                    this.Show();
                }
                else if (IsNumber(txtluong.Text.ToString()) == false)
                {
                    MessageBox.Show("lương phải là số");
                    load_NV();
                    load_tennv();
                    this.Show();
                }

                else if (txtmanv.Enabled == true)
                {

                    if (kt_manv(txtmanv.Text.ToString()) == true)
                    {
                        MessageBox.Show("mã nhân viên đã tồn tại");
                        load_NV();
                        load_tennv();
                        this.Show();

                    }
                    else
                    {
                        if (kt_sdt(txtsdtnv.Text.ToString()) == true)
                        {
                            MessageBox.Show("số điện thoại đã tồn tại !");
                            load_NV();
                            load_tennv();
                            this.Show();
                        }
                        else
                        {
                            connsql.Open();
                            string insertString;
                            insertString = "SET DATEFORMAT mdY INSERT INTO NHANVIEN  VALUES ('" + txtmanv.Text.ToString() + "',N'" + txttennv.Text.ToString() + "',N'" + cbbgt.SelectedItem.ToString() + "'," + txtluong.Text.ToString() + ",'" + cbbcv.SelectedValue + "',N'" + txtdcnv.Text.ToString() + "','" + txtsdtnv.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "'); INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('" + txtsdtnv.Text.ToString() + "','123','" + txtmanv.Text.ToString() + "',NULL)";
                            SqlCommand cmd = new SqlCommand(insertString, connsql);
                            cmd.ExecuteNonQuery();
                            connsql.Close();
                            MessageBox.Show("Thêm thành công");
                            load_NV();
                            load_tennv();
                            this.Show();
                        }

                    }

                }
                else
                {
                    connsql.Open();
                    string updateString = "update NHANVIEN set TenNV=N'" + txttennv.Text.ToString() + "',GioiTinh=N'" + cbbgt.SelectedItem.ToString() + "',LUONG=" + txtluong.Text.ToString() + ",MaCV='" + cbbcv.SelectedValue + "',DiaChiNV=N'" + txtdcnv.Text.ToString() + "',SDTNV='" + txtsdtnv.Text.ToString() + "',NgaySinh='" + dateTimePicker1.Text.ToString() + "' where MaNV='" + txtmanv.Text.ToString() + "'";

                    SqlCommand cmd = new SqlCommand(updateString, connsql);

                    cmd.ExecuteNonQuery();

                    connsql.Close();
                    MessageBox.Show("Cập nhật thành công");
                    load_NV();
                    load_tennv();
                    this.Show();
                }
            //}
            //else
            //{
            //    MessageBox.Show("ngày nhập không hợp lệ");
            //}
            load_NV();
            load_tennv();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtmahd.Enabled = true;
            txtkhhd.Clear();
            txttenkhhd.Clear();
            txtdiackh.Clear();
            txtsdtkh.Clear();
            txtmahd.Text = "HDB"; 
            txtdongia.Clear();
            txtkhhd.Focus();
            load_manv();
            button6.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtmahd.Enabled = false;
            txtkhhd.Clear();
            txttenkhhd.Clear();
            txtdiackh.Clear();
            txtsdtkh.Clear();
            txtmahd.Text = "HDB";
            txtdongia.Clear();
            button6.Enabled = false;
            button1.Enabled = true;
            txtkhhd.Focus();
            cbbgoi.Enabled = true;
            cbbgg.Enabled = true;
            load_manv();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }

            string deleteString = "delete CTHD where MAHD = '" + txtmahd.Text.ToString() + "' delete HOADON where MAHD ='" + txtmahd.Text.ToString() + "'";

            SqlCommand cmd = new SqlCommand(deleteString, connsql);

            cmd.ExecuteNonQuery();

            if (connsql.State == ConnectionState.Open)
            {
                connsql.Close();
            }

            MessageBox.Show("Xóa thành công.");
            load_HD();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //if (txttenkhhd.Enabled == true)
            //{
            //    if (txtsdtkh.Text.ToString() == "" || IsNumber(txtsdtkh.Text) == false)
            //    {
            //        MessageBox.Show("Chưa nhập số điện thoại hoặc không đúng !");
            //        load_NV();
                    
            //        this.Show();

            //    }
            //    else if (kt_sdtkh(txtsdtkh.Text.ToString()) == true)
            //    {
            //        MessageBox.Show("số điện thoại đã tồn tại !");
            //        load_NV();
                   
            //        this.Show();
            //    }
            //    else
            //    {
                    
            //        txttenkhhd.Enabled = false;
            //        txtmahd.Focus();
            //        load_NV();
                    
            //    }
            //}
            if (cbbgg.Text.ToString() == "")
            {
                MessageBox.Show("không được bỏ trống giảm giá !");
                load_NV();
                
                this.Show();
            }
            else if (IsNumber(cbbgg.Text.ToString()) == false)
            {
                MessageBox.Show("giảm giá phải là số");
                load_NV();

                this.Show();
            }
            else
            {
                if (txtmahd.Enabled == true)
                {
                    if (kt_mahd(txtmahd.Text.ToString()) == true || txtmahd.Text.ToString() == "")
                    {
                        MessageBox.Show("Mã hóa đơn đã tồn tại hoặc chưa nhập");
                        this.Show();
                        load_HD();

                    }
                    else
                    {

                        connsql.Open();
                        string insertString;
                        if (txttenkhhd.Enabled == true)
                        {
                            insertString = "SET DATEFORMAT MDY INSERT INTO KHACHHANG(MAKH, TENKH, DiaChi, SDT) VALUES ('" + txtkhhd.Text.ToString() + "',N'" + txttenkhhd.Text.ToString() + "',N'" + txtdiackh.Text.ToString() + "','" + txtsdtkh.Text.ToString() + "');INSERT INTO HOADON VALUES('" + txtmahd.Text.ToString() + "','" + txtnvhd.Text.ToString() + "','" + datenl.Text.ToString() + "','" + txtkhhd.Text.ToString() + "',N'Chưa thanh toán');INSERT INTO CTHD(MAHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES ('" + txtmahd.Text.ToString() + "','" + cbbgoi.SelectedValue.ToString() + "'," + txtdongia.Text.ToString() + ", " + cbbgg.SelectedItem.ToString() + ", NULL);update CTHD set thanhtien = (dongia - GiamGia) where mahd = '"+txtmahd.Text.ToString()+"'";

                        }
                        else
                        {
                            insertString = "SET DATEFORMAT MDY INSERT INTO HOADON VALUES('" + txtmahd.Text.ToString() + "','" + txtnvhd.Text.ToString() + "','" + datenl.Text.ToString() + "','" + txtkhhd.Text.ToString() + "',N'Chưa thanh toán');INSERT INTO CTHD(MAHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES ('" + txtmahd.Text.ToString() + "','" + cbbgoi.SelectedValue.ToString() + "'," + txtdongia.Text.ToString() + ", " + cbbgg.SelectedItem.ToString() + ", NULL);update CTHD set thanhtien = (dongia - GiamGia) where mahd = '" + txtmahd.Text.ToString() + "'";
                        }

                        SqlCommand cmd = new SqlCommand(insertString, connsql);
                        cmd.ExecuteNonQuery();
                        connsql.Close();
                        MessageBox.Show("Thêm thành công");
                        load_HD();
                        load_tennv();
                        this.Show();
                    }


                }
                else
                {
                    connsql.Open();
                    string updateString = "update HOADON set MaNV='" + txtnvhd.Text.ToString() + "',NgayLapHD='" + datenl.Text.ToString() + "',MaKH='" + txtkhhd.Text.ToString() + "',trangthai=N'Chưa thanh toán' where mahd='" + txtmahd.Text.ToString() + "'update KHACHHANG set TenKH=N'" + txttenkhhd.Text.ToString() + "',DiaChi=N'" + txtdiackh.Text.ToString() + "',SDT='" + txtsdtkh.Text.ToString() + "' where MaKH = '" + txtkhhd.Text.ToString() + "' update CTHD set MaGC='" + cbbgoi.SelectedValue.ToString() + "',DonGia=" + txtdongia.Text.ToString() + ",GiamGia=" + cbbgg.SelectedItem.ToString() + " where mahd='" + txtmahd.Text.ToString() + "' update CTHD set thanhtien = (dongia - GiamGia) where mahd = '" + txtmahd.Text.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(updateString, connsql);
                    cmd.ExecuteNonQuery();
                    connsql.Close();
                    MessageBox.Show("Cập nhật thành công");
                    load_HD();
                    load_tennv();
                }
            }
                this.Show();

                connsql.Close();

            //}
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataTable bang = new DataTable();

            //bang = (DataTable)dataGridView4.DataSource;
            //int chiso = dataGridView4.SelectedCells[0].RowIndex;
            //DataRow hang = bang.Rows[chiso];
            //cbbgoi.SelectedValue = hang["magc"].ToString();
            //txtdongia.Text = hang["dongia"].ToString();
            //txtgiamgia.Text = hang["giamgia"].ToString();
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            dangnhap dn = new dangnhap();
            dn.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dangnhap dn = new dangnhap();
            dn.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (KT_KH(txtkhhd.Text.ToString()) == true)
            {
                load_KH();
                button1.Enabled = true;
                txtmahd.Enabled = true;
                cbbgoi.Enabled = true;
                cbbgg.Enabled = true;
                btktkh.Enabled = false;

            }
            else
            {
                
                txttenkhhd.Enabled = true;
                txttenkhhd.Clear();
                txtdiackh.Enabled = true;
                txtdiackh.Clear();
                txtsdtkh.Enabled = true;
                txtsdtkh.Clear();
                btktkh.Enabled = true;
                MessageBox.Show("Khách hàng này không tồn tại, bạn có thể thêm mới !");
            }
        }

        private void cbbgoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtdongia.Clear();
            //{
            //    string sel = "select GiaCuoc from GoiCuoc where magc = '"+cbbgoi.SelectedValue+"'";
            //SqlCommand cm = new SqlCommand(sel, connsql);
            //SqlDataReader rd = cm.ExecuteReader();
            //while (rd.Read())
            //{
            //    txtdongia.Text = rd["GiaCuoc"].ToString();
            //    txtdongia.Enabled = false;
            //}
            //}
            
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            load_dongia();
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataTable bang = new DataTable();

            bang = (DataTable)dataGridView3.DataSource;
            int chiso = dataGridView3.SelectedCells[0].RowIndex;
            DataRow hang = bang.Rows[chiso];
            txtkhhd.Text = hang["makh"].ToString();
            txttenkhhd.Text = hang["tenkh"].ToString();
            txtdiackh.Text = hang["diachi"].ToString();
            txtsdtkh.Text = hang["sdt"].ToString();
            txtmahd.Text = hang["mahd"].ToString();
            cbbgg.Text = hang["giamgia"].ToString();
            cbbgoi.Text = hang["magc"].ToString();
            txtdongia.Text = hang["dongia"].ToString();
            datenl.Text = hang["ngaylaphd"].ToString();
        }

        private void txtngaylap_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ngay"+ dateTimePicker1.Text.ToString());
        }

        private void txtnvhd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btktkh_Click(object sender, EventArgs e)
        {
            if (txtsdtkh.Text.ToString() == "" || IsNumber(txtsdtkh.Text) == false)
            {
                MessageBox.Show("Chưa nhập số điện thoại hoặc không đúng !");
                load_NV();
                load_tennv();
                this.Show();

            }
            else if (kt_sdtkh(txtsdtkh.Text.ToString()) == true)
            {
                MessageBox.Show("số điện thoại đã tồn tại !");
                load_NV();
                load_tennv();
                this.Show();
            }
            else
            {
                MessageBox.Show("Thông tin khách hàng chính xác");
                txtmahd.Focus();
                button1.Enabled = true;
                txtmahd.Enabled = true;
                cbbgoi.Enabled = true;
                cbbgg.Enabled = true;
                load_NV();
                load_manv();
            }
        }
    }
}
