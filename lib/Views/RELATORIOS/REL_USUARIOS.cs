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
    public partial class REL_USUARIOS : Form
    {
        public REL_USUARIOS()
        {
            InitializeComponent();
        }

        private void REL_USUARIOS_Load(object sender, EventArgs e)
        {
            this.tb_LOGINTableAdapter1.Fill(this.dataSet3.tb_LOGIN);
            this.reportViewer1.RefreshReport();
        }
    }
}
