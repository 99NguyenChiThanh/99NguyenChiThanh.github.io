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
    public partial class KH_CNTT : Form
    {
        SqlConnection connsql;
        public KH_CNTT()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            connsql = new SqlConnection(cnn);
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            KH_X kh = new KH_X();

        }

        private void KH_CNTT_Load(object sender, EventArgs e)
        {

        }

        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            connsql.Open();
            string updateString = "update Khachhang set TENkh= N'" + textBox1.Text.ToString() + "',DIaCHI=N'" + textBox2.Text.ToString() +"' where SDT= '"+sdt+"'";

            SqlCommand cmd = new SqlCommand(updateString, connsql);

            cmd.ExecuteNonQuery();

            connsql.Close();
            MessageBox.Show("Cập nhật thành công");
           
        }
    }
}
