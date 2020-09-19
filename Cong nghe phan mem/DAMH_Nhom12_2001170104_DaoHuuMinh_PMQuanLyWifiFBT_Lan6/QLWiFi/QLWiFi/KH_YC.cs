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
    public partial class KH_YC : Form
    {
        SqlConnection connsql;
        public KH_YC()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            connsql = new SqlConnection(cnn); 
        }
        public void load_nv()
        {
            connsql.Open();
            DataSet ds = new DataSet();
            string str = "select * from NHANVIEN where macv = 'CV01'";
            SqlDataAdapter da = new SqlDataAdapter(str, connsql);
            da.Fill(ds, "NHANVIEN");
            cbbnv.DataSource = ds.Tables[0];
            cbbnv.DisplayMember = "tennv";
            cbbnv.ValueMember = "manv";
            cbbnv.SelectedIndex = 0;
            connsql.Close();
        }
        public void load_hotro()
        {
            connsql.Open();
            DataSet ds = new DataSet();
            KH_X makh = new KH_X();
            string makhach = makh.lay_mak();
            SqlDataAdapter da = new SqlDataAdapter("select MaNV,MaKH,NgayHen,TrangThai,YeuCau from HoTro where makh = '" + makhach + "'and YeuCau=N'YÊU CẦU ĐẾN SỬA WIFI'", connsql);
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView1.DataSource = tb;
            connsql.Close();
        }
        public bool KT_YC()
        {
            connsql.Open();
            KH_X makh = new KH_X();
            string makhach = makh.lay_mak();
            string selectString = "select MaKH from HoTro where MaKH='" + makhach + "' and TrangThai=N'Chưa hỗ trợ' and YeuCau=N'YÊU CẦU ĐẾN SỬA WIFI'";
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
        private void KH_YC_Load(object sender, EventArgs e)
        {
            load_hotro();
            load_nv();
        }

        private void btdatlich_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "DD/MM/YYYY")
            {
                MessageBox.Show("vui lòng nhập ngày hẹn");
            }
            else if (KT_YC() == true)
            {
                MessageBox.Show("yêu cầu đã có !");
                load_hotro();
            }
            else
            {
                connsql.Open();
                string insertString;
                KH_X makh = new KH_X();
                string makhach = makh.lay_mak();
                insertString = "SET DATEFORMAT DMY INSERT INTO HoTro(MaNV,MaKH,NgayHen,TrangThai,YeuCau) values ('" + cbbnv.SelectedValue + "','" + makhach + "','" + textBox1.Text.ToString() + "',N'Chưa hỗ trợ',N'YÊU CẦU ĐẾN SỬA WIFI')";
                SqlCommand cmd = new SqlCommand(insertString, connsql);
                cmd.ExecuteNonQuery();
                connsql.Close();
                MessageBox.Show("Thêm yêu cầu thành công");
                load_hotro();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }
            KH_X makh = new KH_X();
            string makhach = makh.lay_mak();
            string deleteString = "delete HoTro where MaKH = '" + makhach + "' and YeuCau=N'YÊU CẦU ĐẾN SỬA WIFI' and TrangThai=N'Chưa hỗ trợ'";

            SqlCommand cmd = new SqlCommand(deleteString, connsql);

            cmd.ExecuteNonQuery();

            if (connsql.State == ConnectionState.Open)
            {
                connsql.Close();
            }

            MessageBox.Show("Xóa thành công.");
            load_hotro();
        }
    }
}
