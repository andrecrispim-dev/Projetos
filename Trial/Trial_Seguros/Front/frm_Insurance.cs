using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trial_Seguros.DAL;

namespace Trial_Seguros.Front
{
    public partial class frm_Insurance : Form
    {
        Consults consult = new Consults();
        public frm_Insurance()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbNome_Seguradora_Enter(object sender, EventArgs e)
        {
            if (txbNome_Seguradora.Text == "Nome da Seguradora")
            {
                txbNome_Seguradora.Text = "";
            }
            if (label8.Visible == true)
            {
                label8.Visible = false;
            }
        }

        private void txbNome_Seguradora_Leave(object sender, EventArgs e)
        {
            if (txbNome_Seguradora.Text == "")
            {
                txbNome_Seguradora.Text = "Nome da Seguradora";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            consult.Insert_Insurance(txbNome_Seguradora.Text);
            label8.Visible = true;
        }

        private void frm_Insurance_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
