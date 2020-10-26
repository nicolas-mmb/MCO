using MAID_COFFEE_OCIDENTAL.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAID_COFFEE_OCIDENTAL.lib.Controllers
{
    class C_PRODUTO
    {
        public List<PRODUTOS> RetornaProdutos()
        {
            PRODUTOS PDS = new PRODUTOS();
            return PDS.ListarProdutos();
        }

        public List<PRODUTOS> RetornaProdutosPesquisa(string Produto)
        {
            PRODUTOS PDS = new PRODUTOS();
            return PDS.ListarPesquisaString(Produto);
        }

        public bool AdicionarProdutoNoBD(string nome, double valor, DateTime validade, int quantidade, string user, byte[] imagem)
        {
            PRODUTOS PDS = new PRODUTOS();
            PDS.InserirProduto(nome, valor, validade, quantidade, user, imagem);
            return true;
        }

        public static List<PRODUTOS> ProdutoParaVenda(int id)
        {
            PRODUTOS PDS = new PRODUTOS();
            return PDS.ProdutoVenda(id);
        }

        public void AtualizarProdutoNoBD(int id,string nome, double valor, DateTime validade, int quantidade, string user, byte[] imagem)
        {
            PRODUTOS PDS = new PRODUTOS();
            PDS.AtualizarProduto(id, nome, valor, validade, quantidade, user, imagem);
        }

        public static void ExcluirProduto(int id)
        { 
            PRODUTOS PDS = new PRODUTOS();
            PDS.ExcluirProduto(id);
        }

        public static void AtualizarProdutoVenda(int id, int quantidade)
        {
            PRODUTOS PDS = new PRODUTOS();
            PDS.AtualizarProdutoVenda(id,quantidade);
        }


    }
}
