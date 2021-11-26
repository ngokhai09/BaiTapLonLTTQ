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
        ExcelProcess excel = new ExcelProcess();
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
            sql = "select MaHS, HoTen, ChieuCao, CanNang, ChiSoIBM, XepLoaiSucKhoe from SK where TenLop " + check(cbKhoi.Text, cbLop.Text);
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
        private void btnExcel_Click(object sender, EventArgs e)
        {
            dgvHealth.DataSource = excel.readExcel("select MaHS, HoTen, ChieuCao, CanNang, ChiSoBMI, XepLoaiSucKhoe from[Sheet3$]");
            //excel.writeExcel(dgvHS);
            btnXuat.Enabled = true;
            btnUpdate.Enabled = true;

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            List<String> a = new List<string>();
            a.Add("Tên Lớp");
            for (int i = 0; i < 6; i++)
            {
                a.Add(dgvHealth.Columns[i].HeaderText);
            }
            excel.writeExcel(dgvHealth, cbKhoi.Text + cbLop.Text, "SỨC KHỎE", a);
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa? Lưu ý các bước xóa không thể hoàn tác", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                dgvHealth.Rows.Remove(dgvHealth.CurrentRow);
            }
        }
        private string Chuyen(string s)
        {
            string res = "", dd = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != '/')
                {
                    dd += s[i];
                }
                else
                {
                    for (int j = dd.Length - 1; j >= 0; j--)
                    {
                        res += dd[j];
                    }
                    dd = "";
                    res += '-';
                }
            }
            for (int j = dd.Length - 1; j >= 0; j--)
            {
                res += dd[j];
            }
            return res;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < dgvHealth.Rows.Count - 1; j++)
            {


                string sql = "Insert into SoSucKhoe values(";
                for (int i = 0; i < dgvHealth.Columns.Count; i++)
                {
                    if (i == 1) continue;
                    if(i != dgvHealth.Columns.Count - 1)
                        sql += "N'" + dgvHealth.Rows[j].Cells[i].Value.ToString() + "', ";
                    else sql += "N'" + dgvHealth.Rows[j].Cells[i].Value.ToString() + "')";

                }
                if (!database.DataChange(sql))
                {
                    MessageBox.Show("Cập nhật không thành công");
                    return;
                }
            }
            MessageBox.Show("Cập nhật thành công!");
        }
    }
}
