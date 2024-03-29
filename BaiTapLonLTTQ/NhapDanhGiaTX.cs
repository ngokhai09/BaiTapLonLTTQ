﻿using System;
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
    public partial class NhapDanhGiaTX : Form
    {
        DatabaseProcess database = new DatabaseProcess();
        ExcelProcess excel = new ExcelProcess();
        User user;
        public NhapDanhGiaTX(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void NhapDanhGiaTX_Load(object sender, EventArgs e)
        {
            if (user.Username == "")
            {
                Visible = false;
                Login login = new Login();
                login.Show();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            }
            if (!cbMon.Items.Contains(user.Subject)) cbMon.Items.Add(user.Subject);

            sql = "select MaHS, TenHS, TenLop, TenMon, MucDoDanhGia, NoiDungDanhGia from DG where TenLop " + check(cbKhoi.Text, cbLop.Text, cbMon.Text);
            data = database.DataReader(sql);
            dgvTX.DataSource = data;
            dgvTX.Columns[0].HeaderText = "Mã Học Sinh";
            dgvTX.Columns[1].HeaderText = "Tên Học Sinh";
            dgvTX.Columns[2].HeaderText = "Tên Lớp";
            dgvTX.Columns[3].HeaderText = "Tên Môn";
            dgvTX.Columns[4].HeaderText = "Mức độ hoàn thành";
            dgvTX.Columns[5].HeaderText = "Nội dung";
            if (data.Rows.Count > 0) btnUpdate.Enabled = true;
            else btnUpdate.Enabled = false;

        }

        private void dgvDK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTX.CurrentRow.Cells[0].Value.ToString() != "")
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
            NhapDanhGiaTX_Load(sender, e);
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhapDanhGiaTX_Load(sender, e);
        }

        private void cbMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhapDanhGiaTX_Load(sender, e);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            dgvTX.DataSource = excel.readExcel("select MaHS, HoTen, TenMon, NhanXetNangLuc, NhanXetPhamChat from[Sheet4$]");
            //excel.writeExcel(dgvHS);
            btnXuat.Enabled = true;
            btnUpdate.Enabled = true;
        }
    }
}
