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
    public partial class NhapDanhGiaDK : Form
    {
        User user;
        DatabaseProcess database = new DatabaseProcess();
        public NhapDanhGiaDK(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private string check(string a, string b, string c)
        {
            if (c == "")
                return " = ''";
            return " = N'" + a + b + "' and TenMon = N'" + c + "'";
        }

        private void NhapDanhGiaDK_Load(object sender, EventArgs e)
        {
            if (user.Username == "")
            {
                Visible = false;
                Login login = new Login();
                login.Show();
            }
            for (int i = 0; i < user.Class1.Count; i++)
            {
                char a = user.Class1[i][0];
                char b = user.Class1[i][1];
                if (!cbKhoi.Items.Contains(a)) cbKhoi.Items.Add(a);
                if (!cbLop.Items.Contains(b)) cbLop.Items.Add(b);
            }
            DataTable data;
            string sql;
            if (user.Chucvu != "Bộ Môn")
            {
                sql = "select TenMon from MonHoc";
                data = database.DataReader(sql);
                int n = data.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    if (!cbMon.Items.Contains(data.Rows[i]["TenMon"].ToString()))
                    {
                        cbMon.Items.Add(data.Rows[i]["TenMon"].ToString());
                    }
                }
            }
            else
            {
                if (!cbMon.Items.Contains(user.Subject)) cbMon.Items.Add(user.Subject);
            }

            

            sql = "select MaHS, TenHS, TenLop, TenMon, MucDoDanhGia, NoiDungDanhGia from DG where TenLop " + check(cbKhoi.Text, cbLop.Text, cbMon.Text);
            data = database.DataReader(sql);
            if(data.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
            dgvDK.DataSource = data;
            dgvDK.Columns[0].HeaderText = "Mã Học Sinh";
            dgvDK.Columns[1].HeaderText = "Tên Học Sinh";
            dgvDK.Columns[2].HeaderText = "Tên Lớp";
            dgvDK.Columns[3].HeaderText = "Tên Môn";
            dgvDK.Columns[4].HeaderText = "Mức độ hoàn thành";
            dgvDK.Columns[5].HeaderText = "Nội dung";
            if (data.Rows.Count > 0) btnUpdate.Enabled = true;
            else btnUpdate.Enabled = false;

        }

        private void dgvDK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDK.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void cbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLop.Enabled = true;
            NhapDanhGiaDK_Load(sender, e);
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhapDanhGiaDK_Load(sender, e);
        }

        private void cbMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhapDanhGiaDK_Load(sender, e);
        }

    }
}
