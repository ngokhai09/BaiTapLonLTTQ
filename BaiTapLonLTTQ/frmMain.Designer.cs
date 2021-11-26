
namespace BaiTapLonLTTQ
{
    partial class frmMain
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.Student = new System.Windows.Forms.ToolStripMenuItem();
            this.Profile = new System.Windows.Forms.ToolStripMenuItem();
            this.Evaluate1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Evaluate2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Healthy = new System.Windows.Forms.ToolStripMenuItem();
            this.mntDSGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnDrop = new System.Windows.Forms.Panel();
            this.btnEx = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnDrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Student,
            this.mntDSGiaoVien});
            this.menuStrip2.Location = new System.Drawing.Point(0, 50);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(1452, 28);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.MouseEnter += new System.EventHandler(this.panel2_Leave);
            // 
            // Student
            // 
            this.Student.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Profile,
            this.Evaluate1,
            this.Evaluate2,
            this.Healthy});
            this.Student.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Student.Image = global::BaiTapLonLTTQ.Properties.Resources.Teacher_icon;
            this.Student.Name = "Student";
            this.Student.Size = new System.Drawing.Size(111, 24);
            this.Student.Text = "1. Học sinh";
            // 
            // Profile
            // 
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(259, 26);
            this.Profile.Text = "1.1 Quản lý hồ sơ học sinh";
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // Evaluate1
            // 
            this.Evaluate1.Name = "Evaluate1";
            this.Evaluate1.Size = new System.Drawing.Size(259, 26);
            this.Evaluate1.Text = "1.2 Đánh giá thường xuyên";
            this.Evaluate1.Click += new System.EventHandler(this.Evaluate1_Click);
            // 
            // Evaluate2
            // 
            this.Evaluate2.BackColor = System.Drawing.Color.Transparent;
            this.Evaluate2.Name = "Evaluate2";
            this.Evaluate2.Size = new System.Drawing.Size(259, 26);
            this.Evaluate2.Text = "1.3 Đánh giá định kỳ";
            this.Evaluate2.Click += new System.EventHandler(this.Evaluate2_Click);
            // 
            // Healthy
            // 
            this.Healthy.Name = "Healthy";
            this.Healthy.Size = new System.Drawing.Size(259, 26);
            this.Healthy.Text = "1.4 Sức khỏe";
            this.Healthy.Click += new System.EventHandler(this.Healthy_Click);
            // 
            // mntDSGiaoVien
            // 
            this.mntDSGiaoVien.Image = global::BaiTapLonLTTQ.Properties.Resources.Custom_reports_icon;
            this.mntDSGiaoVien.Name = "mntDSGiaoVien";
            this.mntDSGiaoVien.Size = new System.Drawing.Size(196, 24);
            this.mntDSGiaoVien.Text = "2. Danh Sách Giáo Viên";
            this.mntDSGiaoVien.Click += new System.EventHandler(this.mntDSGiaoVien_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1452, 50);
            this.panel3.TabIndex = 1;
            this.panel3.MouseEnter += new System.EventHandler(this.panel2_Leave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Brown;
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(191, 46);
            this.panel5.TabIndex = 25;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BaiTapLonLTTQ.Properties.Resources.ea071b56_0a7e_475e_8348_14b737eb9319logo_shn;
            this.pictureBox2.Location = new System.Drawing.Point(17, 9);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.panel5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Brown;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(53, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 24);
            this.label8.TabIndex = 22;
            this.label8.Text = "HANOI-EDU";
            this.label8.Click += new System.EventHandler(this.panel5_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(199, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "TIỂU HỌC VIỆT HÙNG";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.menuStrip2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1452, 82);
            this.panel1.TabIndex = 43;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.White;
            this.pnMain.BackgroundImage = global::BaiTapLonLTTQ.Properties.Resources.school_education_building_street_outdoor_landscape_cartoon_illustration_7081_1942;
            this.pnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 82);
            this.pnMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1452, 668);
            this.pnMain.TabIndex = 45;
            this.pnMain.MouseEnter += new System.EventHandler(this.panel2_Leave);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.BackgroundImage = global::BaiTapLonLTTQ.Properties.Resources.Untitled_h;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pnDrop);
            this.panel2.Location = new System.Drawing.Point(1219, -10);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(233, 177);
            this.panel2.TabIndex = 46;
            // 
            // pnDrop
            // 
            this.pnDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnDrop.BackColor = System.Drawing.Color.Maroon;
            this.pnDrop.Controls.Add(this.btnEx);
            this.pnDrop.Controls.Add(this.btnExit);
            this.pnDrop.Controls.Add(this.btnDrop);
            this.pnDrop.Controls.Add(this.btnChangePass);
            this.pnDrop.Location = new System.Drawing.Point(5, 2);
            this.pnDrop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnDrop.MaximumSize = new System.Drawing.Size(213, 177);
            this.pnDrop.MinimumSize = new System.Drawing.Size(213, 54);
            this.pnDrop.Name = "pnDrop";
            this.pnDrop.Size = new System.Drawing.Size(213, 58);
            this.pnDrop.TabIndex = 38;
            // 
            // btnEx
            // 
            this.btnEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEx.BackColor = System.Drawing.Color.Tomato;
            this.btnEx.FlatAppearance.BorderSize = 0;
            this.btnEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEx.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEx.Location = new System.Drawing.Point(4, 135);
            this.btnEx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEx.Name = "btnEx";
            this.btnEx.Size = new System.Drawing.Size(207, 33);
            this.btnEx.TabIndex = 37;
            this.btnEx.Text = "Thoát";
            this.btnEx.UseVisualStyleBackColor = false;
            this.btnEx.Click += new System.EventHandler(this.btnEx_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Tomato;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(3, 98);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(207, 33);
            this.btnExit.TabIndex = 37;
            this.btnExit.Text = "Đăng xuất";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDrop
            // 
            this.btnDrop.BackColor = System.Drawing.Color.Maroon;
            this.btnDrop.FlatAppearance.BorderSize = 0;
            this.btnDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrop.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDrop.Image = global::BaiTapLonLTTQ.Properties.Resources.down;
            this.btnDrop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDrop.Location = new System.Drawing.Point(4, 7);
            this.btnDrop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(207, 47);
            this.btnDrop.TabIndex = 37;
            this.btnDrop.Text = "button1";
            this.btnDrop.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDrop.UseVisualStyleBackColor = false;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePass.BackColor = System.Drawing.Color.Tomato;
            this.btnChangePass.FlatAppearance.BorderSize = 0;
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePass.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnChangePass.Location = new System.Drawing.Point(3, 59);
            this.btnChangePass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(207, 33);
            this.btnChangePass.TabIndex = 37;
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1452, 750);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnDrop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Student;
        private System.Windows.Forms.ToolStripMenuItem Profile;
        private System.Windows.Forms.ToolStripMenuItem Evaluate1;
        private System.Windows.Forms.ToolStripMenuItem Evaluate2;
        private System.Windows.Forms.ToolStripMenuItem Healthy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnDrop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEx;
        private System.Windows.Forms.ToolStripMenuItem mntDSGiaoVien;
    }
}