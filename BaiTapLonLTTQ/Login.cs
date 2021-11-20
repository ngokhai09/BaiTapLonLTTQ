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
    public partial class Login : Form
    {
        DatabaseProcess databaseProcess = new DatabaseProcess();
        public Login()
        {
            InitializeComponent();
        }

        private void Exit()
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool OK = true;
            if (txtAccount.Text == "")
            {
                ErrAcc.SetError(txtAccount, "Bạn chưa nhập tên tài khoản");
                OK = false;
            }
            if (txtPassword.Text == "")
            {
                ErrPass.SetError(txtPassword, "Bạn chưa nhập mật khẩu");
                OK = false;
            }
            if (true == OK)
            {

                DataTable dataTable = new DataTable();
                string sql = "select TenGV, MatKhau from tblinfo where Tentaikhoan = N'" + txtAccount.Text + " '";
                dataTable = databaseProcess.DataReader(sql);
                if (dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows[0]["MatKhau"].ToString().Trim() == txtPassword.Text.Trim())
                    {
                        Visible = false;
                        User user = new User(txtAccount.Text, txtPassword.Text, dataTable.Rows[0]["TenGV"].ToString().Trim());
                        frmMain frm = new frmMain(user);
                        frm.Show();
                    }
                    else
                    {
                        ErrPass.SetError(txtPassword, "Sai mật khẩu");
                    }
                }
                else
                {
                    ErrAcc.SetError(txtAccount, "Sai tài khoản");
                    ErrAcc.SetError(txtPassword, "Sai mật khẩu");
                }

            }

        }

        private void pbEye_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == false)
            {
                txtPassword.UseSystemPasswordChar = true;
                pbEye.Image = Properties.Resources._255068247_1176629489530584_4810341375929650200_n;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                pbEye.Image = Properties.Resources._255141477_233769452156046_1741164875815994290_n;
            }
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            if (txtAccount.Text != "") ErrAcc.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "") ErrPass.Clear();
        }
    }
}
