using MAID_COFFEE_OCIDENTAL.lib.Controllers;
using MAID_COFFEE_OCIDENTAL.lib.Models;
using MAID_COFFEE_OCIDENTAL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID_COFFEE_OCIDENTAL.lib.Views.MAIN_ITEMS
{
    public partial class ESTOQUE : Form
    {
        private string _imagem = String.Empty;

        private byte[] _img = null;
        private string _cpf = null;
        private string _id = null;

        public void LimparCampos()
        {
            TXB_COD.ResetText();
            TXT_PD.ResetText();
            TXT_VLR.ResetText();
            TXB_DV.ResetText();
            TXB_QTD.ResetText();
            TXB_COD.Focus();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            PBX_ITEM.BackgroundImage = Resources.ui_cardboard;
        }


        public void ATUALIZAR_ITEM()
        {

            int id = Convert.ToInt32(_id);
            string nome = TXT_PD.Text;
            double valor = double.Parse(TXT_VLR.Text);
            DateTime validade = DateTime.Parse(TXB_DV.Text);
            int quantidade = int.Parse(TXB_QTD.Text);
            string user = _cpf;
            validade.ToString("dd-MM-yyyy");
            byte[] imagem = null;

            try
            {
                FileStream FS = new FileStream(_imagem, FileMode.Open, FileAccess.Read);
                BinaryReader RD = new BinaryReader(FS);
                imagem = RD.ReadBytes((int)FS.Length);
                RD.Close();
                FS.Close();
            }
            catch
            {
                PBX_ITEM.BackgroundImage = Resources.ui_stockItems;
                imagem = _img;
            }
            finally
            {
                PBX_ITEM.BackgroundImageLayout = ImageLayout.Stretch;
            }

            C_PRODUTO PDT = new C_PRODUTO();
            PDT.AtualizarProdutoNoBD(id, nome, valor, validade, quantidade, user, imagem);
        }


        public ESTOQUE(string CPF)
        {
            InitializeComponent();
            ListViewCharger();
            _cpf = CPF;
            this.TSL_MD_USER.Text = _cpf;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
        }
        public void ListViewItemComplete()
        {
            button4.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = true;
            string id =          Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[0].Text);
            //string nome =        Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[1].Text);
            //string valor =       Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[2].Text);
            //string data =        Convert.ToDateTime(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[3].Text).ToShortDateString();
            //string quantidade =  Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[4].Text);
            //string user =        Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[5].Text);
            byte[] imagem =      Convert.FromBase64String(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[6].Text);

            _id = id;
            TXB_COD.Text = id;
            TXT_PD.Text = Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[1].Text);
            TXT_VLR.Text = Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[2].Text);
            TXB_QTD.Text = Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[4].Text);
            TXB_DV.Text = Convert.ToDateTime(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[3].Text).ToShortDateString();
            _img = imagem;
            

            try
            {
                MemoryStream ms = new MemoryStream(imagem);
                PBX_ITEM.BackgroundImage = Image.FromStream(ms);
            }
            catch 
            {
                PBX_ITEM.BackgroundImage = Resources.ui_stockItems;
            }
            finally
            {
                PBX_ITEM.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        public void ListViewCharger()
        {
            LTVW_PD.Items.Clear();
            C_PRODUTO CPD = new C_PRODUTO();
            List<PRODUTOS> DataListView = CPD.RetornaProdutos();

            if (DataListView != null)
                LTVW_PD.View = View.Details;
            {
                foreach (var items in DataListView)
                {
                    ListViewItem LVI = new ListViewItem(items.PDT_ID.ToString());
                    LVI.SubItems.Add(String.Format("{0}", items.PDT_NOME_PRODUTO));
                    LVI.SubItems.Add(items.PDT_VALOR_PRODUTO.ToString("F"));
                    LVI.SubItems.Add(items.PDT_VALIDADE_PRODUTO.ToString("dd-MM-yyyy"));
                    LVI.SubItems.Add(items.PDT_QUANTIDADE_PRODUTO.ToString());
                    LVI.SubItems.Add(items.PDT_USER_CHANGE);
                    LVI.SubItems.Add(Convert.ToBase64String(items.PDT_IMAGEM_PRODUTO));
                    LTVW_PD.Items.Add(LVI);

                    //Console.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", items.PDT_ID, items.PDT_NOME_PRODUTO, items.PDT_VALOR_PRODUTO, items.PDT_VALIDADE_PRODUTO, items.PDT_QUANTIDADE_PRODUTO, items.PDT_USER_CHANGE));
                }
            }
        }



        public void ListViewChargerPesquisa(string Produto)
        {
            LTVW_PD.Items.Clear();
            C_PRODUTO CPD = new C_PRODUTO();
            List<PRODUTOS> DataListView = CPD.RetornaProdutosPesquisa(Produto);

            if (DataListView != null)
            {
                LTVW_PD.View = View.Details;
                foreach (var items in DataListView)
                {
                    ListViewItem LVI = new ListViewItem(items.PDT_ID.ToString());
                    LVI.SubItems.Add(String.Format("{0}", items.PDT_NOME_PRODUTO));
                    LVI.SubItems.Add(items.PDT_VALOR_PRODUTO.ToString("F"));
                    LVI.SubItems.Add(items.PDT_VALIDADE_PRODUTO.ToString("dd-MM-yyyy"));
                    LVI.SubItems.Add(items.PDT_QUANTIDADE_PRODUTO.ToString());
                    LVI.SubItems.Add(items.PDT_USER_CHANGE);
                    LVI.SubItems.Add(Convert.ToBase64String(items.PDT_IMAGEM_PRODUTO));
                    LTVW_PD.Items.Add(LVI);

                    //Console.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", items.PDT_ID, items.PDT_NOME_PRODUTO, items.PDT_VALOR_PRODUTO, items.PDT_VALIDADE_PRODUTO, items.PDT_QUANTIDADE_PRODUTO, items.PDT_USER_CHANGE));
                }
            }
        }

        private void ESTOQUE_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListViewChargerPesquisa(TXB_COD.Text);
        }

        private void TXB_COD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                LTVW_PD.Items.Clear();
                ListViewChargerPesquisa(TXB_COD.Text);
            }
        }

        private void LTVW_PD_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItemComplete();
        }
        private void TXT_VLR_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ATUALIZAR_ITEM();
            ListViewCharger();
            LimparCampos();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

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

        private void LTVW_PD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult MSGBOX = MessageBox.Show("Apagar Registro?", "Você Irá Apagar Esse Registro.\n Deseja Apagar?", MessageBoxButtons.YesNo);


            if (MSGBOX == DialogResult.Yes)
            {
                C_PRODUTO.ExcluirProduto(Convert.ToInt32(_id));
                ListViewCharger();
                LimparCampos();
            }
            else if (MSGBOX == DialogResult.No)
            {

            }
            
        }

        private void PBX_ITEM_Click(object sender, EventArgs e)
        {

        }
    }
}
