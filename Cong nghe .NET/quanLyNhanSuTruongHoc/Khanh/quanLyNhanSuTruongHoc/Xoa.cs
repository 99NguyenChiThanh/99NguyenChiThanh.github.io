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
using System.Data.Common;
using System.Threading;

namespace quanLyNhanSuTruongHoc
{

    public partial class Xoa : Form
    {
        KetNoi kn = new KetNoi();
        DataSet ds_nv = new DataSet();
        DataSet ds_TTK = new DataSet();
        Thread th;

        public Xoa()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void load_dtgridview()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT MANV,TENNV,GT,QUEQUAN,NGSINH,DANTOC,SDT,TENPB,TENCV,TENTDHV,BACLUONG,MATKHAU,HINH,QUYEN from NHANVIEN,CHUCVU,TDHV,PHONGBAN WHERE (QUYEN='user' or QUYEN='Mod') AND PHONGBAN.MAPB = NHANVIEN.MAPB AND CHUCVU.MACV = NHANVIEN.MACV AND TDHV.MATDHV = NHANVIEN.MATDHV ", kn.getConnection());
            da.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
            dataGridView2.DataSource = dt;
        }


        private void returnHome(object obj)
        {
            Application.Run(new frmTrangChu());
        }


        private void btXoaNV_Click(object sender, EventArgs e)
        {

            SqlConnection sql = kn.getConnection();
            string strsel = "SELECT * FROM NHANVIEN";
            string strTTK = "Select * From THONGTINKHAC";
            SqlDataAdapter da_nv = new SqlDataAdapter(strsel, kn.getConnection());
            SqlDataAdapter da_TTK = new SqlDataAdapter(strTTK, kn.getConnection());
            da_nv.Fill(ds_nv, "NHANVIEN");
            da_TTK.Fill(ds_TTK, "THONGTINKHAC");
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn chắc chăn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
                    {
                        string strTT = "DELETE FROM THONGTINKHAC WHERE MANV='" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "'";
                        if (sql.State == ConnectionState.Closed)
                        {
                            sql.Open();
                        }
                        SqlCommand cmd = new SqlCommand(strTT, sql);
                        cmd.Connection = sql;
                        cmd.ExecuteNonQuery();
                        sql.Close();
                        string str = "DELETE FROM NHANVIEN WHERE MANV='" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "'";
                        if (sql.State == ConnectionState.Closed)
                        {
                            sql.Open();
                        }
                        SqlCommand cmd2 = new SqlCommand(str, sql);
                        cmd2.Connection = sql;
                        cmd2.ExecuteNonQuery();
                        kn.getConnection().Close();
                        dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                        MessageBox.Show("Thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn nhân viên");
            }

        }

        private void Xoa_Load(object sender, EventArgs e)
        {
            load_dtgridview();
        }

        private void btQuayLai_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            th = new Thread(returnHome);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
