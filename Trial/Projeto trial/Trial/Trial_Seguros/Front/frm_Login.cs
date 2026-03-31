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
using Trial_Seguros.Front;
using Trial_Seguros.Model;
using System.Runtime.InteropServices;

namespace Trial_Seguros
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txbUser.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Controls controls = new Controls();
            controls.acess(txbUser.Text, txbPassword.Text);
            if (controls.error_msg.Equals(""))
            {
                if (controls.canAcess)
                {
                    //MessageBox.Show("Bem vindo " + txbUser.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                    frm_Main2 main = new frm_Main2();
                    main.User = txbUser.Text;
                    main.Show();
                }
                else
                {
                    labelError.Text = "Usuário ou senha não encontrados.";
                    //MessageBox.Show("Usuário ou senha não encontrados.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txbUser.Clear();
                    //txbPassword.Clear();
                    //txbUser.Focus();
                }
            }
            else
            {
                MessageBox.Show(controls.error_msg);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbUser_Enter(object sender, EventArgs e)
        {
            if (txbUser.Text == "USUÁRIO")
            {
                txbUser.Text = "";
            }
        }

        private void txbUser_Leave(object sender, EventArgs e)
        {
            if (txbUser.Text=="")
            {
                txbUser.Text = "USUÁRIO";
            }
        }

        private void txbPassword_Enter(object sender, EventArgs e)
        {
            if (txbPassword.Text=="SENHA")
            {
                txbPassword.Text = "";
                txbPassword.UseSystemPasswordChar = true;
            }
        }

        private void txbPassword_Leave(object sender, EventArgs e)
        {
            if (txbPassword.Text=="")
            {
                txbPassword.Text = "SENHA";
                txbPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnEnter_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void frm_login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEnter_Click(sender, e);
        }
    }
}
