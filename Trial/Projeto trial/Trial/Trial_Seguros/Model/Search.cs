using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trial_Seguros.DAL;
using Trial_Seguros.Front;

namespace Trial_Seguros.Model
{
    public class Search
    {
        private Consults consult = new Consults();

        public DataTable Showresults()
        {
            DataTable results = new DataTable();
            results = consult.Show();

            return results;
        }

        public void InsertClients(String nome, String cpfCnpj, String dataNasc, String logradouro, String bairro, String cidade, String estado, String cep, String email, String seguradora,
                                   String veiculo, String anoveiculo, String placa, String chassi, String renavam, String vigencia, String vencimento, String condutorNome, String condutorCpf,
                                   String condutorDataNasc, String apolice, String obs, String tipo, String princ_cond)
        {
            consult.Insert_Clients( nome,  cpfCnpj, dataNasc,  logradouro,  bairro,  cidade,  estado,  cep,  email,  seguradora,
                                    veiculo,  anoveiculo,  placa,  chassi,  renavam,  Convert.ToInt32(vigencia),  vencimento,  condutorNome,  condutorCpf,
                                    condutorDataNasc,  apolice,  obs, Convert.ToBoolean(tipo), Convert.ToBoolean(princ_cond));
        }

        public void EditClients(String nome, String cpfCnpj, String dataNasc, String logradouro, String bairro, String cidade, String estado, String cep, String email, String seguradora,
                                String veiculo, String anoveiculo, String placa, String chassi, String renavam, String vigencia, String vencimento, String condutorNome, String condutorCpf,
                                String condutorDataNasc, String apolice, String obs, String id, String tipo, String princ_cond)
        {
            consult.Edit_Clients(nome, cpfCnpj, dataNasc, logradouro, bairro, cidade, estado, cep, email, seguradora,
                                    veiculo, anoveiculo, placa, chassi, renavam, Convert.ToInt32(vigencia), vencimento, condutorNome, condutorCpf,
                                    condutorDataNasc, apolice, obs, Convert.ToInt32(id), Convert.ToBoolean(tipo), Convert.ToBoolean(princ_cond));
        }

        public void InsertInsurance(String seg_nome)
        {
            consult.Insert_Insurance(seg_nome);
        }

        public void InsertUser(String user, String password)
        {
            consult.Insert_User(user, password);
        }

        public void DeleteClients(int id)
        {
            consult.Delete_Clients(id);
        }
    }
}
