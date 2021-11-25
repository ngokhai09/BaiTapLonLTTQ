using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
        ExcelProcess excel = new ExcelProcess();
        List<string> delString = new List<string>();
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
                for(int i = 0; i < n; i++)
                {
                    char a = data.Rows[i]["TenLop"].ToString()[0];
                    char b = data.Rows[i]["TenLop"].ToString()[1];
                    if (!cbKhoi.Items.Contains(a)) cbKhoi.Items.Add(a);
                    if (!cbLop.Items.Contains(b)) cbLop.Items.Add(b);
                }
            }
            
            


            sql = "select MaHS, HoTen, NgaySinh, GioiTinh, DiaChi, HoTenCha, NgheNghiepCha, SDTCha, HoTenMe, NgheNghiepMe, SDTMe from HS where TenLop " + check(cbKhoi.Text, cbLop.Text);
            data = database.DataReader(sql);
            if(data.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                btnXuat.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnXuat.Enabled = false;
            }
            dgvHS.DataSource = data;
            dgvHS.Columns[0].HeaderText = "Mã Học Sinh";
            dgvHS.Columns[1].HeaderText = "Tên Học Sinh";
            dgvHS.Columns[2].HeaderText = "Ngày Sinh";
            dgvHS.Columns[3].HeaderText = "Giới tính";
            dgvHS.Columns[4].HeaderText = "Địa chỉ";
            dgvHS.Columns[5].HeaderText = "Họ tên cha";
            dgvHS.Columns[6].HeaderText = "Nghề nghiệp cha";
            dgvHS.Columns[7].HeaderText = "Số điện thoại cha";
            dgvHS.Columns[8].HeaderText = "Họ tên mẹ";
            dgvHS.Columns[9].HeaderText = "Nghề nghiệp mẹ";
            dgvHS.Columns[10].HeaderText = "Số điện thoại mẹ";


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLop.Enabled = true;
            QuanLyHoSo_Load(sender, e);
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExcel.Enabled = true;
            QuanLyHoSo_Load(sender, e);
        }

        private void dgvHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                     
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            dgvHS.DataSource = excel.readExcel("Select MaHS, HoTen, NgaySinh, GioiTinh, DiaChi, HoTenCha, NgheNghiepCha, SDTCha, HoTenMe, NgheNghiepMe, SDTMe from [Sheet1$]");
            //excel.writeExcel(dgvHS);
            btnXuat.Enabled = true;
            
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            List<String> a = new List<string>();
            a.Add("Tên Lớp");
            for(int i = 0; i < 11; i++)
            {
                a.Add(dgvHS.Columns[i].HeaderText);
            }
            excel.writeExcel(dgvHS, cbKhoi.Text + cbLop.Text, "HỌC SINH", a);
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa? Lưu ý các bước xóa không thể hoàn tác", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(rs == DialogResult.Yes)
            {
                dgvHS.Rows.Remove(dgvHS.CurrentRow);
            }            
        }

        private void btnUnTick_Click(object sender, EventArgs e)
        {
            delString.Remove(dgvHS.CurrentRow.Cells[0].Value.ToString());
            dgvHS.CurrentRow.DefaultCellStyle.BackColor = Color.White;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "Delete from HocSinh where where MAHS = any (Select MaHS from HS where TenLop = N'"+ cbKhoi.Text + cbLop.Text +"')";
            if (!database.DataChange(sql))
            {
                MessageBox.Show("Cập nhật không thành công!");
                return;
            }
        }
    }
}
