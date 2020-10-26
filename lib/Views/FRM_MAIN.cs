using MAID_COFFEE_OCIDENTAL.lib.Controllers;
using MAID_COFFEE_OCIDENTAL.lib.Views.MAIN_ITEMS;
using MAID_COFFEE_OCIDENTAL.lib.Views.RELATORIOS;
using MAID_COFFEE_OCIDENTAL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID_COFFEE_OCIDENTAL.lib.Views
{
    public partial class FRM_MAIN : Form
    {
        private int MDI(string FRM)
        {
            int n = 0;
            while (n < this.MdiChildren.Length)
            {
                if (this.MdiChildren[n].Name == FRM)
                {
                    return n;
                }
                n++;
            }
            return 9;
        }

        private void AbrirAdcUsar()
        {
            if (Application.OpenForms.OfType<FRM_CAD_USER>().Count() > 0)
            {
                ///MessageBox.Show("A Janela ESTOQUE Já Está Aberta");
                this.MdiChildren[MDI("FRM_CAD_USER")].Activate();
            }
            else
            {
                FRM_CAD_USER FCU = new FRM_CAD_USER();
                FCU.MdiParent = this;
                FCU.Show();
                FCU.WindowState = FormWindowState.Normal;
                FCU.WindowState = FormWindowState.Maximized;
            }
        }

        private void AbrirFerrDeADM()
        {
            if (Application.OpenForms.OfType<ADM_TOOL>().Count() > 0)
            {
                ///MessageBox.Show("A Janela ESTOQUE Já Está Aberta");
                this.MdiChildren[MDI("ADM_TOOL")].Activate();
            }
            else
            {
                ADM_TOOL FRMX = new ADM_TOOL(this.TSSL_USER.Text);
                FRMX.MdiParent = this;
                FRMX.Show();
                FRMX.WindowState = FormWindowState.Normal;
                FRMX.WindowState = FormWindowState.Maximized;
            }
        }

        public void CarregarImagens()
        {
            //PICBOX
            pictureBox1.BackgroundImage = Resources.logo;
            //BTN
            button1.BackgroundImage = Resources.ui_pedido;
            button2.BackgroundImage = Resources.ui_product;
            button3.BackgroundImage = Resources.ui_stock;
            button4.BackgroundImage = Resources.ui_userChange;
            button5.BackgroundImage = Resources.ui_cadUser;
            button6.BackgroundImage = Resources.ui_money;
            button7.BackgroundImage = Resources.ui_push;
            button8.BackgroundImage = Resources.ui_push;
            button9.BackgroundImage = Resources.ui_push;

        }

        private void AbrirREL_VENDAS()
        {
            if (Application.OpenForms.OfType<REL_VENDAS>().Count() > 0)
            {
                ///MessageBox.Show("A Janela ESTOQUE Já Está Aberta");
                this.MdiChildren[MDI("FRM_VENDAS")].Activate();
            }
            else
            {
                REL_VENDAS FRMX = new REL_VENDAS();
                FRMX.MdiParent = this;
                FRMX.Show();
                FRMX.WindowState = FormWindowState.Normal;
                //FRMX.WindowState = FormWindowState.Maximized;
            }
        }


        private void AbrirREL_USUARIOS()
        {
            if (Application.OpenForms.OfType<REL_USUARIOS>().Count() > 0)
            {
                ///MessageBox.Show("A Janela ESTOQUE Já Está Aberta");
                this.MdiChildren[MDI("REL_USUARIOS")].Activate();
            }
            else
            {
                REL_USUARIOS FRMX = new REL_USUARIOS();
                FRMX.MdiParent = this;
                FRMX.Show();
                FRMX.WindowState = FormWindowState.Normal;
                // FRMX.WindowState = FormWindowState.Maximized;
            }
        }



        private void AbrirREL_PRODUTOS()
        {
            if (Application.OpenForms.OfType<REL_PRODUTOS>().Count() > 0)
            {
                ///MessageBox.Show("A Janela ESTOQUE Já Está Aberta");
                this.MdiChildren[MDI("REL_PRODUTOS")].Activate();
            }
            else
            {
                REL_PRODUTOS FRMX = new REL_PRODUTOS();
                FRMX.MdiParent = this;
                FRMX.Show();
                FRMX.WindowState = FormWindowState.Normal;
               // FRMX.WindowState = FormWindowState.Maximized;
            }
        }


        private void AbrirVendas()
        {
            if (Application.OpenForms.OfType<FRM_VENDAS>().Count() > 0)
            {
                ///MessageBox.Show("A Janela ESTOQUE Já Está Aberta");
                this.MdiChildren[MDI("FRM_VENDAS")].Activate();
            }
            else
            {
                FRM_VENDAS FRMX = new FRM_VENDAS();
                FRMX.MdiParent = this;
                FRMX.Show();
                FRMX.WindowState = FormWindowState.Normal;
                FRMX.WindowState = FormWindowState.Maximized;
            }
        }

        private void AbrirEstoque()
        {
            if (Application.OpenForms.OfType<ESTOQUE>().Count() > 0)
            {
                ///MessageBox.Show("A Janela ESTOQUE Já Está Aberta");
                this.MdiChildren[MDI("ESTOQUE")].Activate();
            }
            else
            {
                ESTOQUE FRMX = new ESTOQUE(this.TSSL_USER.Text);
                FRMX.MdiParent = this;
                FRMX.Show();
                FRMX.WindowState = FormWindowState.Normal;
                FRMX.WindowState = FormWindowState.Maximized;
            }
        }

        private void AbrirCAD_PRODUTO()
        {
            if (Application.OpenForms.OfType<CAD_PRODUTO>().Count() > 0)
            {
                //MessageBox.Show("A Janela CAD. PRODUTO Já Está Aberta");
                this.MdiChildren[MDI("CAD_PRODUTO")].Activate();
            }
            else
            {
                CAD_PRODUTO FRMX = new CAD_PRODUTO(this.TSSL_USER.Text);
                FRMX.MdiParent = this;
                FRMX.Show();
                FRMX.WindowState = FormWindowState.Normal;
                FRMX.WindowState = FormWindowState.Maximized;
            }
        }


        private void AbrirREAL_PEDIDO()
        {
            if (Application.OpenForms.OfType<REAL_PEDIDO>().Count() > 0)
            {
                //MessageBox.Show("A Janela REALIZAR PEDIDO Já Está Aberta");
                this.MdiChildren[MDI("REAL_PEDIDO")].Activate();
            }
            else
            {
                REAL_PEDIDO FRMX = new REAL_PEDIDO(this.TSSL_USER.Text);
                FRMX.MdiParent = this;
                FRMX.Show();
                FRMX.WindowState = FormWindowState.Normal;
                FRMX.WindowState = FormWindowState.Maximized;
            }
        }



        //public C_USUARIO { get; set; }
        public FRM_MAIN(string CPF, bool access)
        {
            InitializeComponent();
            this.TSSL_USER.Text = CPF;
            CarregarImagens();
            C_USUARIO.VerficaADM(CPF);

            if (access == false)
            {
                button9.Visible = false;
                button8.Visible = false;
                button7.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
                panel14.Visible = false;
                panel13.Visible = false;
                panel12.Visible = false;
                panel11.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
            }

        }

        private void uSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            AbrirREAL_PEDIDO();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirCAD_PRODUTO();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            AbrirEstoque();
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            //this.toolStripStatusLabel1.Text = 
            //MessageBox.Show();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirEstoque();
        }

        private void realizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirREAL_PEDIDO();
        }

        private void cadastrarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCAD_PRODUTO();
        }

        private void pesquisarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFerrDeADM();
        }

        private void cASCATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void hORIZONTALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void vERTICALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFerrDeADM();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirAdcUsar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirVendas();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirREL_VENDAS();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirREL_PRODUTOS();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirREL_USUARIOS();
        }
    }
}
