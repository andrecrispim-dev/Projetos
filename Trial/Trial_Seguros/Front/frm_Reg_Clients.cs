using Microsoft.SqlServer.Server;
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
using Trial_Seguros.Model;

namespace Trial_Seguros.Front
{
    public partial class frm_Reg_Clients : Form
    {
        Consults consult = new Consults();
        public frm_Reg_Clients()
        {
            InitializeComponent();
        }

        private void txbNome_Enter(object sender, EventArgs e)
        {
            if (txbNome.Text == "Nome")
            {
                txbNome.Text = "";
            }
        }

        private void txbNome_Leave(object sender, EventArgs e)
        {
            if (txbNome.Text == "")
            {
                txbNome.Text = "Nome";
            }
        }

        private void txbCPFCNPJ_Enter(object sender, EventArgs e)
        {
            if (txbCPFCNPJ.Text == "CPF / CNPJ")
            {
                txbCPFCNPJ.Text = "";
            }
        }

        private void txbCPFCNPJ_Leave(object sender, EventArgs e)
        {
            if (txbCPFCNPJ.Text == "")
            {
                txbCPFCNPJ.Text = "CPF / CNPJ";
            }
        }

        private void txbLogradouro_Enter(object sender, EventArgs e)
        {
            if (txbLogradouro.Text == "Logradouro")
            {
                txbLogradouro.Text = "";
            }
        }

        private void txbLogradouro_Leave(object sender, EventArgs e)
        {
            if (txbLogradouro.Text == "")
            {
                txbLogradouro.Text = "Logradouro";
            }
        }

        private void txbBairro_Enter(object sender, EventArgs e)
        {
            if (txbBairro.Text == "Bairro")
            {
                txbBairro.Text = "";
            }
        }

        private void txbBairro_Leave(object sender, EventArgs e)
        {
            if (txbBairro.Text == "")
            {
                txbBairro.Text = "Bairro";
            }
        }

        private void txbCidade_Enter(object sender, EventArgs e)
        {
            if (txbCidade.Text == "Cidade")
            {
                txbCidade.Text = "";
            }
        }

        private void txbCidade_Leave(object sender, EventArgs e)
        {
            if (txbCidade.Text == "")
            {
                txbCidade.Text = "Cidade";
            }
        }

        private void txbCEP_Leave(object sender, EventArgs e)
        {
            if (txbCEP.Text == "")
            {
                txbCEP.Text = "CEP";
            }
        }

        private void txbCEP_Enter(object sender, EventArgs e)
        {
            if (txbCEP.Text == "CEP")
            {
                txbCEP.Text = "";
            }
        }

        private void txbEmail_Enter(object sender, EventArgs e)
        {
            if (txbEmail.Text == "Email")
            {
                txbEmail.Text = "";
            }
        }

        private void txbEmail_Leave(object sender, EventArgs e)
        {
            if (txbEmail.Text == "")
            {
                txbEmail.Text = "Email";
            }
        }

        private void txbVeiculo_Enter(object sender, EventArgs e)
        {
            if (txbVeiculo.Text == "Veículo")
            {
                txbVeiculo.Text = "";
            }
        }

        private void txbVeiculo_Leave(object sender, EventArgs e)
        {
            if (txbVeiculo.Text == "")
            {
                txbVeiculo.Text = "Veículo";
            }
        }

        private void txbPlaca_Enter(object sender, EventArgs e)
        {
            if (txbPlaca.Text == "Placa")
            {
                txbPlaca.Text = "";
            }
        }

        private void txbPlaca_Leave(object sender, EventArgs e)
        {
            if (txbPlaca.Text == "")
            {
                txbPlaca.Text = "Placa";
            }
        }

        private void tbxChassi_Enter(object sender, EventArgs e)
        {
            if (tbxChassi.Text == "Chassi")
            {
                tbxChassi.Text = "";
            }
        }

        private void tbxChassi_Leave(object sender, EventArgs e)
        {
            if (tbxChassi.Text == "")
            {
                tbxChassi.Text = "Chassi";
            }
        }

        private void tbxRenavam_Enter(object sender, EventArgs e)
        {
            if (tbxRenavam.Text == "Renavam")
            {
                tbxRenavam.Text = "";
            }
        }

        private void tbxRenavam_Leave(object sender, EventArgs e)
        {
            if (tbxRenavam.Text == "")
            {
                tbxRenavam.Text = "Renavam";
            }
        }

        private void txbCondutorNome_Enter(object sender, EventArgs e)
        {
            if (txbCondutorNome.Text == "Nome do Condutor")
            {
                txbCondutorNome.Text = "";
            }
        }

        private void txbCondutorNome_Leave(object sender, EventArgs e)
        {
            if (txbCondutorNome.Text == "")
            {
                txbCondutorNome.Text = "Nome do Condutor";
            }
        }

        private void tbxCondutorCPF_Enter(object sender, EventArgs e)
        {
            if (tbxCondutorCPF.Text == "CPF do Condutor")
            {
                tbxCondutorCPF.Text = "";
            }
        }

        private void tbxCondutorCPF_Leave(object sender, EventArgs e)
        {
            if (tbxCondutorCPF.Text == "")
            {
                tbxCondutorCPF.Text = "CPF do Condutor";
            }
        }

        private void tbxObs_Enter(object sender, EventArgs e)
        {
            if (tbxObs.Text == "Obs")
            {
                tbxObs.Text = "";
            }
        }

        private void tbxObs_Leave(object sender, EventArgs e)
        {
            if (tbxObs.Text == "")
            {
                tbxObs.Text = "Obs";
            }
        }

        private void chkPrincipalCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrincipalCondutor.Checked)
            {
                txbCondutorNome.Enabled = false;
                tbxCondutorCPF.Enabled = false;
                txbDataNascCond.Enabled = false;
                txbCondutorNome.Text = txbNome.Text;
                tbxCondutorCPF.Text = txbCPFCNPJ.Text;
                txbDataNascCond.Text = txbDataNasc.Text;
            }
            else
            {
                txbCondutorNome.Enabled = true;
                tbxCondutorCPF.Enabled = true;
                txbDataNascCond.Enabled = true;
            }
        }
        bool tipo, princ_cond = false;
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (rbFisica.Checked == true)
            {
                tipo = false; //0 = Pessoa Fisica
            }
            if (rbJuridica.Checked == true)
            {
                tipo = true; //1 = Pessoa Jurídica
            }
            if (chkPrincipalCondutor.Checked == true)
            {
                princ_cond = true;
            }
            try
            {
                consult.Insert_Clients(txbNome.Text,
                                   txbCPFCNPJ.Text,
                                   txbDataNasc.Text,
                                   txbLogradouro.Text,
                                   txbBairro.Text,
                                   txbCidade.Text,
                                   cbxUF.Text,
                                   txbCEP.Text,
                                   txbEmail.Text,
                                   cbxSeguradora.Text,
                                   txbVeiculo.Text,
                                   cbxAnoVeiculo.Text,
                                   txbPlaca.Text,
                                   tbxChassi.Text,
                                   tbxRenavam.Text,
                                   Convert.ToInt32(cbxVigencia.Text),
                                   "",
                                   txbCondutorNome.Text,
                                   tbxCondutorCPF.Text,
                                   txbDataNascCond.Text,
                                   "",
                                   tbxObs.Text,
                                   tipo,
                                   princ_cond);
                labelSucess.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nao foi possivel salvar o cliente." + ex);
            }
            
        }

        public void clearForm()
        {
            txbNome.Clear();
            txbNome.Focus();
            txbCPFCNPJ.Clear();
            txbCPFCNPJ.Focus();
            txbLogradouro.Clear();
            txbLogradouro.Focus();
            txbBairro.Clear();
            txbBairro.Focus();
            txbCidade.Clear();
            txbCidade.Focus();
            txbCEP.Clear();
            txbCEP.Focus();
            txbEmail.Clear();
            txbEmail.Focus();
            txbVeiculo.Clear();
            txbVeiculo.Focus();
            txbPlaca.Clear();
            txbPlaca.Focus();
            tbxChassi.Clear();
            tbxChassi.Focus();
            tbxRenavam.Clear();
            tbxRenavam.Focus();
            txbCondutorNome.Clear();
            txbCondutorNome.Focus();
            tbxCondutorCPF.Clear();
            tbxCondutorCPF.Focus();
            tbxObs.Clear();
            tbxObs.Focus();
            label2.Focus();
            labelSucess.Visible = false;
            chkPrincipalCondutor.Checked = false;
        }

        private void frm_Reg_Clients_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    clearForm();
                    break;
            }
        }

        private void frm_Reg_Clients_Load(object sender, EventArgs e)
        {
            cbxSeguradora.DataSource = consult.cbxSeg();
            cbxSeguradora.ValueMember = "SEG_NOME";
            cbxSeguradora.DisplayMember = "SEG_NOME";
        }

        private void txbDataNasc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txbDataNasc.TextLength)
                {
                    case 0:
                        txbDataNasc.Text = "";
                        break;
                    case 2:
                        txbDataNasc.Text = txbDataNasc.Text + "/";
                        txbDataNasc.SelectionStart = 4;
                        break;
                    case 5:
                        txbDataNasc.Text = txbDataNasc.Text + "/";
                        txbDataNasc.SelectionStart = 9;
                        break;
                }
            }
        }

        private void txbDataNascCond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txbDataNascCond.TextLength)
                {
                    case 0:
                        txbDataNascCond.Text = "";
                        break;
                    case 2:
                        txbDataNascCond.Text = txbDataNasc.Text + "/";
                        txbDataNascCond.SelectionStart = 4;
                        break;
                    case 5:
                        txbDataNascCond.Text = txbDataNasc.Text + "/";
                        txbDataNascCond.SelectionStart = 9;
                        break;
                }
            }
        }

        private void txbCPFCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbFisica.Checked == true)
            {
                txbCPFCNPJ.MaxLength = 14;
                if (char.IsNumber(e.KeyChar) == true)
                {
                    switch (txbCPFCNPJ.TextLength)
                    {
                        case 0:
                            txbCPFCNPJ.Text = "";
                            break;
                        case 3:
                            txbCPFCNPJ.Text = txbCPFCNPJ.Text + ".";
                            txbCPFCNPJ.SelectionStart = 5;
                            break;
                        case 7:
                            txbCPFCNPJ.Text = txbCPFCNPJ.Text + ".";
                            txbCPFCNPJ.SelectionStart = 9;
                            break;
                        case 11:
                            txbCPFCNPJ.Text = txbCPFCNPJ.Text + "-";
                            txbCPFCNPJ.SelectionStart = 13;
                            break;
                    }
                }
            }
            if (rbJuridica.Checked == true)
            {
                txbCPFCNPJ.MaxLength = 18;
                if (char.IsNumber(e.KeyChar) == true)
                {
                    switch (txbCPFCNPJ.TextLength)
                    {
                        case 0:
                            txbCPFCNPJ.Text = "";
                            break;
                        case 2:
                            txbCPFCNPJ.Text = txbCPFCNPJ.Text + ".";
                            txbCPFCNPJ.SelectionStart = 4;
                            break;
                        case 6:
                            txbCPFCNPJ.Text = txbCPFCNPJ.Text + ".";
                            txbCPFCNPJ.SelectionStart = 8;
                            break;
                        case 10:
                            txbCPFCNPJ.Text = txbCPFCNPJ.Text + "/";
                            txbCPFCNPJ.SelectionStart = 12;
                            break;
                        case 15:
                            txbCPFCNPJ.Text = txbCPFCNPJ.Text + "-";
                            txbCPFCNPJ.SelectionStart = 17;
                            break;
                    }
                }
            }
        }

        private void txbDataNasc_Enter(object sender, EventArgs e)
        {
            if (txbDataNasc.Text == "Data de Nascimento")
            {
                txbDataNasc.Text = "";
            }
        }

        private void cbxSeguradora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSeguradora.Text != "")
            {
                txbVeiculo.Focus();
            }
        }

        private void txbDataNasc_Leave(object sender, EventArgs e)
        {
            if (txbDataNasc.Text == "")
            {
                txbDataNasc.Text = "Data de Nascimento";
            }
        }
    }
}
