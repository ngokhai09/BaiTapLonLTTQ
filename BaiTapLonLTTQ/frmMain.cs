using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonLTTQ
{
    public partial class frmMain : Form
    {
        User user;    
        private Form currentFormChild;
        private bool isCollased = true;
        DataTable dataTable;
        DatabaseProcess databaseProcess = new DatabaseProcess();
        public frmMain(User user)
        {
            InitializeComponent();
            this.user = user;
            string sql = "Select TenCV, TenLop, TenMon from tblinfo where Tentaikhoan = N'" + user.Username + "'";
            dataTable = databaseProcess.DataReader(sql);
            int n = dataTable.Rows.Count;
            user.Chucvu = dataTable.Rows[0]["TenCV"].ToString().Trim();
            if (user.Chucvu == "Bộ Môn")
            {
                Profile.Enabled = false;
                Healthy.Enabled = false;
                mntDSGiaoVien.Enabled = false;
                Healthy.Enabled = false;
                menuStrip2.Enabled = false;
            }
            else if(user.Chucvu == "Chủ Nhiệm")
            {
                mntDSGiaoVien.Enabled = false;
                mntGiaoVien.Enabled = false;
            }
            for(int i = 0; i < n; i++)
            {
                user.Class1.Add(dataTable.Rows[i]["TenLop"].ToString().Trim());
            }
            user.Subject = dataTable.Rows[0]["TenMon"].ToString().Trim();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnDrop.Text = user.Name;
        }

        private void callChildFrom(Form childFrom)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childFrom);
            pnMain.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            callChildFrom(new QuanLyHoSo(user));
        }

        private void Evaluate1_Click(object sender, EventArgs e)
        {
            callChildFrom(new NhapDanhGiaTX(user));
        }

        private void Evaluate2_Click(object sender, EventArgs e)
        {
            callChildFrom(new NhapDanhGiaDK(user));
        }

        private void Healthy_Click(object sender, EventArgs e)
        {
            callChildFrom(new NhapSK(user));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollased)
            {
                panel2.BringToFront();
                pnDrop.Height += 10;
                btnDrop.Image = Properties.Resources.up;
                if(pnDrop.Size == pnDrop.MaximumSize)
                {
                    isCollased = false;
                    timer1.Stop();
                }
            }
            else
            {
                pnMain.BringToFront();
                pnDrop.Height -= 10;
                btnDrop.Image = Properties.Resources.down;
                if (pnDrop.Size == pnDrop.MinimumSize)
                {
                    isCollased = true;
                    timer1.Stop();
                }
            }
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePass register = new ChangePass(user);
            register.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Visible = false;
                Login login = new Login();
                login.Show();
            }
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            if(currentFormChild != null)
                currentFormChild.Close();
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn Thoát không?", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void mntDSGiaoVien_Click(object sender, EventArgs e)
        {
            callChildFrom(new HoSoGiaoVien(user));
        }

        private void panel2_Leave(object sender, EventArgs e)
        {
            isCollased = false;
            timer1.Start();
        }

    }
}
