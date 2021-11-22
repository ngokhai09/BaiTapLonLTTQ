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
            
            


            sql = "select * from HS where TenLop " + check(cbKhoi.Text, cbLop.Text);
            data = database.DataReader(sql);
            if(data.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
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
                btnDel.Enabled = true;
            }
            else
            {
                btnDel.Enabled = false;
            }
                     
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = @"D:\Year_3\Lập trinh trực quan\Doc\Dữ liệu";
            fdlg.FileName = "";
            fdlg.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                String name = "Items";
                String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                fdlg.FileName.ToString() +
                                ";Extended Properties='Excel 8.0;HDR=YES;';";

                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgvHS.DataSource = data;
            }
        }
    }
}
