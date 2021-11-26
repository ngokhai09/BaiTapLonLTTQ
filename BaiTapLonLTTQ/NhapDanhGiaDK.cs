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
        ExcelProcess excel = new ExcelProcess();
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
            DataTable data;
            string sql;
            if (user.Chucvu == "Bộ Môn")
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
                sql = "select TenLop from Lop";
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

            

            sql = "select MaHS, HoTen, TenMon, MucDoDanhGia, NoiDungDanhGia from DG where TenLop " + check(cbKhoi.Text, cbLop.Text, cbMon.Text);
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
            dgvDK.Columns[2].HeaderText = "Tên Môn";
            dgvDK.Columns[3].HeaderText = "Mức độ hoàn thành";
            dgvDK.Columns[4].HeaderText = "Nội dung";
            if (data.Rows.Count > 0) btnUpdate.Enabled = true;
            else btnUpdate.Enabled = false;

        }

        private void dgvDK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDK.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnTick.Enabled = true;                
            }
            else
            {
                btnTick.Enabled = false;
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
            btnExcel.Enabled = true;
            btnUpdate.Enabled = true;
            btnXuat.Enabled = true;
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            dgvDK.DataSource = excel.readExcel("select MaHS, HoTen, TenMon, MucDoDanhGia, NoiDungDanhGia from [Sheet2$]");
            //excel.writeExcel(dgvHS);
            btnXuat.Enabled = true;
            btnUpdate.Enabled = true;

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            List<String> a = new List<string>();
            a.Add("Tên Lớp");
            for (int i = 0; i < 5; i++)
            {
                a.Add(dgvDK.Columns[i].HeaderText);
            }
            excel.writeExcel(dgvDK, cbKhoi.Text + cbLop.Text, "ĐÁNH GIÁ ĐỊNH KỲ", a);
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa? Lưu ý các bước xóa không thể hoàn tác", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                dgvDK.Rows.Remove(dgvDK.CurrentRow);
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
            string sql = "select MaMon from Lop where TenMon = N'" + cbMon.Text + "'";
            string ml = database.DataReader(sql).Rows[0]["MaMon"].ToString();
            sql = "Delete from DanhGia where MaMon = N'" + ml + "'";
            if (!database.DataChange(sql))
            {
                MessageBox.Show("Cập nhật không thành công!");
                return;
            }

            for (int j = 0; j < dgvDK.Rows.Count - 1; j++)
            {


                sql = "Insert into DanhGia () values(";
                for (int i = 0; i < dgvDK.Columns.Count; i++)
                {
                    sql += "N'" + dgvDK.Rows[j].Cells[i].Value.ToString() + "', ";
                }
                sql += " N'" + ml + "')";
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
