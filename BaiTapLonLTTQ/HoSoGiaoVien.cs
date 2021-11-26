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
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa? Lưu ý các bước xóa không thể hoàn tác", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                dgvList.Rows.Remove(dgvList.CurrentRow);
            }
        }
        private bool check()
        {
            bool ok = true;
            for(int i = 0; i < dgvList.Rows.Count - 1; i++)
            {
                if (dgvList.Rows[i].Cells[0].Value.ToString() == "")
                {
                    dgvList.Rows[i].Cells[0].Style.BackColor = Color.OrangeRed;
                    ok = false;
                }
                if (dgvList.Rows[i].Cells[1].Value.ToString() == "")
                {
                    dgvList.Rows[i].Cells[1].Style.BackColor = Color.OrangeRed;
                    ok = false;
                }
                if (dgvList.Rows[i].Cells[6].Value.ToString() == "")
                {
                    dgvList.Rows[i].Cells[6].Style.BackColor = Color.OrangeRed;
                    ok = false;
                }
            }
            return ok;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                MessageBox.Show("Không được để trống ô màu đỏ!", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
            string sql = "Delete from GiaoVien ";
            if (!database.DataChange(sql))
            {
                MessageBox.Show("Cập nhật không thành công!");
                return;
            }
            sql = "Delete from TaiKhoan ";
            if (!database.DataChange(sql))
            {
                MessageBox.Show("Cập nhật không thành công!");
                return;
            }

            for (int j = 0; j < dgvList.Rows.Count - 1; j++)
            {
                sql = "Insert into GiaoVien values(";
                for (int i = 0; i < 5; i++)
                {
                    if (dgvList.Columns[i].HeaderText == "Môn Học" && dgvList.Rows[j].Cells[i].Value.ToString() != "")
                    {
                        sql += "N'" + database.DataReader("Select MaMon from MonHoc where TenMon = N'" + dgvList.Rows[j].Cells[i].Value + "'").Rows[0]["MaMon"].ToString() + "', ";
                    }                        
                    else sql += "N'" + dgvList.Rows[j].Cells[i].Value.ToString() + "', ";
                }
                if (dgvList.Rows[j].Cells[5].Value.ToString() != "")
                    sql += "N'" + database.DataReader("Select MaLop from Lop where TenLop = N'" + dgvList.Rows[j].Cells[5].Value + "'").Rows[0]["MaLop"].ToString() + "', ";
                else sql += "N'',";
                sql += "N'" + database.DataReader("Select MaCV from ChucVu where TenCV = N'" + dgvList.Rows[j].Cells[6].Value + "'").Rows[0]["MaCV"].ToString() + "')";
                if (!database.DataChange(sql))
                {
                    MessageBox.Show("Cập nhật không thành công");
                    return;
                }                
                sql = "Insert into TaiKhoan values(N'" + dgvList.Rows[j].Cells[7].Value.ToString() + "', N'" + dgvList.Rows[j].Cells[8].Value.ToString() + "', N'" + dgvList.Rows[j].Cells[0].Value.ToString() + "')";
                if (!database.DataChange(sql))
                {
                    MessageBox.Show("Cập nhật không thành công");
                    return;
                }
            }
            MessageBox.Show("Cập nhật thành công!");


        }

        private void btnUnTick_Click(object sender, EventArgs e)
        {
            delString.Remove(dgvList.CurrentRow.Cells[0].Value.ToString());
            dgvList.CurrentRow.DefaultCellStyle.BackColor = Color.White;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvList.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnTick.Enabled = true;
            }
            else
            {
                btnTick.Enabled = false;
            }
        }
    }
}
