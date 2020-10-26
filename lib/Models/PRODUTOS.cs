    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAID_COFFEE_OCIDENTAL.lib.Models
{
    class PRODUTOS
    {
        public int PDT_ID { get; set; }
        public string PDT_NOME_PRODUTO { get; set; }
        public double PDT_VALOR_PRODUTO { get; set; }
        public DateTime PDT_VALIDADE_PRODUTO { get; set; }
        public int PDT_QUANTIDADE_PRODUTO { get; set; }
        public byte[] PDT_IMAGEM_PRODUTO { get; set; }
        public string PDT_USER_CHANGE { get; set; }


        public PRODUTOS(int id, string nome, double valor, DateTime validade, int quantidade, string user, byte[] imagem)
        {
            this.PDT_ID = id;
            this.PDT_NOME_PRODUTO = nome;
            this.PDT_VALOR_PRODUTO = valor;
            this.PDT_VALIDADE_PRODUTO = validade;
            this.PDT_QUANTIDADE_PRODUTO = quantidade;
            this.PDT_USER_CHANGE = user;
            this.PDT_IMAGEM_PRODUTO = imagem;
        }


        public PRODUTOS(int id, string nome, double valor, DateTime validade, int quantidade, string user)
        {
            this.PDT_ID = id;
            this.PDT_NOME_PRODUTO = nome;
            this.PDT_VALOR_PRODUTO = valor;
            this.PDT_VALIDADE_PRODUTO = validade;
            this.PDT_QUANTIDADE_PRODUTO = quantidade;
            this.PDT_USER_CHANGE = user;
        }


        private CONEXAO CNTN { get; set; }
        private SqlCommand SqlCMD { get; set; }

        public PRODUTOS()
        {
            CNTN = new CONEXAO();
            SqlCMD = new SqlCommand();
        }


        public void InserirProduto(string nome, double valor, DateTime validade, int quantidade, string user, byte[] imagem) 
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = @"INSERT INTO tb_PRODUTO VALUES(@nome, @valor, @validade, @quantidade, @user, @imagem)";
            SqlCMD.Parameters.AddWithValue("@nome", nome);
            SqlCMD.Parameters.AddWithValue("@valor", valor);
            SqlCMD.Parameters.AddWithValue("@validade", validade);
            SqlCMD.Parameters.AddWithValue("@quantidade", quantidade);
            SqlCMD.Parameters.AddWithValue("@user", user);
            SqlCMD.Parameters.AddWithValue("@imagem", imagem);

            if (SqlCMD.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("ADDED ON DB");
            }
        }



        public List<PRODUTOS> ListarProdutos()
        {
            List<PRODUTOS> itens = new List<PRODUTOS>();
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "SELECT * FROM tb_PRODUTO";
            SqlDataReader reader = SqlCMD.ExecuteReader();
            
            while(reader.Read())
            {
                PRODUTOS MDP = new PRODUTOS(Convert.ToInt32(reader["PDT_ID"]),
                    Convert.ToString(reader["PDT_NOME_PRODUTO"]),
                    Convert.ToDouble(reader["PDT_VALOR_PRODUTO"]),
                    Convert.ToDateTime(reader["PDT_VALIDADE_PRODUTO"]),
                    Convert.ToInt32(reader["PDT_QUANTIDADE_PRODUTO"]),
                    Convert.ToString(reader["PDT_USER_CHANGE"]),
                    (byte[])reader["PDT_IMAGEM_PRODUTO"]);

                itens.Add(MDP);
            }
            CNTN.Disconnect();
            return itens;
        }

        public List<PRODUTOS> ListarPesquisaString(string Produto)
        {
            List<PRODUTOS> itens = new List<PRODUTOS>();
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "SELECT * FROM tb_PRODUTO WHERE PDT_ID LIKE @PDT_ID";
            string PDT_format = "%" + Produto + "%";
            SqlCMD.Parameters.AddWithValue("@PDT_ID", PDT_format.Trim());
            SqlDataReader reader = SqlCMD.ExecuteReader();

            while (reader.Read())
            {
                PRODUTOS MDPS = new PRODUTOS(Convert.ToInt32(reader["PDT_ID"]),
                    Convert.ToString(reader["PDT_NOME_PRODUTO"]),
                    Convert.ToDouble(reader["PDT_VALOR_PRODUTO"]),
                    Convert.ToDateTime(reader["PDT_VALIDADE_PRODUTO"]),
                    Convert.ToInt32(reader["PDT_QUANTIDADE_PRODUTO"]),
                    Convert.ToString(reader["PDT_USER_CHANGE"]),
                    (byte[])reader["PDT_IMAGEM_PRODUTO"]);

                itens.Add(MDPS);
            }
            CNTN.Disconnect();
            return itens;
        }


        public bool AtualizarProduto(int id, string nome, double valor, DateTime validade, int quantidade, string user, byte[] imagem)
        {
            string IMG_BT = "0F"; 
            byte[] bytes = Encoding.ASCII.GetBytes(IMG_BT);

            if (imagem == null)
            {
                imagem = bytes;
            }

            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "UPDATE tb_PRODUTO SET PDT_NOME_PRODUTO = @nome, PDT_VALOR_PRODUTO = @valor, PDT_VALIDADE_PRODUTO = @validade, PDT_QUANTIDADE_PRODUTO = @quantidade, PDT_USER_CHANGE = @user, PDT_IMAGEM_PRODUTO = @imagem WHERE PDT_ID = @id";
            SqlCMD.Parameters.AddWithValue("@id", id);
            SqlCMD.Parameters.AddWithValue("@nome", nome);
            SqlCMD.Parameters.AddWithValue("@valor", valor);
            SqlCMD.Parameters.AddWithValue("@validade", validade);
            SqlCMD.Parameters.AddWithValue("@quantidade", quantidade);
            SqlCMD.Parameters.AddWithValue("@user", user);
            SqlCMD.Parameters.AddWithValue("@imagem", imagem);

            if (SqlCMD.ExecuteNonQuery() == 1)
            {
                return true;
            }
            return false;
        }

        public bool AtualizarProdutoVenda(int id, int quantidade)
        {
            string IMG_BT = "0F";
            byte[] bytes = Encoding.ASCII.GetBytes(IMG_BT);


            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "UPDATE tb_PRODUTO SET PDT_QUANTIDADE_PRODUTO = @quantidade WHERE PDT_ID = @id";
            SqlCMD.Parameters.AddWithValue("@id", id);
            SqlCMD.Parameters.AddWithValue("@quantidade", quantidade);

            if (SqlCMD.ExecuteNonQuery() == 1)
            {
                return true;
            }
            return false;
        }



        public List<PRODUTOS> ProdutoVenda(int Produto)
        {
            List<PRODUTOS> itens = new List<PRODUTOS>();
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "SELECT * FROM tb_PRODUTO WHERE PDT_ID = @PDT_ID";
            string PDT_format = "%" + Produto + "%";
            SqlCMD.Parameters.AddWithValue("@PDT_ID", Produto);
            SqlDataReader reader = SqlCMD.ExecuteReader();

            while (reader.Read())
            {
                PRODUTOS MDPS = new PRODUTOS(Convert.ToInt32(reader["PDT_ID"]),
                    Convert.ToString(reader["PDT_NOME_PRODUTO"]),
                    Convert.ToDouble(reader["PDT_VALOR_PRODUTO"]),
                    Convert.ToDateTime(reader["PDT_VALIDADE_PRODUTO"]),
                    Convert.ToInt32(reader["PDT_QUANTIDADE_PRODUTO"]),
                    Convert.ToString(reader["PDT_USER_CHANGE"]),
                    (byte[])reader["PDT_IMAGEM_PRODUTO"]);

                itens.Add(MDPS);
            }
            CNTN.Disconnect();
            return itens;
        }

        public bool ExcluirProduto(int id)
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = @"DELETE FROM tb_PRODUTO WHERE PDT_ID = @id";

            SqlCMD.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = SqlCMD.ExecuteReader();

            return false;
        }
    }
}


// UPDATE tb_PRODUTO SET PDT_NOME_PRODUTO = @logradouro, PDT_VALOR_PRODUTO = @numero, PDT_VALIDADE_PRODUTO = @bairro, PDT_QUANTIDADE_PRODUTO = @cep, PDT_USER_CHANGE = @cidade, PDT_IMAGEM_PRODUTO = @estado WHERE PDT_ID = @idEnd