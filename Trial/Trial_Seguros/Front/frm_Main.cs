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
using System.Runtime.InteropServices;
using Trial_Seguros.DAL;
using Trial_Seguros.Model;
using System.Data.Entity;

namespace Trial_Seguros.Front
{
    public partial class frm_Main : Form
    {
        Consults consult = new Consults();
        public frm_Main main1 { get; set; }

        Search searchs = new Search();
        SqlCommand objCommand = null;
        SqlConnection objConect = null;
        public frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void ShowGrid()
        {
            dgPrincipal.DataSource = searchs.Showresults();
        }

        public void ListGrid(String querry)
        {
            String strSQL = querry;
            SqlCommand sqlcmd = new SqlCommand();
            Conection conection = new Conection();
            sqlcmd.CommandText = strSQL;

            try
            {
                sqlcmd.Connection = conection.connect();
                SqlDataAdapter objAdp = new SqlDataAdapter(sqlcmd);
                DataTable dtLista = new DataTable();
                objAdp.Fill(dtLista);
                dgPrincipal.DataSource = dtLista;
                //txbSearch.Text = dtLista.Columns[0].ColumnName.ToString();
                //txbSearch.Text = dtLista.Rows[0]["ID"].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Erro de Banco de Dados.");
            }


        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            cbxFilter.SelectedIndex = 0;
            //ListGrid("SELECT * FROM CLIENTS");
            ShowGrid();
        }


        private void frm_Main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {        
            if (cbxFilter.SelectedIndex == 0)
            {
                ListGrid(String.Format("SELECT * FROM CLIENTS WHERE NOME LIKE '%{0}%'", txbSearch.Text));
            }

            if (cbxFilter.SelectedIndex == 1)
            {
                ListGrid(String.Format("SELECT * FROM CLIENTS WHERE CPF_CNPJ LIKE '%{0}%'", txbSearch.Text));
            }

            if (cbxFilter.SelectedIndex == 2)
            {
                ListGrid(String.Format("SELECT * FROM CLIENTS WHERE SEGURADORA LIKE '%{0}%'", txbSearch.Text));
            }
        }

        public static string nome, cpfcnpj, logradouro, cidade, uf, cep, email, seuradora, veiculo, placa, ano, chassi, renavam, vigencia, condnome, condcpf, obs;

        private void dgPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    delete();
                    break;
            }
        }

        public void dgPrincipal_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm_Clients clients = new frm_Clients();
            clients.id = Convert.ToInt32(dgPrincipal.CurrentRow.Cells["ID"].Value);
            clients.Show();
        }
        
        public void delete()
        {
            if (MessageBox.Show("Deseja realmente excluir esse cliente?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgPrincipal.SelectedRows.Count > 0)
                {
                    consult.Delete_Clients(Convert.ToInt32(dgPrincipal.CurrentRow.Cells["ID"].Value));
                }
            }
        }

    }
}
