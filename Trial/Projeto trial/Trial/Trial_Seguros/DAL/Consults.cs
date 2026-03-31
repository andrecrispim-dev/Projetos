using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace Trial_Seguros.DAL
{
    public class Consults
    {
        private Conection conexao = new Conection();

        SqlDataReader read, read2;
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        SqlCommand command = new SqlCommand();

        public DataTable Show()
        {
            command.Connection = conexao.connect();
            command.CommandText = "SELECT * FROM CLIENTS";
            read = command.ExecuteReader();
            table.Load(read);
            conexao.desconnect();

            return table;
        }

        public void Insert_Clients(String nome, String cpfCnpj, String dataNasc, String logradouro, String bairro, String cidade, String estado, String cep, String email, String seguradora, 
                                   String veiculo, String anoveiculo, String placa, String chassi, String renavam, int vigencia, String vencimento, String condutorNome, String condutorCpf,
                                   String condutorDataNasc, String apolice, String obs, bool tipo, bool princ_cond)
        {
            command.Connection = conexao.connect();
            command.CommandText = "INSERT INTO CLIENTS VALUES ('"+nome+ "', '" + cpfCnpj + "', '" + dataNasc + "', '" + logradouro + "', '" + bairro + "', '" + cidade + "', '" + estado + "', '" + cep + "', '" + email + "', '" + seguradora + "', '" + veiculo + "', '" + anoveiculo + "', '" + placa + "', '" + chassi + "', '" + renavam + "', '" + vigencia + "', '" + vencimento + "', '" + condutorNome + "', '" + condutorCpf + "', '" + condutorDataNasc + "', '" + apolice + "', '" + obs + "', '" + tipo + "', '" + princ_cond + "')";
            command.ExecuteNonQuery();
        }

        public void Edit_Clients(String nome, String cpfCnpj, String dataNasc, String logradouro, String bairro, String cidade, String estado, String cep, String email, String seguradora,
                                   String veiculo, String anoveiculo, String placa, String chassi, String renavam, int vigencia, String vencimento, String condutorNome, String condutorCpf,
                                   String condutorDataNasc, String apolice, String obs, int id, bool tipo, bool princ_cond)
        {
            command.Connection = conexao.connect();
            command.CommandText = "UPDATE CLIENTS SET NOME = '" + nome + "', CPF_CNPJ = '" + cpfCnpj + "', DATA_NASCIMENTO = '" + dataNasc + "', LOGRADOURO =  '" + logradouro + "', BAIRRO = '" + bairro + "', CIDADE = '" + cidade + "', ESTADO = '" + estado + "', CEP =  '" + cep + "', EMAIL = '" + email + "', SEGURADORA = '" + seguradora + "', VEICULO =  '" + veiculo + "', ANO_VEICULO = '" + anoveiculo + "', PLACA = '" + placa + "', CHASSI = '" + chassi + "', RENAVAM = '" + renavam + "', VIGENCIA = '" + vigencia + "', DATA_VENCIMENTO = '" + vencimento + "', PRINC_CONDUTOR_NOME =  '" + condutorNome + "', PRINC_CONDUTOR_CPF =  '" + condutorCpf + "', PRINC_CONDUTOR_NASCIMENTO = '" + condutorDataNasc + "', NUMERO_APOLICE = '" + apolice + "', OBS = '" + obs + "', TIPO = '" + tipo + "', PRINC_CONDUTOR = '" + princ_cond + "' WHERE ID='" + id + "'";
            command.ExecuteNonQuery();
        }

        public void Insert_Insurance(String seg_nome)
        {
            command.Connection = conexao.connect();
            command.CommandText = "INSERT INTO SEGURADORAS VALUES ('" + seg_nome + "')";
            command.ExecuteNonQuery();
        }

        public void Insert_User(String user, String password)
        {
            command.Connection = conexao.connect();
            command.CommandText = "INSERT INTO USERS VALUES ('" + user + "','" + password + "')";
            command.ExecuteNonQuery();
        }

        public void Delete_Clients(int id)
        {
            command.Connection = conexao.connect();
            command.CommandText = "DELETE FROM CLIENTS WHERE ID ='" + id + "'";
            command.ExecuteNonQuery();
        }

        public DataTable cbxSeg()
        {
            command.Connection = conexao.connect();
            command.CommandText = "SELECT * FROM SEGURADORAS ORDER BY SEG_NOME";
            read2 = command.ExecuteReader();
            table2.Load(read2);
            DataRow row = table2.NewRow();
            row["SEG_NOME"] = "";
            table2.Rows.InsertAt(row, 0);

            return table2;
        }
    }
}
