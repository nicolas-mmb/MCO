using MAID_COFFEE_OCIDENTAL.lib.Controllers;
using MAID_COFFEE_OCIDENTAL.lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID_COFFEE_OCIDENTAL.lib.Views.MAIN_ITEMS
{
    public partial class FRM_VENDAS : Form
    {
        public void ListViewCharger()
        {
            LTVW_PD.Items.Clear();
            C_VENDA CPD = new C_VENDA();
            List<VENDA> DataListView = CPD.RetornarTodasVendas();

            if (DataListView != null)
                LTVW_PD.View = View.Details;
            {
                foreach (var items in DataListView)
                {
                    ListViewItem LVI = new ListViewItem(items.VND_ID.ToString());
                    LVI.SubItems.Add(items.VND_USER_CHANGE);
                    LVI.SubItems.Add(items.VND_VALOR_TOTAL.ToString());
                    LVI.SubItems.Add(items.VND_DATA_VENDA.ToString());
                    LTVW_PD.Items.Add(LVI);

                    //Console.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", items.PDT_ID, items.PDT_NOME_PRODUTO, items.PDT_VALOR_PRODUTO, items.PDT_VALIDADE_PRODUTO, items.PDT_QUANTIDADE_PRODUTO, items.PDT_USER_CHANGE));
                }
            }
        }


        public void ListViewChargerPesquisa()
        {
            LTVW_PD.Items.Clear();
            C_VENDA CPD = new C_VENDA();
            List<VENDA> DataListView = CPD.RetornarVendasPesquisa(DT_INCIO.Value, DT_FIM.Value);

            if (DataListView != null)
                LTVW_PD.View = View.Details;
            {
                foreach (var items in DataListView)
                {
                    ListViewItem LVI = new ListViewItem(items.VND_ID.ToString());
                    LVI.SubItems.Add(items.VND_USER_CHANGE);
                    LVI.SubItems.Add(items.VND_VALOR_TOTAL.ToString());
                    LVI.SubItems.Add(items.VND_DATA_VENDA.ToString("dd-MM-yyyy"));
                    LTVW_PD.Items.Add(LVI);

                    //Console.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", items.PDT_ID, items.PDT_NOME_PRODUTO, items.PDT_VALOR_PRODUTO, items.PDT_VALIDADE_PRODUTO, items.PDT_QUANTIDADE_PRODUTO, items.PDT_USER_CHANGE));
                }
            }
        }



        public FRM_VENDAS()
        {
            InitializeComponent();
            ListViewCharger();
            DT_INCIO.MaxDate = DateTime.Now.AddDays(-1);




        }

        private void FRM_VENDAS_Load(object sender, EventArgs e)
        {
            var dataminusum = DateTime.Now;
            dataminusum.AddDays(-1);


            DT_INCIO.MaxDate = dataminusum;
            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewChargerPesquisa();
        }

        private void LTVW_PD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
