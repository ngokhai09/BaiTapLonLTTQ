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
    public partial class ChangePass : Form
    {
        User user;
        DatabaseProcess databaseProcess = new DatabaseProcess();
        public ChangePass(User user)
        {
            InitializeComponent();
            this.user = user;
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

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            bool OK = true;
            errOld.Clear();
            errPass.Clear();
            errRe.Clear();
            if (txtOldpass.Text == "")
            {
                errOld.SetError(txtOldpass, "Bạn chưa nhập mật khẩu cũ");
                OK = false;
            }
            if (txtPass.Text == "")
            {
                errPass.SetError(txtPass, "Bạn chưa nhập mật khẩu");
                OK = false;
            }
            if (txtRepass.Text == "")
            {
                errRe.SetError(txtRepass, "Bạn chưa nhập lại mật khẩu");
                OK = false;
            }
            if(txtPass.Text != txtRepass.Text)
            {
                errRe.SetError(txtRepass, "Mật khẩu không khớp");
                OK = false;
            }
            if (!OK)
            {
                return;
            }
            if(txtOldpass.Text != user.Password)
            {
                errOld.SetError(txtOldpass, "Bạn nhập sai mật khẩu");
            }
            else
            {
                string sql = "Update TaiKhoan set MatKhau = '" + txtPass.Text + "' where Tentaikhoan = N'" + user.Username + "'";
                databaseProcess.DataChange(sql);
                MessageBox.Show("Bạn đã đổi mật khẩu thành công!","Thông báo" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                Visible = false;
            }
            
        }

        private void txtOldpass_TextChanged(object sender, EventArgs e)
        {
            errOld.Clear();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            errPass.Clear();
        }

        private void txtRepass_TextChanged(object sender, EventArgs e)
        {
            errRe.Clear();
        }
    }
}
