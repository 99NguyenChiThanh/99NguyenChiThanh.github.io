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

namespace _CSDLPhantan__QL_Chungcu
{
    public partial class Form1 : Form
    {
        SqlConnection cn;
        string sele;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadLogin();
        }

        private void loadLogin()//Load dữ liệu combobox chi nhánh
        {
            // TODO: This line of code loads data into the '_CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet.CHINHANH' table. You can move, or remove it, as needed.
            this.cHINHANHTableAdapter.Fill(this._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet.CHINHANH);

            p_nv.Visible = false;
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            enablePanel(p_Login, false);
            cn = new SqlConnection("Data Source=TOSHIBA-SATELLI;Initial Catalog=CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K&T;Integrated Security=True");
            cn.Open();
            
            //Kiem tra tai khoan + mat khau
            sele = "Select count(*) from Taikhoan where username = '" + txt_user.Text + "' and pass = '" + txt_pass.Text + "'";
            SqlCommand cmd = new SqlCommand(sele, cn);
            int count = (int)cmd.ExecuteScalar();

            cn.Close();

            if (count > 0)
            {
                loadNV();
            }
            else
            {
                enablePanel(p_Login, true);
                MessageBox.Show("Đăng nhập thất bại.");
                txt_pass.Text = "";
                if (txt_user.Text != "")
                    txt_pass.Focus();
                else
                    txt_user.Focus();
            }
        }

        private void enablePanel(Panel p, bool b)
        {
            //Set panel p enable hay disable
            foreach (Control control in p.Controls)
            {
                control.Enabled = b;
            }
        }

        private void loadNV()
        {
            try
            {
                cn.Open();
                //Kiểm tra username + per
                //Get nhan vien chi nhanh bang username - username la khoa chinh
                
                sele = "Select per from Taikhoan where username = '" + txt_user.Text + "' and per = '" + cbo_Chinhanh.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(sele, cn);
                string per = (string)cmd.ExecuteScalar();
                per = per.Trim();
                cn.Close();

                switch (per)
                {
                    case "cn001"://Chi nhánh 1
                        cn = new SqlConnection("Data Source=TOSHIBA-SATELLI\\MSSQLSERVER2;Initial Catalog=CSDL_CUA_HANG_BAN_QUA_LUU_NIEM;Integrated Security=True");
                        btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnLuu.Enabled = true;
                        txtHoten.ReadOnly = txtMaso.ReadOnly = txtNgaysinh.ReadOnly = txtSDT.ReadOnly = txtDiachi.ReadOnly = false;
                        break;
                    case "cn002"://Chi nhánh 2
                        cn = new SqlConnection("Data Source=TOSHIBA-SATELLI\\MSSQLSERVER3;Initial Catalog=CSDL_CUA_HANG_BAN_QUA_LUU_NIEM;Integrated Security=True");
                        btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnLuu.Enabled = true;
                        txtHoten.ReadOnly = txtMaso.ReadOnly = txtNgaysinh.ReadOnly = txtSDT.ReadOnly = txtDiachi.ReadOnly = false;
                        break;
                    default://Trụ sở chính
                        btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnLuu.Enabled = false;
                        txtHoten.ReadOnly = txtMaso.ReadOnly = txtNgaysinh.ReadOnly = txtSDT.ReadOnly = txtDiachi.ReadOnly = true;
                        break;
                }

                cn.Open();
                //load dataGridView nhanvien
                
                sele = "Select MANV, TENNV, NGSINH, SDT, DIACHI, MACN from Nhanvien";
                SqlDataAdapter da = new SqlDataAdapter(sele, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                cn.Close();

                txt_pass.Text = "";
                p_Login.Visible = false;
                Khoaitimbungtay();
                p_nv.Visible = true;
                lbl_username.Text = cbo_Chinhanh.Text + ",";

                this.Width = 670;
                this.Height = 480;
                //Set vi tri Form sau khi set size
                Rectangle rect = Screen.PrimaryScreen.WorkingArea;
                this.Top = (rect.Height / 2) - (this.Height / 2);
                this.Left = (rect.Width / 2) - (this.Width / 2);
            }
            catch (Exception)
            {
                enablePanel(p_Login, true);
                MessageBox.Show("Đăng nhập thất bại.");
                txt_pass.Text = "";
                if (txt_user.Text != "")
                    txt_pass.Focus();
                else
                    txt_user.Focus();
            }
        }

        private void cbo_Chinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_user.Text = txt_pass.Text = "";
            txt_user.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn thoát?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Logout", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.OK)
            {
                enablePanel(p_Login, true);
                loadLogin();

                p_Login.Visible = true;
                txt_user.Focus();

                this.Width = 456;
                this.Height = 297;
                //Set vi tri Form sau khi set size
                Rectangle rect = Screen.PrimaryScreen.WorkingArea;
                this.Top = (rect.Height / 2) - (this.Height / 2);
                this.Left = (rect.Width / 2) - (this.Width / 2);
            }
        }

        void Khoaitimbungtay()
        {
            txtMaso.Text = txtHoten.Text = txtDiachi.Text = txtNgaysinh.Text = txtSDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Khoaitimbungtay();
            txtMaso.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaso.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNgaysinh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaso.Text != "")
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa '" + txtMaso.Text.Trim() + "'?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (r == DialogResult.OK)
                {
                    try
                    {
                        cn.Open();
                        string xoa = "Delete Nhanvien where Manv = '" + txtMaso.Text + "'";
                        SqlCommand cmd = new SqlCommand(xoa, cn);
                        cmd.ExecuteNonQuery();
                        //load dataGridView nhanvien
                        sele = "Select MANV, TENNV, NGSINH, SDT, DIACHI, MACN from Nhanvien";
                        SqlDataAdapter da = new SqlDataAdapter(sele, cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        cn.Close();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaso.Text != "")
            {
                try
                {
                    //Kiểm tra khóa chính

                    //
                    string chinhanh = cbo_Chinhanh.SelectedValue.ToString().Trim();
                    cn.Open();
                    sele = "Set dateformat DMY Insert into Nhanvien values ('" + txtMaso.Text + "', N'" + txtHoten.Text + "', '" + txtNgaysinh.Text + "', '" + txtSDT.Text + "', N'" + txtDiachi.Text + "', '" + chinhanh + "', newID())";
                    SqlCommand cmd = new SqlCommand(sele, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công.");
                    //load dataGridView nhanvien
                    sele = "Select MANV, TENNV, NGSINH, SDT, DIACHI, MACN from Nhanvien";
                    SqlDataAdapter da = new SqlDataAdapter(sele, cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lưu thất bại.");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaso.Text != "")
            {
                try
                {
                    cn.Open();
                    string sua = "Update Nhanvien set Tennv = N'" + txtHoten.Text + "', Ngsinh = '', SDT = '" + txtSDT.Text + "', Diachi = N'" + txtDiachi.Text + "' where Manv='" + txtMaso.Text + "'";
                    SqlCommand cmd = new SqlCommand(sua, cn);
                    cmd.ExecuteNonQuery();
                    //load dataGridView nhanvien
                    sele = "Select MANV, TENNV, NGSINH, SDT, DIACHI, MACN from Nhanvien";
                    SqlDataAdapter da = new SqlDataAdapter(sele, cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại.");
                }
            }
        }
    }
}
