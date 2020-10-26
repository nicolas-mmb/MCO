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
    public partial class REL_VENDAS : Form
    {
        public REL_VENDAS()
        {
            InitializeComponent();
        }

        private void REL_VENDAS_Load(object sender, EventArgs e)
        {
            this.tb_VENDASTableAdapter1.Fill(this.dataSet1.tb_VENDAS);
            this.reportViewer1.RefreshReport();
        }
    }
}
