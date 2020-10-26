using MAID_COFFEE_OCIDENTAL.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAID_COFFEE_OCIDENTAL.lib.Controllers
{
    class C_VENDA
    {
        public static void InserirProdutoVenda( double valor,string user, DateTime data)
        {
            VENDA PDS = new VENDA();
            PDS.InserirVenda (valor, user,data);
        }

        public List<VENDA> RetornarVendasPesquisa(DateTime inicio, DateTime fim)
        {
            VENDA PDS = new VENDA();
            return PDS.ListarPesquisaString(inicio, fim);
        }

        public List<VENDA> RetornarTodasVendas()
        {
            VENDA PDS = new VENDA();
            return PDS.ListarProdutos();
        }
    }
}
