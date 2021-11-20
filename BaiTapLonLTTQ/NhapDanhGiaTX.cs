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
    public partial class NhapDanhGiaTX : Form
    {
        User user;
        public NhapDanhGiaTX(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void NhapDanhGiaTX_Load(object sender, EventArgs e)
        {
            /*if (user.Username == "")
            {
                Visible = false;
                Application.Run(new Login());
            }*/
        }
    }
}
