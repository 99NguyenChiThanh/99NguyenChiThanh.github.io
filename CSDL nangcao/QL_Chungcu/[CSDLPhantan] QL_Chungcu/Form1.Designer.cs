namespace _CSDLPhantan__QL_Chungcu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.p_Login = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_Chinhanh = new System.Windows.Forms.ComboBox();
            this.cHINHANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet = new _CSDLPhantan__QL_Chungcu._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.p_nv = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.lbl_username = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtNgaysinh = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaso = new System.Windows.Forms.TextBox();
            this.btn_logout = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cHINHANHTableAdapter = new _CSDLPhantan__QL_Chungcu._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSetTableAdapters.CHINHANHTableAdapter();
            this.p_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cHINHANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet)).BeginInit();
            this.p_nv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Login
            // 
            this.p_Login.Controls.Add(this.label5);
            this.p_Login.Controls.Add(this.cbo_Chinhanh);
            this.p_Login.Controls.Add(this.label4);
            this.p_Login.Controls.Add(this.label3);
            this.p_Login.Controls.Add(this.label2);
            this.p_Login.Controls.Add(this.btn_dangnhap);
            this.p_Login.Controls.Add(this.txt_pass);
            this.p_Login.Controls.Add(this.txt_user);
            this.p_Login.Location = new System.Drawing.Point(12, 12);
            this.p_Login.Name = "p_Login";
            this.p_Login.Size = new System.Drawing.Size(416, 234);
            this.p_Login.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Chi nhánh:";
            // 
            // cbo_Chinhanh
            // 
            this.cbo_Chinhanh.DataSource = this.cHINHANHBindingSource;
            this.cbo_Chinhanh.DisplayMember = "CHINHANH";
            this.cbo_Chinhanh.FormattingEnabled = true;
            this.cbo_Chinhanh.Location = new System.Drawing.Point(144, 14);
            this.cbo_Chinhanh.Name = "cbo_Chinhanh";
            this.cbo_Chinhanh.Size = new System.Drawing.Size(204, 21);
            this.cbo_Chinhanh.TabIndex = 2;
            this.cbo_Chinhanh.ValueMember = "MACN";
            this.cbo_Chinhanh.SelectedIndexChanged += new System.EventHandler(this.cbo_Chinhanh_SelectedIndexChanged);
            // 
            // cHINHANHBindingSource
            // 
            this.cHINHANHBindingSource.DataMember = "CHINHANH";
            this.cHINHANHBindingSource.DataSource = this._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet;
            // 
            // _CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet
            // 
            this._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet.DataSetName = "_CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet";
            this._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "ĐĂNG NHẬP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tài khoản:";
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.Location = new System.Drawing.Point(117, 185);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(188, 34);
            this.btn_dangnhap.TabIndex = 7;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(144, 142);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(188, 20);
            this.txt_pass.TabIndex = 1;
            this.txt_pass.UseSystemPasswordChar = true;
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(144, 100);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(188, 20);
            this.txt_user.TabIndex = 0;
            // 
            // p_nv
            // 
            this.p_nv.Controls.Add(this.btnSua);
            this.p_nv.Controls.Add(this.lbl_username);
            this.p_nv.Controls.Add(this.btnThem);
            this.p_nv.Controls.Add(this.btnXoa);
            this.p_nv.Controls.Add(this.btnLuu);
            this.p_nv.Controls.Add(this.btnExit);
            this.p_nv.Controls.Add(this.txtHoten);
            this.p_nv.Controls.Add(this.txtDiachi);
            this.p_nv.Controls.Add(this.txtSDT);
            this.p_nv.Controls.Add(this.txtNgaysinh);
            this.p_nv.Controls.Add(this.label10);
            this.p_nv.Controls.Add(this.label9);
            this.p_nv.Controls.Add(this.label8);
            this.p_nv.Controls.Add(this.label7);
            this.p_nv.Controls.Add(this.label6);
            this.p_nv.Controls.Add(this.label1);
            this.p_nv.Controls.Add(this.txtMaso);
            this.p_nv.Controls.Add(this.btn_logout);
            this.p_nv.Controls.Add(this.dataGridView1);
            this.p_nv.Location = new System.Drawing.Point(0, 0);
            this.p_nv.Name = "p_nv";
            this.p_nv.Size = new System.Drawing.Size(652, 441);
            this.p_nv.TabIndex = 1;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(272, 198);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 19;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.Location = new System.Drawing.Point(498, 8);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(70, 13);
            this.lbl_username.TabIndex = 11;
            this.lbl_username.Text = "aaaaaaaaaa,";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(110, 198);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(191, 198);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(372, 198);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(534, 183);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(97, 107);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(164, 20);
            this.txtHoten.TabIndex = 1;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(97, 139);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(250, 20);
            this.txtDiachi.TabIndex = 2;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(462, 107);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(100, 20);
            this.txtSDT.TabIndex = 4;
            // 
            // txtNgaysinh
            // 
            this.txtNgaysinh.Location = new System.Drawing.Point(462, 76);
            this.txtNgaysinh.Name = "txtNgaysinh";
            this.txtNgaysinh.Size = new System.Drawing.Size(100, 20);
            this.txtNgaysinh.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(429, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Sđt:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(399, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ngày sinh:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Địa chỉ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Họ tên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(186, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(252, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mã số:";
            // 
            // txtMaso
            // 
            this.txtMaso.Location = new System.Drawing.Point(97, 76);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.Size = new System.Drawing.Size(164, 20);
            this.txtMaso.TabIndex = 0;
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(574, 3);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 23);
            this.btn_logout.TabIndex = 10;
            this.btn_logout.Text = "Đăng xuất";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 244);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(646, 194);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cHINHANHTableAdapter
            // 
            this.cHINHANHTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_dangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 258);
            this.Controls.Add(this.p_Login);
            this.Controls.Add(this.p_nv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân viên cửa hàng bán đồ lưu niệm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.p_Login.ResumeLayout(false);
            this.p_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cHINHANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet)).EndInit();
            this.p_nv.ResumeLayout(false);
            this.p_nv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Panel p_nv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_Chinhanh;
        private _CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet _CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSet;
        private System.Windows.Forms.BindingSource cHINHANHBindingSource;
        private _CSDLPhanTan_CUA_HANG_BAN_QUA_LUU_NIEM_K_TDataSetTableAdapters.CHINHANHTableAdapter cHINHANHTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtNgaysinh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaso;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Button btnSua;
    }
}