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
                dateTimePickerCondutorNasc.Enabled = false;
                txbCondutorNome.Text = txbNome.Text;
                tbxCondutorCPF.Text = txbCPFCNPJ.Text;
                dateTimePickerCondutorNasc.Value = dateTimePickerNasc.Value;
            }
            else
            {
                txbCondutorNome.Enabled = true;
                tbxCondutorCPF.Enabled = true;
                dateTimePickerCondutorNasc.Enabled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                consult.Insert_Clients(txbNome.Text,
                                   txbCPFCNPJ.Text,
                                   dateTimePickerNasc.Value.Date,
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
                                   DateTime.Now.Date,
                                   txbCondutorNome.Text,
                                   tbxCondutorCPF.Text,
                                   dateTimePickerCondutorNasc.Value.Date,
                                   "",
                                   tbxObs.Text);
                labelSucess.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nao foi possivel salvar o cliente." + ex);
            }
            
        }
    }
}
