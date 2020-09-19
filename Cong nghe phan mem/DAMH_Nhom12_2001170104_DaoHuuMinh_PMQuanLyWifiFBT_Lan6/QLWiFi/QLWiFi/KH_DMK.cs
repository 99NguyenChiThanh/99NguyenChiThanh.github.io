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
    public partial class KH_DMK : Form
    {
        SqlConnection connsql;
        
        public KH_DMK()
        {

            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            connsql = new SqlConnection(cnn);
            
        }
        void load_wf()
        {
            connsql.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sel = "select khachhang.makh,taikhoanwifi,matkhauwifi from wifi,KHACHHANG where KHACHHANG.MaKH=wifi.MaKH and KHACHHANG.SDT='" + sdt + "'";
            SqlCommand cmd = new SqlCommand(sel, connsql);
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                label5.Text = (rd["makh"].ToString().Trim());
            label6.Text = (rd["taikhoanwifi"].ToString().Trim());
            label7.Text = (rd["matkhauwifi"].ToString().Trim());
            }
            connsql.Close();
            
        }
        private void KH_DMK_Load(object sender, EventArgs e)
        {
            load_wf();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            {
                connsql.Open();
                dangnhap dn = new dangnhap();
                string sdt = dn.gan_sdt();

                string updateString = "update wifi set taikhoanwifi=N'" + txtten.Text.ToString() + "',matkhauwifi=N'" + txtmk.Text.ToString() + "' from wifi,KHACHHANG where wifi.MaKH = KHACHHANG.MaKH and KHACHHANG.SDT = '" + sdt + "'";

                SqlCommand cmd = new SqlCommand(updateString, connsql);

                cmd.ExecuteNonQuery();

                connsql.Close();
                MessageBox.Show("Cập nhật thành công");
            }
            load_wf();
        }
    }
}
