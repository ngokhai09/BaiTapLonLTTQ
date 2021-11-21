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
    public partial class NhapSK : Form
    {
        User user;
        DatabaseProcess database = new DatabaseProcess();
        public NhapSK(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private string check(string a, string b)
        {
            if (b == "")
                return " = ''";
            return " = N'" + a + b + "'";
        }

        private void NhapSK_Load(object sender, EventArgs e)
        {
            if (user.Username == "")
            {
                Visible = false;
                Login login = new Login();
                login.Show();
            }
            string sql;
            DataTable data;
            if (user.Chucvu == "Chủ Nhiệm")
            {
                for (int i = 0; i < user.Class1.Count; i++)
                {
                    char a = user.Class1[i][0];
                    char b = user.Class1[i][1];
                    if (!cbKhoi.Items.Contains(a)) cbKhoi.Items.Add(a);
                    if (!cbLop.Items.Contains(b)) cbLop.Items.Add(b);
                }
            }
            else
            {
                sql = "Select TenLop from Lop";
                data = database.DataReader(sql);
                int n = data.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    char a = data.Rows[i]["TenLop"].ToString()[0];
                    char b = data.Rows[i]["TenLop"].ToString()[1];
                    if (!cbKhoi.Items.Contains(a)) cbKhoi.Items.Add(a);
                    if (!cbLop.Items.Contains(b)) cbLop.Items.Add(b);
                }
            }
            sql = "select * from SK where TenLop " + check(cbKhoi.Text, cbLop.Text);
            data = database.DataReader(sql);
            if (data.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }

            dgvHealth.DataSource = data;
            dgvHealth.Columns[0].HeaderText = "Mã Học Sinh";
            dgvHealth.Columns[1].HeaderText = "Tên Học Sinh";
            dgvHealth.Columns[2].HeaderText = "Chiều Cao";
            dgvHealth.Columns[3].HeaderText = "Cân Nặng";
            dgvHealth.Columns[4].HeaderText = "Chỉ số BMI";
            dgvHealth.Columns[5].HeaderText = "Xếp Loại Sức Khỏe";
        }
        private void cbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLop.Enabled = true;
            NhapSK_Load(sender, e);
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhapSK_Load(sender, e);
        }
    }
}
