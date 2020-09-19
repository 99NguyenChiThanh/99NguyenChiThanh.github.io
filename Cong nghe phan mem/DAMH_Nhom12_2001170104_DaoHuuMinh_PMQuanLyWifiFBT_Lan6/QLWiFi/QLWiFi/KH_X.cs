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
    public partial class KH_X : Form
    {
        SqlConnection connsql;
        public KH_X()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            connsql = new SqlConnection(cnn);
        }
        
        public void load_ttKH()
        {
            
            connsql.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sel = "select MAKH, TENKH, DiaChi, SDT from khachhang where SDT='" + sdt + "'";
            SqlCommand cm = new SqlCommand(sel, connsql);
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                label_mak.Text = rd["makh"].ToString();
                label_tenkh.Text = rd["TenKH"].ToString();
                label_diachi.Text = rd["DiaCHi"].ToString();
                
                label_sdt.Text = rd["SDT"].ToString();
                
                
            }
            connsql.Close();
        }
        public void load_ttgc()
        {
            connsql.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sel = "select GoiCuoc.TenGC,GoiCuoc.MaGC from HOADON ,CTHD,GoiCuoc where HOADON.mahd= CTHD.mahd and GoiCuoc.MAGC=CTHD.MAGC and HOADON.makh = (select makh from KHACHHANG where sdt='"+sdt+"')";
            SqlCommand cm = new SqlCommand(sel, connsql);
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                
                label1_tengoi.Text = rd["TenGC"].ToString();
          
                label_magoi.Text = rd["MAGC"].ToString();

            }
            connsql.Close();
        }
        //public void load_makh()
        //{

        //    connsql.Open();
        //    dangnhap dn = new dangnhap();
        //    string sdt = dn.gan_sdt();
        //    string sel = "select khachhang.makh from KHACHHANG,HOADON,GoiCuoc where KHACHHANG.MaKH= HOADON.MaKH and GoiCuoc.MaGC = HOADON.MaGC and KHACHHANG.SDT='0935682663'";
        //    SqlCommand cm = new SqlCommand(sel, connsql);
        //    label_makh.Text = (string)cm.ExecuteScalar();
        //    connsql.Close();
        //}
        public static string makh;
        private void KH_X_Load(object sender, EventArgs e)
        {
            load_ttKH();
            load_ttgc();
            //load_makh();
             makh = label_mak.Text.Trim();

        }
        public string lay_mak()
        {
            return makh;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            KH_CNTT khtt = new KH_CNTT();
            khtt.Show();
            load_ttKH();
            load_ttgc();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
