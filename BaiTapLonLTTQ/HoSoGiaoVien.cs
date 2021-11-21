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
    public partial class HoSoGiaoVien : Form
    {
        User user;
        DatabaseProcess database = new DatabaseProcess();
        List<string> delString = new List<string>();
        public HoSoGiaoVien(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private string check(string s)
        {
            if (s == "Chưa có tài khoản")
            {
                return "where TenTaiKhoan = '' ";
            }
            else if(s == "Tất cả")
            {
                return "";
            }
            return "where Tentaikhoan != '' ";
        }

        private void HoSoGiaoVien_Load(object sender, EventArgs e)
        {
            if (user.Username == "")
            {
                Visible = false;
                Login login = new Login();
                login.Show();
            }
            string sql = "select * from tblinfo " + check(comboBox1.Text);
            DataTable dataTable = database.DataReader(sql);
            dgvList.DataSource = dataTable;
            dgvList.Columns[0].HeaderText = "Mã Giáo Viên";
            dgvList.Columns[1].HeaderText = "Tên Giáo Viên";
            dgvList.Columns[2].HeaderText = "Môn Học";
            dgvList.Columns[3].HeaderText = "Địa Chỉ";
            dgvList.Columns[4].HeaderText = "Số Điện Thoại";
            dgvList.Columns[5].HeaderText = "Tên Lớp";
            dgvList.Columns[6].HeaderText = "Chức Vụ";
            dgvList.Columns[7].HeaderText = "Tài Khoản";
            dgvList.Columns[8].HeaderText = "Mật Khẩu";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HoSoGiaoVien_Load(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            delString.Add(dgvList.CurrentRow.Cells[0].Value.ToString());
            dgvList.CurrentRow.DefaultCellStyle.BackColor = Color.Red;            
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnUnTick.Enabled = true;
            }
            else
            {
                btnUnTick.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool Del = true, Update = true;
            foreach(string item  in delString)
            {
                string sql = "Delete from GiaoVien where MaGV = N'" + item + "'";
                if (database.DataChange(sql))
                {
                    delString.Remove(item);
                }
            }
            string str = "";
            foreach(string item in delString)
            {
                str += item + "\n";
            }
            if(str != "")
            {
                MessageBox.Show("Xóa không thành công các giáo viên có mã:\n" + str, "Thông Báo", MessageBoxButtons.OK);
                Del = false;
            }
            

        }

        private void btnUnTick_Click(object sender, EventArgs e)
        {
            delString.Remove(dgvList.CurrentRow.Cells[0].Value.ToString());
            dgvList.CurrentRow.DefaultCellStyle.BackColor = Color.White;
        }
    }
}
