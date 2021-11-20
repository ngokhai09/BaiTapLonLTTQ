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

        private void NhapSK_Load(object sender, EventArgs e)
        {
            if (user.Username == "")
            {
                Visible = false;
                Login login = new Login();
                login.Show();
            }
            string sql = "select * from SK where";
            DataTable data = database.DataReader(sql);

            dgvHealth.DataSource = data;
            dgvHealth.Columns[0].HeaderText = "Mã Học Sinh";
            dgvHealth.Columns[1].HeaderText = "Tên Học Sinh";
            dgvHealth.Columns[2].HeaderText = "Tên Lớp";
            dgvHealth.Columns[3].HeaderText = "Ngày Sinh";
            dgvHealth.Columns[4].HeaderText = "Giới tính";
            dgvHealth.Columns[5].HeaderText = "Địa chỉ";
            dgvHealth.Columns[6].HeaderText = "Họ Tên Bố";
            dgvHealth.Columns[7].HeaderText = "Nghề nghiệp bố";
            dgvHealth.Columns[8].HeaderText = "Số điện thoại bố";
            dgvHealth.Columns[9].HeaderText = "Họ tên mẹ";
            dgvHealth.Columns[10].HeaderText = "Nghề nghiệp mẹ";
            dgvHealth.Columns[11].HeaderText = "Số điện thoại mẹ";


        }
    }
}
