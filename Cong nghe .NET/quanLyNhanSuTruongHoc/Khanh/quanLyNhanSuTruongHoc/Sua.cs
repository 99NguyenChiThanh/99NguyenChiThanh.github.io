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
    public partial class Sua : Form
    {
        Thread th;
        KetNoi kn = new KetNoi();
        SqlDataAdapter da;
        DataSet ds;
        public Sua()
        {
            InitializeComponent();
        }

        private void Sua_Load(object sender, EventArgs e)
        {
            load_grid();
        }

        private void load_grid()
        {
            string strSele = "select * from NHANVIEN nv, THONGTINKHAC ttk where nv.MANV = ttk.MANV";
            da = new SqlDataAdapter(strSele, kn.getConnection());
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[14].ReadOnly = true;
            dataGridView1.Columns[15].ReadOnly = true;
        }

        private void Sua_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                e.Cancel = true;
            else
            {
                this.Dispose();
                th = new Thread(TrangCHU);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void TrangCHU(object obj)
        {
            Application.Run(new frmTrangChu());
        }

        private void btluuu_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells != null)
            {
                    SqlConnection cn = kn.getConnection();
                    int dong = dataGridView1.CurrentRow.Index;
                    string strUpdate = "SET DATEFORMAT DMY Update NHANVIEN SET TENNV='" + dataGridView1.Rows[dong].Cells[1].Value.ToString()
                        + "',GT='" + dataGridView1.Rows[dong].Cells[2].Value.ToString()
                        + "',QUEQUAN='" + dataGridView1.Rows[dong].Cells[3].Value.ToString()
                        + "',NGSINH='" + DateTime.Parse(dataGridView1.Rows[0].Cells[4].Value.ToString()).ToShortDateString()
                        + "',DANTOC='" + dataGridView1.Rows[dong].Cells[5].Value.ToString()
                        + "',SDT='" + dataGridView1.Rows[dong].Cells[6].Value.ToString()
                        + "',MAPB='" + dataGridView1.Rows[dong].Cells[7].Value.ToString()
                        + "',MACV='" + dataGridView1.Rows[dong].Cells[8].Value.ToString()
                        + "',MATDHV='" + dataGridView1.Rows[dong].Cells[9].Value.ToString()
                        + "',BACLUONG='" + dataGridView1.Rows[dong].Cells[10].Value.ToString()
                        + "',MATKHAU='" + dataGridView1.Rows[dong].Cells[11].Value.ToString()
                        + "',HINH='" + dataGridView1.Rows[dong].Cells[12].Value.ToString()
                        + "',QUYEN='" + dataGridView1.Rows[dong].Cells[13].Value.ToString()
                        + "' where MANV= '" + Convert.ToString(dataGridView1.Rows[dong].Cells[0].Value)+"'";
                    string strUpdate2 = "SET DATEFORMAT DMY Update THONGTINKHAC SET CMND='" + dataGridView1.Rows[dong].Cells[16].Value.ToString()
                        + "',NGAYCAP='" + DateTime.Parse(dataGridView1.Rows[0].Cells[4].Value.ToString()).ToShortDateString()
                        + "',NOICAP='" + dataGridView1.Rows[dong].Cells[18].Value.ToString()
                        + "',MASOTHUE='" + dataGridView1.Rows[dong].Cells[19].Value.ToString()
                        + "',NGAYVAOLAM='" + DateTime.Parse(dataGridView1.Rows[0].Cells[4].Value.ToString()).ToShortDateString()
                        + "',TTHONNHAN='" + dataGridView1.Rows[dong].Cells[21].Value.ToString()
                        + "' where MAHOSO= '" + dataGridView1.Rows[dong].Cells[15].Value.ToString() + "'";
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(strUpdate, cn);
                    SqlCommand cmd2 = new SqlCommand(strUpdate2, cn);
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Thanh cong.");
            }
        }

    }
}
