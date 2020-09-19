namespace QLWiFi
{
    partial class KH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KH));
            this.bt_dmk = new System.Windows.Forms.Button();
            this.bt_xemtt = new System.Windows.Forms.Button();
            this.bt_ktno = new System.Windows.Forms.Button();
            this.bt_ycsuachua = new System.Windows.Forms.Button();
            this.bt_thoat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_tt = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_dmk
            // 
            this.bt_dmk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_dmk.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_dmk.ForeColor = System.Drawing.Color.Black;
            this.bt_dmk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_dmk.Location = new System.Drawing.Point(362, 19);
            this.bt_dmk.Name = "bt_dmk";
            this.bt_dmk.Size = new System.Drawing.Size(224, 49);
            this.bt_dmk.TabIndex = 2;
            this.bt_dmk.Text = "Đổi mật khẩu wifi";
            this.bt_dmk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_dmk.UseVisualStyleBackColor = false;
            this.bt_dmk.Click += new System.EventHandler(this.dmk_Click);
            // 
            // bt_xemtt
            // 
            this.bt_xemtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_xemtt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xemtt.ForeColor = System.Drawing.Color.Black;
            this.bt_xemtt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_xemtt.Location = new System.Drawing.Point(12, 19);
            this.bt_xemtt.Name = "bt_xemtt";
            this.bt_xemtt.Size = new System.Drawing.Size(187, 49);
            this.bt_xemtt.TabIndex = 0;
            this.bt_xemtt.Text = "Xem thông tin";
            this.bt_xemtt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_xemtt.UseVisualStyleBackColor = false;
            this.bt_xemtt.Click += new System.EventHandler(this.xemtt_Click);
            // 
            // bt_ktno
            // 
            this.bt_ktno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_ktno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ktno.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bt_ktno.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ktno.ForeColor = System.Drawing.Color.Black;
            this.bt_ktno.ImageKey = "(none)";
            this.bt_ktno.Location = new System.Drawing.Point(195, 19);
            this.bt_ktno.Name = "bt_ktno";
            this.bt_ktno.Size = new System.Drawing.Size(170, 49);
            this.bt_ktno.TabIndex = 1;
            this.bt_ktno.Text = "Kiểm tra nợ";
            this.bt_ktno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_ktno.UseVisualStyleBackColor = false;
            this.bt_ktno.Click += new System.EventHandler(this.ktno_Click);
            // 
            // bt_ycsuachua
            // 
            this.bt_ycsuachua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_ycsuachua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ycsuachua.ForeColor = System.Drawing.Color.Black;
            this.bt_ycsuachua.Location = new System.Drawing.Point(582, 19);
            this.bt_ycsuachua.Name = "bt_ycsuachua";
            this.bt_ycsuachua.Size = new System.Drawing.Size(214, 49);
            this.bt_ycsuachua.TabIndex = 3;
            this.bt_ycsuachua.Text = "Yêu cầu sửa chữa";
            this.bt_ycsuachua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_ycsuachua.UseVisualStyleBackColor = false;
            this.bt_ycsuachua.Click += new System.EventHandler(this.ycsuachua_Click);
            // 
            // bt_thoat
            // 
            this.bt_thoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_thoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_thoat.BackgroundImage")));
            this.bt_thoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_thoat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thoat.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_thoat.Location = new System.Drawing.Point(790, 19);
            this.bt_thoat.Name = "bt_thoat";
            this.bt_thoat.Size = new System.Drawing.Size(63, 49);
            this.bt_thoat.TabIndex = 4;
            this.bt_thoat.UseVisualStyleBackColor = false;
            this.bt_thoat.Click += new System.EventHandler(this.thoat_Click);
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = "";
            this.panel1.AccessibleName = "";
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(19, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 304);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 44);
            this.panel2.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.bt_thoat);
            this.groupBox2.Controls.Add(this.bt_xemtt);
            this.groupBox2.Controls.Add(this.bt_ktno);
            this.groupBox2.Controls.Add(this.bt_ycsuachua);
            this.groupBox2.Controls.Add(this.bt_dmk);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Gray;
            this.groupBox2.Location = new System.Drawing.Point(9, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(855, 81);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(592, 29);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(49, 28);
            this.panel6.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(371, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(49, 28);
            this.panel5.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(22, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(41, 30);
            this.panel4.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(205, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(51, 30);
            this.panel3.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(243, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "Quản lý và chăm sóc khách hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(722, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Liên hệ hỗ trợ : 19006600";
            // 
            // panel_tt
            // 
            this.panel_tt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_tt.Location = new System.Drawing.Point(9, 144);
            this.panel_tt.Name = "panel_tt";
            this.panel_tt.Size = new System.Drawing.Size(853, 305);
            this.panel_tt.TabIndex = 14;
            // 
            // KH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(874, 461);
            this.Controls.Add(this.panel_tt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KH";
            this.Text = "Chức năng khách hàng";
            this.Load += new System.EventHandler(this.KH_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_dmk;
        private System.Windows.Forms.Button bt_xemtt;
        private System.Windows.Forms.Button bt_ktno;
        private System.Windows.Forms.Button bt_ycsuachua;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_thoat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_tt;
    }
}