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
    public partial class KH : Form
    {
        SqlConnection connsql;
        public KH()
        {
            ketnoics a = new ketnoics();
            string cnn = a.xuat();
            InitializeComponent();
            //connsql = new SqlConnection(@"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True");
            connsql = new SqlConnection(cnn);
        }

       

        private void thoat_Click(object sender, EventArgs e)
        {
            dangnhap dn = new dangnhap();
            dn.Show();
            this.Close();
        }
        public void Add_X()
        {
            KH_X x = new KH_X();
            x.TopLevel = false;
            panel_tt.Controls.Add(x);         
            x.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;           
            x.Dock = DockStyle.Fill;
            x.Show();
        }
        public void Add_YC()
        {
            KH_YC x1 = new KH_YC();
            x1.TopLevel = false;
            panel_tt.Controls.Add(x1);
            x1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            x1.Dock = DockStyle.Fill;
            x1.Show();
        }
        public void Add_KTN()
        {
            KH_KTN x2 = new KH_KTN();
            x2.TopLevel = false;
            panel_tt.Controls.Add(x2);
            x2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            x2.Dock = DockStyle.Fill;
            x2.Show();
        }
        public void Add_DMK()
        {
            KH_DMK x3 = new KH_DMK();
            x3.TopLevel = false;
            panel_tt.Controls.Add(x3);
            x3.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            x3.Dock = DockStyle.Fill;
            x3.Show();
        }
        private void xemtt_Click(object sender, EventArgs e)
        {
            panel_tt.Controls.Clear();
            Add_X();
            
                     
        }

        private void dmk_Click(object sender, EventArgs e)
        {
            panel_tt.Controls.Clear();
            Add_DMK();
        }

        private void KH_Load(object sender, EventArgs e)
        {
            
            KH_X x = new KH_X();
            x.TopLevel = false;
            panel_tt.Controls.Add(x);
            x.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            x.Dock = DockStyle.Fill;
            x.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            KH_X x = new KH_X();
            x.TopLevel = false;
            panel1.Controls.Add(x);
            x.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            x.Dock = DockStyle.Fill;
            x.Show();
        }

        private void ktno_Click(object sender, EventArgs e)
        {
            panel_tt.Controls.Clear();
            Add_KTN();
        }

        private void ycsuachua_Click(object sender, EventArgs e)
        {
            panel_tt.Controls.Clear();
            Add_YC();
        }

        private void panel_tt_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
