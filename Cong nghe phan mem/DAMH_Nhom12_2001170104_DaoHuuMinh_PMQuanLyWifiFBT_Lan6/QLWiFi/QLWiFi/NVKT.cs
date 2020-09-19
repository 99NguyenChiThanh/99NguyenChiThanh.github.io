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
    public partial class NVKT : Form
    {
        SqlConnection cn;
        public NVKT()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            cn = new SqlConnection(cnn);
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            dangnhap dn = new dangnhap();
            dn.Show();
            this.Close();
        }

        private void NVKT_Load(object sender, EventArgs e)
        {
            //cn = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS; Initial Catalog=QL_INTERNET1; Integrated Security=True;");

            cn.Open();
            dangnhap dn = new dangnhap();
            string sdt = dn.gan_sdt();
            string sele = "Select nv.Manv, Tennv, gioitinh, luong, tencv, DiaChiNV, sdtnv, ngaysinh from Nhanvien nv, Chucvu cv where SDTnv = '" + sdt + "' and nv.Macv = cv.Macv";
            //string sele = "Select nv.Manv, Tennv, gioitinh, luong, tencv, diachi, sdt, ngaysinh from Nhanvien nv, Chucvu cv where SDT = '0927352718' and nv.Macv = cv.Macv";
            SqlCommand cm = new SqlCommand(sele, cn);
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                label1.Text = "Chào " + rd["Tennv"].ToString() + ",";
                label2.Text = label2.Text + " " + rd["Manv"].ToString();
                label9.Text = label9.Text + " " + rd["Tennv"].ToString();
                label3.Text = label3.Text + " " + rd["gioitinh"].ToString();
                label4.Text = label4.Text + " " + rd["luong"].ToString();
                label7.Text = label7.Text + " " + rd["tencv"].ToString();
                label6.Text = label6.Text + " " + rd["diachinv"].ToString();
                label8.Text = label8.Text + " " + rd["sdtnv"].ToString();
                label5.Text = label5.Text + " " + rd["ngaysinh"].ToString();
            }
            cn.Close();

            cn.Open();
            sele = "Select * from hotro where manv = '" + label2.Text.Substring(7) + "'";
            SqlDataAdapter da = new SqlDataAdapter(sele, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            cn.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMakh.Text != "")
            {
                try
                {
                    cn.Open();
                    string ngayhendmy = txtNgayhen.Text;
                    if (ngayhendmy.Length > 10)
                        ngayhendmy = txtNgayhen.Text.Substring(0, 10);
                    string[] ngayhenmdy = ngayhendmy.Split('/');
                    //manv + makh là khóa chính, 1 kh có 1 yêu cầu gồm n` yêu cầu sửa chữa
                    string sua = "Update hotro set ngayhen = '" + ngayhenmdy[1] + "/" + ngayhenmdy[0] + "/" + ngayhenmdy[2] + "', Trangthai = N'" + cboTrangthai.SelectedItem + "' where makh = '" + txtMakh.Text + "' and manv = '" + label2.Text.Substring(7) + "'";
                    SqlCommand cmd = new SqlCommand(sua, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công.");
                    string sele = "Select * from hotro where manv = '" + label2.Text.Substring(7) + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sele, cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lưu thất bại.");
                    txtMakh.Text = txtNgayhen.Text = cboTrangthai.Text = "";
                    string sele = "Select * from hotro where manv = '" + label2.Text.Substring(7) + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sele, cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    cn.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView1.Enabled = false;
                txtMakh.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNgayhen.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboTrangthai.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                dataGridView1.Enabled = true;
            }
        }
    }
}
