using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trial_Seguros.Front
{
    public partial class frm_splash : Form
    {
        public frm_splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 15;
            if (panel1.Width >= 700)
            {
                timer1.Enabled = false;
                this.Visible = false;
                frm_login login = new frm_login();
                login.Show();
            }
        }
    }
}
