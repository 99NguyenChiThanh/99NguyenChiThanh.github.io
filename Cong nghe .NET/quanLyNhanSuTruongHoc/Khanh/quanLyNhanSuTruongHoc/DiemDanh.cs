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
using System.Threading;
namespace quanLyNhanSuTruongHoc
{
    public partial class DiemDanh : Form
    {
        Thread th;
        SqlCommand cmd;
        DataTable table;
        SqlDataAdapter adapter;
        KetNoi kn = new KetNoi();
        public DiemDanh()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void DiemDanh_Load(object sender, EventArgs e)
        {
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string DD = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
                int Ma = Convert.ToInt16(dataGridView1.Rows[i].Cells[0].Value);
                string str = "Update DIEMDANH set DD=N'" +DD+ "',NGAYDD ='" + dateTimePicker1.Value.ToShortDateString() + "'where MADD="+Ma;
                SqlConnection sql = kn.getConnection();
                if (sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                    cmd = new SqlCommand(str, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                }
            }
            MessageBox.Show("Cập nhật thành công","Thông báo");
            dateTimePicker1.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string now = dt.ToString("dd/MM/yyyy");
            string time = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            int kt = time.CompareTo(now);
            if (kt == 0)
            {
                table = new DataTable();
                string strAll = "select * from DIEMDANH where NgayDD ='"+dateTimePicker1.Value.ToShortDateString()+"'";
                adapter = new SqlDataAdapter(strAll, kn.getConnection());
                adapter.Fill(table);
                table.PrimaryKey = new DataColumn[] { table.Columns[0] };
                //
                //kiểm tra ngày tại row tời gian
                //
                    if (table.Rows.Count>0)
                    {
                        load_gridTheoNgay();

                    }
                    else
                    {
                        dateTimePicker1.Enabled = false;
                        buttonCapNhat.Enabled = true;
                        DataTable data = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT MANV from NHANVIEN ", kn.getConnection());
                        da.Fill(data);
                        data.PrimaryKey = new DataColumn[] { data.Columns[0] };
                        foreach (DataRow dr in data.Rows)
                        {
                            string ma = dr["MANV"].ToString();
                            string str = "Insert Into DIEMDANH(MaNV) values('" + ma + "')";
                            SqlConnection sql = kn.getConnection();
                            if (sql.State == ConnectionState.Closed)
                            {
                                sql.Open();
                                cmd = new SqlCommand(str, sql);
                                cmd.ExecuteNonQuery();
                                sql.Close();
                            }
                            //
                            //load lại grid view
                            //
                            DataTable dt1 = new DataTable();
                            string str1 = "Select MADD,NHANVIEN.MaNV,TenNV,TenCV,SDT,DD FROM CHUCVU,NHANVIEN,DIEMDANH where CHUCVU.MACV = NHANVIEN.MACV AND DIEMDANH.MaNV = NHANVIEN.MANV AND DD is null";
                            SqlDataAdapter da1 = new SqlDataAdapter(str1, sql);
                            da1.Fill(dt1);
                            dt1.PrimaryKey = new DataColumn[] { dt1.Columns[0] };
                            dataGridView1.DataSource = dt1;
                        }
                    }
            }
            else if (kt < 0)
            {
                dateTimePicker1.Enabled = true;
                load_gridTheoNgay();
            }
            else
            {
                dateTimePicker1.Enabled = true;
            }
        }
        void load_gridTheoNgay()
        {
            DataTable dt1 = new DataTable();
            string str1 = "Select MADD,NHANVIEN.MaNV,TenNV,TenCV,SDT,DD FROM CHUCVU,NHANVIEN,DIEMDANH where CHUCVU.MACV = NHANVIEN.MACV AND DIEMDANH.MaNV = NHANVIEN.MANV AND NgayDD ='"+dateTimePicker1.Value.ToShortDateString()+"'";
            SqlDataAdapter da1 = new SqlDataAdapter(str1, kn.getConnection());
            da1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns[0] };
            dataGridView1.DataSource = dt1;
        }

        private void DiemDanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Thoát","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
                e.Cancel = true;
            else
            {
                this.Dispose();
                th = new Thread(TrangChu);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void TrangChu(object obj)
        {
            Application.Run(new frmTrangChu());
        }
    }
}
