using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID_COFFEE_OCIDENTAL.lib.Views.RELATORIOS
{
    public partial class REL_PRODUTOS : Form
    {
        public REL_PRODUTOS()
        {
            InitializeComponent();
        }

        private void REL_PRODUTOS_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSet2.tb_PRODUTO'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_PRODUTOTableAdapter.Fill(this.dataSet2.tb_PRODUTO);
            this.reportViewer2.RefreshReport();
        }
    }
}
