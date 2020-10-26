using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace MAID_COFFEE_OCIDENTAL.lib.Models
//    class VENDA
//    {
//    }
//}


    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAID_COFFEE_OCIDENTAL.lib.Models
{
    class VENDA
    {
        public int VND_ID { get; set; }
        public string VND_USER_CHANGE { get; set; }
        public double VND_VALOR_TOTAL { get; set; }
        public DateTime VND_DATA_VENDA { get; set; }



        public VENDA(int id, string nome, double valor, DateTime validade)
        {
            this.VND_ID = id;
            this.VND_USER_CHANGE = nome;
            this.VND_VALOR_TOTAL = valor;
            this.VND_DATA_VENDA = validade;
        }

        private CONEXAO CNTN { get; set; }
        private SqlCommand SqlCMD { get; set; }

        public VENDA()
        {
            CNTN = new CONEXAO();
            SqlCMD = new SqlCommand();
        }

        public void InserirVenda(double valor, string user, DateTime validade)
        {
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = @"INSERT INTO tb_VENDAS VALUES(@user, @valor, @validade)";
            SqlCMD.Parameters.AddWithValue("@valor", valor);
            SqlCMD.Parameters.AddWithValue("@validade", validade);
            SqlCMD.Parameters.AddWithValue("@user", user);

            if (SqlCMD.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("ADDED ON DB");
            }
        }

        public List<VENDA> ListarProdutos()
        {
            List<VENDA> itens = new List<VENDA>();
            SqlCMD.Connection = CNTN.ReturnConnection();
            SqlCMD.CommandText = "SELECT * FROM tb_VENDAS";
            SqlDataReader reader = SqlCMD.ExecuteReader();

            while (reader.Read())
            {
                VENDA MDP = new VENDA(Convert.ToInt32(reader["VND_ID"]),
                    Convert.ToString(reader["VND_USER_CHANGE"]),
                    Convert.ToDouble(reader["VND_VALOR_TOTAL"]),
                    Convert.ToDateTime(reader["VND_DATA_VENDA"]));
                itens.Add(MDP);
            }
            CNTN.Disconnect();
            return itens;
        }

        public List<VENDA> ListarPesquisaString(DateTime inicio, DateTime fim)
        {
            List<VENDA> itens = new List<VENDA>();
            SqlCMD.Connection = CNTN.ReturnConnection();
            //select* from tb_VENDAS where VND_DATA_VENDA between '24-10-2020' and '25-10-2020'
            SqlCMD.CommandText = "SELECT * FROM tb_VENDAS WHERE VND_DATA_VENDA between @inicio AND @fim";
            SqlCMD.Parameters.AddWithValue("@inicio", inicio);
            SqlCMD.Parameters.AddWithValue("@fim", fim);
            SqlDataReader reader = SqlCMD.ExecuteReader();


            while (reader.Read())
            {
                VENDA MDP = new VENDA(Convert.ToInt32(reader["VND_ID"]),
                    Convert.ToString(reader["VND_USER_CHANGE"]),
                    Convert.ToDouble(reader["VND_VALOR_TOTAL"]),
                    Convert.ToDateTime(reader["VND_DATA_VENDA"]));
                itens.Add(MDP);
            }
            CNTN.Disconnect();
            return itens;
        }
    }
}