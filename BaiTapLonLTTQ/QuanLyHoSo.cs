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
    public partial class QuanLyHoSo : Form
    {
        User user;
        DatabaseProcess database = new DatabaseProcess();
        public QuanLyHoSo(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private string check(string a, string b)
        {
            if(b == "")
                return " = ''";
            return " = N'" + a + b + "'"; 
        }

        private void QuanLyHoSo_Load(object sender, EventArgs e)
        {
            if (user.Username == "")
            {
                Visible = false;
                Login login = new Login();
                login.Show();
            }
            for(int i = 0; i < user.Class1.Count; i++)
            {
                char a = user.Class1[i][0];
                char b = user.Class1[i][1];
                if(!cbKhoi.Items.Contains(a)) cbKhoi.Items.Add(a);
                if(!cbLop.Items.Contains(b)) cbLop.Items.Add(b);
            }
            


            string sql = "select * from HS where TenLop " + check(cbKhoi.Text, cbLop.Text);
            DataTable data = database.DataReader(sql);
            dgvHS.DataSource = data;
            dgvHS.Columns[0].HeaderText = "Mã Học Sinh";
            dgvHS.Columns[1].HeaderText = "Tên Học Sinh";
            dgvHS.Columns[2].HeaderText = "Tên Lớp";
            dgvHS.Columns[3].HeaderText = "Ngày Sinh";
            dgvHS.Columns[4].HeaderText = "Giới tính";
            dgvHS.Columns[5].HeaderText = "Địa chỉ";
            dgvHS.Columns[6].HeaderText = "Họ Tên Bố";
            dgvHS.Columns[7].HeaderText = "Nghề nghiệp bố";
            dgvHS.Columns[8].HeaderText = "Số điện thoại bố";
            dgvHS.Columns[9].HeaderText = "Họ tên mẹ";
            dgvHS.Columns[10].HeaderText = "Nghề nghiệp mẹ";
            dgvHS.Columns[11].HeaderText = "Số điện thoại mẹ";            


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLop.Enabled = true;
            QuanLyHoSo_Load(sender, e);
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuanLyHoSo_Load(sender, e);
        }

        private void dgvHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHS.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnUpdate.Enabled = true;
                btnDel.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDel.Enabled = false;
            }
                     
        }
    }
}
