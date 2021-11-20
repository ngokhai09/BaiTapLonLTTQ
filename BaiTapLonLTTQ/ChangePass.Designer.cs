
namespace BaiTapLonLTTQ
{
    partial class ChangePass
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
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtRepass = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.txtOldpass = new System.Windows.Forms.TextBox();
            this.errOld = new System.Windows.Forms.ErrorProvider(this.components);
            this.errPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.errRe = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errRe)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txtPass.Location = new System.Drawing.Point(427, 188);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(243, 36);
            this.txtPass.TabIndex = 2;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // txtRepass
            // 
            this.txtRepass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txtRepass.Location = new System.Drawing.Point(427, 281);
            this.txtRepass.Multiline = true;
            this.txtRepass.Name = "txtRepass";
            this.txtRepass.Size = new System.Drawing.Size(243, 36);
            this.txtRepass.TabIndex = 2;
            this.txtRepass.TextChanged += new System.EventHandler(this.txtRepass_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(585, 351);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(125, 44);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnXacNhan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXacNhan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnXacNhan.Location = new System.Drawing.Point(387, 351);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 44);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtOldpass
            // 
            this.txtOldpass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txtOldpass.Location = new System.Drawing.Point(427, 98);
            this.txtOldpass.Multiline = true;
            this.txtOldpass.Name = "txtOldpass";
            this.txtOldpass.Size = new System.Drawing.Size(243, 36);
            this.txtOldpass.TabIndex = 2;
            this.txtOldpass.TextChanged += new System.EventHandler(this.txtOldpass_TextChanged);
            // 
            // errOld
            // 
            this.errOld.BlinkRate = 0;
            this.errOld.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errOld.ContainerControl = this;
            // 
            // errPass
            // 
            this.errPass.BlinkRate = 0;
            this.errPass.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errPass.ContainerControl = this;
            // 
            // errRe
            // 
            this.errRe.BlinkRate = 0;
            this.errRe.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errRe.ContainerControl = this;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BaiTapLonLTTQ.Properties.Resources.Untitled_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(769, 478);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtRepass);
            this.Controls.Add(this.txtOldpass);
            this.Controls.Add(this.txtPass);
            this.DoubleBuffered = true;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.errOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errRe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtRepass;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.TextBox txtOldpass;
        private System.Windows.Forms.ErrorProvider errOld;
        private System.Windows.Forms.ErrorProvider errPass;
        private System.Windows.Forms.ErrorProvider errRe;
    }
}