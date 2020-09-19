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
    public partial class KH_KTN : Form
    {
        SqlConnection connsql;
        public KH_KTN()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            connsql = new SqlConnection(cnn);
        }
        public void load_hoadon()
        {

            DataSet ds = new DataSet();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            SqlDataAdapter da = new SqlDataAdapter("select HOADON.MaHD, MaGC,  DonGia, GiamGia, ThanhTien,HOADON.NgayLapHD,trangthai from HOADON ,CTHD where HOADON.mahd= CTHD.mahd and  HOADON.makh = (select makh from KHACHHANG where sdt='"+sdt+"')", connsql);
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView1.DataSource = tb;
           
            
        }
        public void load_loc()
        {
            DataSet ds = new DataSet();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string str = "select mahd,trangthai from hoadon where makh=(select makh from KHACHHANG where sdt='"+sdt+"')";
            SqlDataAdapter da = new SqlDataAdapter(str, connsql);
            da.Fill(ds, "HOADON");
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "trangthai";
            comboBox1.ValueMember = "trangthai";
            comboBox1.SelectedIndex = 0;
        }
        public void load_trangthai()
        {
            
            //DataSet ds = new DataSet();
            //dangnhap dn = new dangnhap();
            //string sdt = dn.gan_sdt();
            //SqlDataAdapter da = new SqlDataAdapter("Select  MaHD, MANV, NgayLapHD, khachhang.MAKH, MaGC,trangthai, TONGTIEN from Hoadon,khachhang where hoadon.makh=khachhang.makh and khachhang.sdt= '" + sdt + "' ", connsql);
            //da.Fill(ds, "HOADON");
            //comboBox1.DataSource = ds.Tables[0];
            //comboBox1.DisplayMember = "TRANGTHAI";
            //comboBox1.ValueMember = "MAHD";
            //comboBox1.SelectedIndex = 0;
            
           
        }
              

        
        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBox1.Text.ToString() == "Chọn trạng thái")
            {
                MessageBox.Show("vui lòng chọn trạng thái trước khi lọc dữ liệu");
                load_hoadon();
            }
            else
            {

                load_hoadon();
                dataGridView1.Controls.Clear();
                DataSet ds = new DataSet();
                dangnhap dn = new dangnhap();
                string sdt = dn.gan_sdt();
                SqlDataAdapter da = new SqlDataAdapter("select HOADON.MaHD, MaGC,  DonGia, GiamGia, ThanhTien,HOADON.NgayLapHD,trangthai from HOADON ,CTHD where HOADON.mahd= CTHD.mahd and trangthai=N'" + comboBox1.SelectedValue + "' and  HOADON.makh = (select makh from KHACHHANG where sdt='" + sdt + "')", connsql);
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DataTable tb1 = new DataTable();
                da.Fill(tb1);
                dataGridView1.DataSource = tb1;
            }

        }

        private void KH_KTN_Load(object sender, EventArgs e)
        {
            //connsql.Open();

            load_hoadon();
            load_loc();
            //load_trangthai();
        }
        public bool KT_tt()
        {

            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string selectString = "select trangthai from hoadon where trangthai='Đã thanh toán' and makh=(select makh from KHACHHANG where sdt='"+sdt+"')";
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (KT_tt()==true)
            {
                MessageBox.Show("Quý khách không có hóa đơn nợ cước");
                load_hoadon();
            }
            else {
                KH_KTN_THANHTOAN tt = new KH_KTN_THANHTOAN();
                tt.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
