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
    public partial class frm_Users : Form
    {
        Consults consult = new Consults();
        public frm_Users()
        {
            InitializeComponent();
        }

        private void frm_Users_Load(object sender, EventArgs e)
        {

        }

        private void txbNomeUsuario_Enter(object sender, EventArgs e)
        {
            if (txbNomeUsuario.Text == "Nome do Usuário")
            {
                txbNomeUsuario.Text = "";
            }
            if (label1.Visible == true)
            {
                label1.Visible = false;
            }
            if (label8.Visible == true)
            {
                label8.Visible = false;
            }
        }

        private void txbNomeUsuario_Leave(object sender, EventArgs e)
        {
            if (txbNomeUsuario.Text == "")
            {
                txbNomeUsuario.Text = "Nome do Usuário";
            }
        }

        private void txbSenha_Enter(object sender, EventArgs e)
        {
            if (txbSenha.Text == "Senha")
            {
                txbSenha.Text = "";
                txbSenha.UseSystemPasswordChar = true;
            }
        }

        private void txbSenha_Leave(object sender, EventArgs e)
        {
            if (txbSenha.Text == "")
            {
                txbSenha.Text = "Senha";
                txbSenha.UseSystemPasswordChar = false;
            }
        }

        private void txbConfSenha_Enter(object sender, EventArgs e)
        {
            if (txbConfSenha.Text == "Confirmar Senha")
            {
                txbConfSenha.Text = "";
                txbConfSenha.UseSystemPasswordChar = true;
            }
        }

        private void txbConfSenha_Leave(object sender, EventArgs e)
        {
            if (txbConfSenha.Text == "")
            {
                txbConfSenha.Text = "Confirmar Senha";
                txbConfSenha.UseSystemPasswordChar = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txbSenha.Text == txbConfSenha.Text)
            {
                consult.Insert_User(txbNomeUsuario.Text, txbSenha.Text);
                label8.Visible = true;
                label1.Visible = false;
                timer1.Enabled = true;
            }
            else
            {
                label1.Visible = true;
                txbSenha.Clear();
                txbConfSenha.Clear();
                txbConfSenha.Focus();
                txbSenha.Focus();
            }
            
        }

        public void clearForm()
        {
            txbNomeUsuario.Clear();
            txbNomeUsuario.Focus();
            txbSenha.Clear();
            txbSenha.Focus();
            txbConfSenha.Clear();
            txbConfSenha.Focus();
            label2.Focus();
        }

        private void frm_Users_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    clearForm();
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clearForm();
            timer1.Enabled = false;
        }

        private void frm_Users_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
