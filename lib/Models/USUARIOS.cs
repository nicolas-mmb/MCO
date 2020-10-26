using MAID_COFFEE_OCIDENTAL.lib.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID_COFFEE_OCIDENTAL.lib.Models
{
    class USUARIOS
    {
        public string id { get; set; }
        public string cpf { get; set; }
        public string nomes { get; set; }
        public string senha { get; set; }
        public bool IsADM { get; set; }
        public bool IsAttendant { get; set; }
        public bool BiologicalSex { get; set; }


        public USUARIOS(string cpf, string senha, bool isADM, bool IsAttendant, string nome, bool biosex)
        {

            this.cpf = cpf;
            this.senha = senha;
            this.IsADM = isADM;
            this.IsAttendant = IsAttendant;
            this.nomes = nome;
            this.BiologicalSex = biosex;


        }


        private CONEXAO CNTN { get; set; }
        private SqlCommand SqlCMD { get; set; }
        public USUARIOS()
        {
            CNTN = new CONEXAO();
            SqlCMD = new SqlCommand();
        }

        public bool ChecarLogin(string CPF, string SENHA)
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "SELECT CPFX, PASSWORDX FROM tb_LOGIN WHERE CPFX = @CPF and PASSWORDX = @SENHA";

            SqlCMD.Parameters.AddWithValue("@CPF", CPF);
            SqlCMD.Parameters.AddWithValue("@SENHA", SENHA);
            
            try
            {
                SqlDataReader reader = SqlCMD.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }


        public bool ADM(string CPF)
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "SELECT CPFX FROM tb_LOGIN WHERE CPFX = @CPF and IsADM = '0'";
            SqlCMD.Parameters.AddWithValue("@CPF", CPF);
            try
            {
                SqlDataReader reader = SqlCMD.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }



        public bool AddLogin(string CPF, string SENHA, bool isADM, bool IsAttendant, string nome, bool biosex)
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "INSERT INTO tb_LOGIN VALUES (@CPF,@IsADM,@IsAttendant,@Names,@BiologicalSex,@PASSWORDX)";

            //string adm = "0";
            //string att = "1";
            //SqlCMD.Parameters.AddWithValue("@", );

            SqlCMD.Parameters.AddWithValue("@CPF"           , CPF);
            SqlCMD.Parameters.AddWithValue("@PASSWORDX"     , SENHA);
            SqlCMD.Parameters.AddWithValue("@IsADM"         , isADM);
            SqlCMD.Parameters.AddWithValue("@IsAttendant"   , IsAttendant);
            SqlCMD.Parameters.AddWithValue("@Names"         , nome);
            SqlCMD.Parameters.AddWithValue("@BiologicalSex" , biosex);

            if (SqlCMD.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("ADDED ON DB");
                return true;
            }
            return false;
        }



        public bool AtualizarLogin(string CPF, string SENHA, bool isADM, bool IsAttendant, string nome, bool biosex)
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "UPDATE tb_LOGIN SET CPFX = @CPF, IsADM = @IsADM, IsAttendant = @IsAttendant, Names = @Names, BiologicalSex = @BiologicalSex, PASSWORDX = @PASSWORDX WHERE CPFX = @CPF";

            SqlCMD.Parameters.AddWithValue("@CPF", CPF);
            SqlCMD.Parameters.AddWithValue("@PASSWORDX", SENHA);
            SqlCMD.Parameters.AddWithValue("@IsADM", isADM);
            SqlCMD.Parameters.AddWithValue("@IsAttendant", IsAttendant);
            SqlCMD.Parameters.AddWithValue("@Names", nome);
            SqlCMD.Parameters.AddWithValue("@BiologicalSex", biosex);

            if (SqlCMD.ExecuteNonQuery() == 1)
            {
                return true;
            }
            return false;
        }


        public bool AtualizarLoginSemSenha(string CPF, bool isADM, bool IsAttendant, string nome, bool biosex)
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "UPDATE tb_LOGIN SET CPFX = @CPF, IsADM = @IsADM, IsAttendant = @IsAttendant, Names = @Names, BiologicalSex = @BiologicalSex WHERE CPFX = @CPF";

            SqlCMD.Parameters.AddWithValue("@CPF", CPF);
            SqlCMD.Parameters.AddWithValue("@IsADM", isADM);
            SqlCMD.Parameters.AddWithValue("@IsAttendant", IsAttendant);
            SqlCMD.Parameters.AddWithValue("@Names", nome);
            SqlCMD.Parameters.AddWithValue("@BiologicalSex", biosex);

            if (SqlCMD.ExecuteNonQuery() == 1)
            {
                return true;
            }
            return false;
        }


        public bool ExcluirUsuario(string CPF)
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = @"DELETE FROM tb_LOGIN WHERE CPFX = @CPF";

            SqlCMD.Parameters.AddWithValue("@CPF", CPF);
            SqlDataReader reader = SqlCMD.ExecuteReader();

            return false;
        }


        public List<USUARIOS> ListarUsuarios()
        {
            List<USUARIOS> itens = new List<USUARIOS>();
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "SELECT * FROM tb_LOGIN";
            SqlDataReader reader = SqlCMD.ExecuteReader();


            while (reader.Read())
            {
                USUARIOS USERS = new USUARIOS(
                    Convert.ToString(reader["CPFX"]),
                    Convert.ToString(reader["PASSWORDX"]),
                    Convert.ToBoolean(reader["isADM"]),
                    Convert.ToBoolean(reader["IsAttendant"]),
                    Convert.ToString(reader["Names"]),
                    Convert.ToBoolean(reader["BiologicalSex"]));
                itens.Add(USERS);
            }
            CNTN.Disconnect();
            return itens;
        }


        public List<USUARIOS> ListarPesquisaString(string id)
        {
            List<USUARIOS> itens = new List<USUARIOS>();
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "SELECT * FROM tb_LOGIN WHERE CPFX LIKE @ID";
            string PDT_format = "%" + id + "%";
            SqlCMD.Parameters.AddWithValue("@ID", PDT_format.Trim());
            SqlDataReader reader = SqlCMD.ExecuteReader();


            while (reader.Read())
            {
                USUARIOS USERS = new USUARIOS(
                    Convert.ToString(reader["CPFX"]),
                    Convert.ToString(reader["PASSWORDX"]),
                    Convert.ToBoolean(reader["isADM"]),
                    Convert.ToBoolean(reader["IsAttendant"]),
                    Convert.ToString(reader["Names"]),
                    Convert.ToBoolean(reader["BiologicalSex"]));


                /*Console.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", MDPS.PDT_ID, MDPS.PDT_NOME_PRODUTO, MDPS.PDT_VALOR_PRODUTO, MDPS.PDT_VALIDADE_PRODUTO, MDPS.PDT_QUANTIDADE_PRODUTO, MDPS.PDT_USER_CHANGE));*/
                itens.Add(USERS);
            }
            CNTN.Disconnect();
            return itens;
        }
    }
}
