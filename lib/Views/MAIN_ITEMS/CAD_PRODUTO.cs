using MAID_COFFEE_OCIDENTAL.lib.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID_COFFEE_OCIDENTAL.lib.Views.MAIN_ITEMS
{
    public partial class CAD_PRODUTO : Form
    {
        private string _imagem = String.Empty;
        public void CADASTRAR_ITEM()
        {
            try
            {
                FileStream FS = new FileStream(_imagem, FileMode.Open, FileAccess.Read);
                BinaryReader RD = new BinaryReader(FS);
                byte[] imagem = RD.ReadBytes((int)FS.Length);

                _imagem = imagem.ToString();
                string nome = TXB_PD.Text;
                double valor = double.Parse(TXB_VALOR.Text);
                DateTime validade = DateTime.Parse(TXB_DV.Text);
                int quantidade = int.Parse(TXB_QTD.Text);
                string user = this.TSL_MD_USER.Text;
                validade.ToString("dd-MM-yyyy");

                C_PRODUTO PDT = new C_PRODUTO();
                PDT.AdicionarProdutoNoBD(nome, valor, validade, quantidade, user, imagem);


                RD.Close();
                FS.Close();
            }
            catch
            {
                MessageBox.Show("Não Foi Possivel Carregar a Esse Registro No Banco de Dados Corretamente, Verifique no Estoque o Produto Adcionado e Verifique se Tudo Está Correto");


                byte[] imagem = {255};

                string nome = TXB_PD.Text;
                double valor = double.Parse(TXB_VALOR.Text);
                DateTime validade = DateTime.Parse(TXB_DV.Text);
                int quantidade = int.Parse(TXB_QTD.Text);
                string user = this.TSL_MD_USER.Text;
                validade.ToString("dd-MM-yyyy");

                C_PRODUTO PDT = new C_PRODUTO();
                PDT.AdicionarProdutoNoBD(nome, valor, validade, quantidade, user, imagem);
            }


            //string nome = TXB_PD.Text;
            //double valor = double.Parse(TXB_VALOR.Text);
            //DateTime validade = DateTime.Parse(TXB_DV.Text);
            //int quantidade = int.Parse(TXB_QTD.Text);
            //string user = this.TSL_MD_USER.Text;
            //validade.ToString("dd-MM-yyyy");
            //MessageBox.Show("{0}", label2.Text);




            //C_PRODUTO PDT = new C_PRODUTO();
            //PDT.AdicionarProdutoNoBD(nome, valor, validade, quantidade, user, _imagem);
        }


        public CAD_PRODUTO(string CPF)
        {
            InitializeComponent();
            this.TSL_MD_USER.Text = CPF;
        }

        private void TXB_VALOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',';
        }

        private void CAD_PRODUTO_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CADASTRAR_ITEM();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _imagem = string.Empty;
            if (OFD_imagem.ShowDialog() == DialogResult.OK)
            {
                _imagem = OFD_imagem.FileName;
                if (PBX_ITEM.Image != null)
                {
                    PBX_ITEM.Image.Dispose();
                    PBX_ITEM.Image = null;
                }
                PBX_ITEM.BackgroundImage = null;
                PBX_ITEM.BackgroundImageLayout = ImageLayout.Stretch;
                PBX_ITEM.BackgroundImage = Image.FromFile(_imagem);
            }
        }

        private void TSL_MD_USER_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TXB_VALOR_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
