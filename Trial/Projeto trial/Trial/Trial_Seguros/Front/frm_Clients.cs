using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trial_Seguros.DAL;

namespace Trial_Seguros.Front
{
    public partial class frm_Clients : Form
    {
        Consults consult = new Consults();
        public int id { get; set; }

        private Conection conexao = new Conection();
        SqlCommand command = new SqlCommand();
        public bool edit = false;

        Consults Consults = new Consults();
        public frm_Clients()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            edit = true;
            rbFisica.Enabled = true;
            rbJuridica.Enabled = true;
            txbNome.Enabled = true;
            txbCPFCNPJ.Enabled = true;
            txbDataNasc.Enabled = true;
            txbLogradouro.Enabled = true;
            txbBairro.Enabled = true;
            txbCidade.Enabled = true;
            cbxUF.Enabled = true;
            txbCEP.Enabled = true;
            txbEmail.Enabled = true;
            cbxSeguradora.Enabled = true;
            txbVeiculo.Enabled = true;
            txbPlaca.Enabled = true;
            tbxChassi.Enabled = true;
            tbxRenavam.Enabled = true;
            cbxAnoVeiculo.Enabled = true;
            cbxVigencia.Enabled = true;
            chkPrincipalCondutor.Enabled = true;
            txbCondutorNome.Enabled = true;
            tbxCondutorCPF.Enabled = true;
            txbDataNascCond.Enabled = true;
            tbxObs.Enabled = true;
            btnEdit.Visible = false;
            btnSalvar.Visible = true;
            if (cbxSeguradora.Items.Count<=0)
            {
                cbxSeguradora.DataSource = consult.cbxSeg();
                cbxSeguradora.ValueMember = "SEG_NOME";
                cbxSeguradora.DisplayMember = "SEG_NOME";
            }
            
        }
        string seguradora;
        private void frm_Clients_Load(object sender, EventArgs e)
        {
            
            command.Connection = conexao.connect();
            command.CommandText = "SELECT * FROM CLIENTS WHERE ID = " + id;

            SqlDataAdapter objAdp = new SqlDataAdapter(command);
            DataTable dtLista = new DataTable();
            objAdp.Fill(dtLista);

            txbNome.Text = dtLista.Rows[0]["NOME"].ToString();
            txbCPFCNPJ.Text = dtLista.Rows[0]["CPF_CNPJ"].ToString();
            txbDataNasc.Text = dtLista.Rows[0]["DATA_NASCIMENTO"].ToString();
            //dateTimePickerNasc.Value = dtLista.Rows[0]["DATA_NASCIMENTO"].ToString();
            txbLogradouro.Text = dtLista.Rows[0]["LOGRADOURO"].ToString();
            txbBairro.Text = dtLista.Rows[0]["BAIRRO"].ToString(); 
            txbCidade.Text = dtLista.Rows[0]["CIDADE"].ToString();
            cbxUF.Text = dtLista.Rows[0]["ESTADO"].ToString();
            txbCEP.Text = dtLista.Rows[0]["CEP"].ToString();
            txbEmail.Text = dtLista.Rows[0]["EMAIL"].ToString();
            cbxSeguradora.Text = dtLista.Rows[0]["SEGURADORA"].ToString();
            seguradora = cbxSeguradora.Text;
            txbVeiculo.Text = dtLista.Rows[0]["VEICULO"].ToString();
            txbPlaca.Text = dtLista.Rows[0]["PLACA"].ToString();
            tbxChassi.Text = dtLista.Rows[0]["CHASSI"].ToString();
            tbxRenavam.Text = dtLista.Rows[0]["RENAVAM"].ToString();
            cbxAnoVeiculo.Text = dtLista.Rows[0]["ANO_VEICULO"].ToString();
            cbxVigencia.Text = dtLista.Rows[0]["VIGENCIA"].ToString();
            txbCondutorNome.Text = dtLista.Rows[0]["PRINC_CONDUTOR_NOME"].ToString();
            tbxCondutorCPF.Text = dtLista.Rows[0]["PRINC_CONDUTOR_CPF"].ToString();
            txbDataNascCond.Text = dtLista.Rows[0]["PRINC_CONDUTOR_NASCIMENTO"].ToString();
            //dateTimePickerCondutorNasc.Value = Convert.ToDateTime(dtLista.Rows[0]["PRINC_CONDUTOR_NASCIMENTO"].ToString());
            tbxObs.Text = dtLista.Rows[0]["OBS"].ToString();
            rbFisica.Checked = Convert.ToBoolean(dtLista.Rows[0]["TIPO"].ToString());
            rbJuridica.Checked = Convert.ToBoolean(dtLista.Rows[0]["TIPO"].ToString());
            chkPrincipalCondutor.Checked = Convert.ToBoolean(dtLista.Rows[0]["PRINC_CONDUTOR"].ToString());
            label2.Focus();
        }
        bool tipo, princ_cond = false;
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cbxSeguradora.Text == "")
            {
                cbxSeguradora.Text = seguradora;
            }
            if (seguradora != cbxSeguradora.Text)
            {
                seguradora = cbxSeguradora.Text;
            }
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
            if (edit == true)
            {
                try
                {
                    Consults.Edit_Clients(txbNome.Text,
                                       txbCPFCNPJ.Text,
                                       txbDataNasc.Text,
                                       txbLogradouro.Text,
                                       txbBairro.Text,
                                       txbCidade.Text,
                                       cbxUF.Text,
                                       txbCEP.Text,
                                       txbEmail.Text,
                                       seguradora,
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
                                       id,
                                       tipo,
                                       princ_cond);
                    labelSucess.Visible = true;
                    edit = false;
                    rbFisica.Enabled = false;
                    rbJuridica.Enabled = false;
                    txbNome.Enabled = false;
                    txbCPFCNPJ.Enabled = false;
                    txbDataNasc.Enabled = false;
                    txbLogradouro.Enabled = false;
                    txbBairro.Enabled = false;
                    txbCidade.Enabled = false;
                    cbxUF.Enabled = false;
                    txbCEP.Enabled = false;
                    txbEmail.Enabled = false;
                    cbxSeguradora.Enabled = false;
                    txbVeiculo.Enabled = false;
                    txbPlaca.Enabled = false;
                    tbxChassi.Enabled = false;
                    tbxRenavam.Enabled = false;
                    cbxAnoVeiculo.Enabled = false;
                    cbxVigencia.Enabled = false;
                    chkPrincipalCondutor.Enabled = false;
                    txbCondutorNome.Enabled = false;
                    tbxCondutorCPF.Enabled = false;
                    txbDataNascCond.Enabled = false;
                    tbxObs.Enabled = false;
                    btnEdit.Visible = true;
                    btnSalvar.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao foi possivel editar o cliente." + ex);
                }
            }
        }

        private void txbNome_Enter(object sender, EventArgs e)
        {
            if (labelSucess.Visible == true)
            {
                labelSucess.Visible = false;
            }
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
        }

        private void cbxSeguradora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSeguradora.Text != "")
            {
                txbVeiculo.Focus();
            }
        }

        private void txbDataNasc_Enter(object sender, EventArgs e)
        {

        }
    }
}
