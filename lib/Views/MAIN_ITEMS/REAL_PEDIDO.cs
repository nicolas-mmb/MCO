using MAID_COFFEE_OCIDENTAL.lib.Controllers;
using MAID_COFFEE_OCIDENTAL.lib.Models;
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
    public partial class REAL_PEDIDO : Form
    {
        public REAL_PEDIDO(string CPF)
        {
            InitializeComponent();
            CarregarItens();
            timer1.Start();
            timer2.Start();
            TSL_MD_USER.Text = CPF;
        }

        public struct ProdutosInfo
        {
            public int ID;
            public int Quantidade;
            public Double Valor;
            public string Nome;
            public int TotalPedido;
        }

        ProdutosInfo _PD01, _PD02, _PD03, _PD04, _PD05, _PD06, _PD07, _PD08, _PD09, _PD10, _PD11, _PD12, _PD13, _PD14, _PD15, _PD16, _PD17, _PD18, _PD19, _PD20, _PD21;

        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult MSGBOX = MessageBox.Show("Operação em Andamento", "Deseja Cancelar a Operação e Descartar os Dados?", MessageBoxButtons.YesNo);


            if (MSGBOX == DialogResult.Yes)
            {
                this.Close();
            }
            else if (MSGBOX == DialogResult.No)
            {

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void REAL_PEDIDO_Load_1(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            var datax = GerarLista();
            var totaldopedido = datax.Sum(c => c.Valor * c.TotalPedido);
            lbPrecoFinal.Text = "R$ " + totaldopedido.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var datax = GerarLista();
            ListViewCharger(datax);

            var totaldopedido = datax.Sum(c => c.Valor * c.TotalPedido);
            lbPrecoFinal.Text = "R$ " + totaldopedido.ToString();
        }


        public void ListViewCharger(List<ProdutosInfo> lsPD)
        {
            listView1.Items.Clear();
            

            if (lsPD != null)
            {
                listView1.View = View.Details;
                foreach (var items in lsPD)
                    if (items.TotalPedido > 0)
                    {
                        {
                            ListViewItem LVI = new ListViewItem(items.Nome);
                            LVI.SubItems.Add(items.TotalPedido.ToString()); // quantidade
                            LVI.SubItems.Add(items.Valor.ToString()); // preco do produto
                            LVI.SubItems.Add((items.Valor * items.TotalPedido).ToString()); // preco total dos produtos (quantidade * valor)
                            listView1.Items.Add(LVI);

                            Console.WriteLine(String.Format("{0},{1},{2},{3},{4}", items.ID, items.Nome, items.TotalPedido, items.Valor, (items.Valor * items.TotalPedido)));
                        }
                    }
            }
        }




        private void button1_Click_3(object sender, EventArgs e)
        {


            DialogResult MSGBOX = MessageBox.Show("Finalizando Compra", "Deseja Finalizar Essa Operação de Venda?", MessageBoxButtons.YesNo);


            if (MSGBOX == DialogResult.Yes)
            {
                CarregarItens();
                var datax = GerarLista();
                var totaldopedido = datax.Sum(c => c.Valor * c.TotalPedido);

                FinalizarCompra(datax);
                C_VENDA.InserirProdutoVenda(totaldopedido, this.TSL_MD_USER.Text, DateTime.Now);
                this.Close();
            }
            else if (MSGBOX == DialogResult.No)
            {

            }



        }

        public List<ProdutosInfo> GerarLista()
        {
            List<ProdutosInfo> pd = new List<ProdutosInfo>();
            pd.Add(_PD01); pd.Add(_PD02); pd.Add(_PD03); pd.Add(_PD04); pd.Add(_PD05); pd.Add(_PD06); pd.Add(_PD07);
            pd.Add(_PD08); pd.Add(_PD09); pd.Add(_PD10); pd.Add(_PD11); pd.Add(_PD12); pd.Add(_PD13); pd.Add(_PD14); 
            pd.Add(_PD15); pd.Add(_PD16); pd.Add(_PD17); pd.Add(_PD18); pd.Add(_PD19); pd.Add(_PD20); pd.Add(_PD21);
            return pd;
        }

        public void FinalizarCompra(List<ProdutosInfo> lsPD)
        {
            foreach(var ns in lsPD)
            {
                int QuantidadeFinal = ns.Quantidade - ns.TotalPedido;
                var lstTotal = ns.Valor * ns.TotalPedido;
                //var valores = (ns.Valor * ns.TotalPedido);
                C_PRODUTO.AtualizarProdutoVenda(ns.ID, QuantidadeFinal);
                //Console.WriteLine("Item: " + ns.Nome +"\n" + "Quantidade Final: " + QuantidadeFinal + "\n" + "Preco Total: " + lstTotal);
            }

            double x = lsPD.Sum(c => c.Valor * c.TotalPedido);
            Console.WriteLine("Valor total da compra: " + x);



            //var n = lsPD.Sum(x => lsPD[0].Valor * lsPD[0].TotalPedido);
            //Console.WriteLine(n.ToString());
            //Console.WriteLine(lsPD[0].Valor * lsPD[0].TotalPedido);
        }



        private void REAL_PEDIDO_Load(object sender, EventArgs e)
        {

        }

        public void CarregarItens()
        {
            // 1 - NOME
            // 2 - VALOR
            // 4 - QUANTIDADE
            // 6 - IMAGEM
            //

            var DTX01 = C_PRODUTO.ProdutoParaVenda(1);
            _PD01.ID          = DTX01[0].PDT_ID;
            _PD01.Quantidade  = DTX01[0].PDT_QUANTIDADE_PRODUTO;
            _PD01.Valor       = DTX01[0].PDT_VALOR_PRODUTO;
            _PD01.Nome        = DTX01[0].PDT_NOME_PRODUTO;
            _PD01.TotalPedido = Convert.ToInt32(numericUpDown1.Value);

            var DTX02 = C_PRODUTO.ProdutoParaVenda(2);
            _PD02.ID         = DTX02[0].PDT_ID;
            _PD02.Quantidade = DTX02[0].PDT_QUANTIDADE_PRODUTO;
            _PD02.Valor      = DTX02[0].PDT_VALOR_PRODUTO;
            _PD02.Nome       = DTX02[0].PDT_NOME_PRODUTO;
            _PD02.TotalPedido = Convert.ToInt32(numericUpDown2.Value);

            var DTX03 = C_PRODUTO.ProdutoParaVenda(3);
            _PD03.ID         = DTX03[0].PDT_ID;
            _PD03.Quantidade = DTX03[0].PDT_QUANTIDADE_PRODUTO;
            _PD03.Valor      = DTX03[0].PDT_VALOR_PRODUTO;
            _PD03.Nome       = DTX03[0].PDT_NOME_PRODUTO;
            _PD03.TotalPedido = Convert.ToInt32(numericUpDown3.Value);

            var DTX04 = C_PRODUTO.ProdutoParaVenda(4);
            _PD04.ID         = DTX04[0].PDT_ID;
            _PD04.Quantidade = DTX04[0].PDT_QUANTIDADE_PRODUTO;
            _PD04.Valor      = DTX04[0].PDT_VALOR_PRODUTO;
            _PD04.Nome       = DTX04[0].PDT_NOME_PRODUTO;
            _PD04.TotalPedido = Convert.ToInt32(numericUpDown4.Value);

            var DTX05 = C_PRODUTO.ProdutoParaVenda(5);
            _PD05.ID         = DTX05[0].PDT_ID;
            _PD05.Quantidade = DTX05[0].PDT_QUANTIDADE_PRODUTO;
            _PD05.Valor      = DTX05[0].PDT_VALOR_PRODUTO;
            _PD05.Nome       = DTX05[0].PDT_NOME_PRODUTO;
            _PD05.TotalPedido = Convert.ToInt32(numericUpDown5.Value);

            var DTX06 = C_PRODUTO.ProdutoParaVenda(6);
            _PD06.ID         = DTX06[0].PDT_ID;
            _PD06.Quantidade = DTX06[0].PDT_QUANTIDADE_PRODUTO;
            _PD06.Valor      = DTX06[0].PDT_VALOR_PRODUTO;
            _PD06.Nome       = DTX06[0].PDT_NOME_PRODUTO;
            _PD06.TotalPedido = Convert.ToInt32(numericUpDown6.Value);

            var DTX07 = C_PRODUTO.ProdutoParaVenda(7);
            _PD07.ID         = DTX07[0].PDT_ID;
            _PD07.Quantidade = DTX07[0].PDT_QUANTIDADE_PRODUTO;
            _PD07.Valor      = DTX07[0].PDT_VALOR_PRODUTO;
            _PD07.Nome       = DTX07[0].PDT_NOME_PRODUTO;
            _PD07.TotalPedido = Convert.ToInt32(numericUpDown7.Value);

            var DTX08 = C_PRODUTO.ProdutoParaVenda(8);
            _PD08.ID         = DTX08[0].PDT_ID;
            _PD08.Quantidade = DTX08[0].PDT_QUANTIDADE_PRODUTO;
            _PD08.Valor      = DTX08[0].PDT_VALOR_PRODUTO;
            _PD08.Nome       = DTX08[0].PDT_NOME_PRODUTO;
            _PD08.TotalPedido = Convert.ToInt32(numericUpDown8.Value);

            var DTX09 = C_PRODUTO.ProdutoParaVenda(9);
            _PD09.ID         = DTX09[0].PDT_ID;
            _PD09.Quantidade = DTX09[0].PDT_QUANTIDADE_PRODUTO;
            _PD09.Valor      = DTX09[0].PDT_VALOR_PRODUTO;
            _PD09.Nome       = DTX09[0].PDT_NOME_PRODUTO;
            _PD09.TotalPedido = Convert.ToInt32(numericUpDown9.Value);

            var DTX10 = C_PRODUTO.ProdutoParaVenda(10);
            _PD10.ID         = DTX10[0].PDT_ID;
            _PD10.Quantidade = DTX10[0].PDT_QUANTIDADE_PRODUTO;
            _PD10.Valor      = DTX10[0].PDT_VALOR_PRODUTO;
            _PD10.Nome        = DTX10[0].PDT_NOME_PRODUTO;
            _PD10.TotalPedido = Convert.ToInt32(numericUpDown10.Value);

            var DTX11 = C_PRODUTO.ProdutoParaVenda(11);
            _PD11.ID         = DTX11[0].PDT_ID;
            _PD11.Quantidade = DTX11[0].PDT_QUANTIDADE_PRODUTO;
            _PD11.Valor      = DTX11[0].PDT_VALOR_PRODUTO;
            _PD11.Nome       = DTX11[0].PDT_NOME_PRODUTO;
            _PD11.TotalPedido = Convert.ToInt32(numericUpDown11.Value);

            var DTX12 = C_PRODUTO.ProdutoParaVenda(12);
            _PD12.ID         = DTX12[0].PDT_ID;
            _PD12.Quantidade = DTX12[0].PDT_QUANTIDADE_PRODUTO;
            _PD12.Valor      = DTX12[0].PDT_VALOR_PRODUTO;
            _PD12.Nome       = DTX12[0].PDT_NOME_PRODUTO;
            _PD12.TotalPedido = Convert.ToInt32(numericUpDown12.Value);

            var DTX13 = C_PRODUTO.ProdutoParaVenda(13);
            _PD13.ID         = DTX13[0].PDT_ID;
            _PD13.Quantidade = DTX13[0].PDT_QUANTIDADE_PRODUTO;
            _PD13.Valor      = DTX13[0].PDT_VALOR_PRODUTO;
            _PD13.Nome       = DTX13[0].PDT_NOME_PRODUTO;
            _PD13.TotalPedido = Convert.ToInt32(numericUpDown13.Value);

            var DTX14 = C_PRODUTO.ProdutoParaVenda(14);
            _PD14.ID         = DTX14[0].PDT_ID;
            _PD14.Quantidade = DTX14[0].PDT_QUANTIDADE_PRODUTO;
            _PD14.Valor      = DTX14[0].PDT_VALOR_PRODUTO;
            _PD14.Nome       = DTX14[0].PDT_NOME_PRODUTO;
            _PD14.TotalPedido = Convert.ToInt32(numericUpDown14.Value);

            var DTX15 = C_PRODUTO.ProdutoParaVenda(15);
            _PD15.ID         = DTX15[0].PDT_ID;
            _PD15.Quantidade = DTX15[0].PDT_QUANTIDADE_PRODUTO;
            _PD15.Valor      = DTX15[0].PDT_VALOR_PRODUTO;
            _PD15.Nome       = DTX15[0].PDT_NOME_PRODUTO;
            _PD15.TotalPedido = Convert.ToInt32(numericUpDown15.Value);

            var DTX16 = C_PRODUTO.ProdutoParaVenda(16);
            _PD16.ID         = DTX16[0].PDT_ID;
            _PD16.Quantidade = DTX16[0].PDT_QUANTIDADE_PRODUTO;
            _PD16.Valor      = DTX16[0].PDT_VALOR_PRODUTO;
            _PD16.Nome       = DTX16[0].PDT_NOME_PRODUTO;
            _PD16.TotalPedido = Convert.ToInt32(numericUpDown16.Value);


            var DTX17 = C_PRODUTO.ProdutoParaVenda(17);
            _PD17.ID         = DTX17[0].PDT_ID;
            _PD17.Quantidade = DTX17[0].PDT_QUANTIDADE_PRODUTO;
            _PD17.Valor      = DTX17[0].PDT_VALOR_PRODUTO;
            _PD17.Nome       = DTX17[0].PDT_NOME_PRODUTO;
            _PD17.TotalPedido = Convert.ToInt32(numericUpDown17.Value);


            var DTX18 = C_PRODUTO.ProdutoParaVenda(18);
            _PD18.ID         = DTX18[0].PDT_ID;
            _PD18.Quantidade = DTX18[0].PDT_QUANTIDADE_PRODUTO;
            _PD18.Valor      = DTX18[0].PDT_VALOR_PRODUTO;
            _PD18.Nome       = DTX18[0].PDT_NOME_PRODUTO;
            _PD18.TotalPedido = Convert.ToInt32(numericUpDown18.Value);

            var DTX19 = C_PRODUTO.ProdutoParaVenda(19);
            _PD19.ID         = DTX19[0].PDT_ID;
            _PD19.Quantidade = DTX19[0].PDT_QUANTIDADE_PRODUTO;
            _PD19.Valor      = DTX19[0].PDT_VALOR_PRODUTO;
            _PD19.Nome       = DTX19[0].PDT_NOME_PRODUTO;
            _PD19.TotalPedido = Convert.ToInt32(numericUpDown19.Value);


            var DTX20 = C_PRODUTO.ProdutoParaVenda(20);
            _PD20.ID         = DTX20[0].PDT_ID;
            _PD20.Quantidade = DTX20[0].PDT_QUANTIDADE_PRODUTO;
            _PD20.Valor      = DTX20[0].PDT_VALOR_PRODUTO;
            _PD20.Nome       = DTX20[0].PDT_NOME_PRODUTO;
            _PD20.TotalPedido = Convert.ToInt32(numericUpDown20.Value);

            var DTX21 = C_PRODUTO.ProdutoParaVenda(21);
            _PD21.ID         = DTX21[0].PDT_ID;
            _PD21.Quantidade = DTX21[0].PDT_QUANTIDADE_PRODUTO;
            _PD21.Valor      = DTX21[0].PDT_VALOR_PRODUTO;
            _PD21.Nome       = DTX21[0].PDT_NOME_PRODUTO;
            _PD21.TotalPedido = Convert.ToInt32(numericUpDown21.Value);


            //CARREGA ITENS DA TELA
            groupBox1.Text = DTX01[0].PDT_NOME_PRODUTO;
            label1.Text = Convert.ToString("R$ " + DTX01[0].PDT_VALOR_PRODUTO);
            MemoryStream ms01 = new MemoryStream(DTX01[0].PDT_IMAGEM_PRODUTO);
            pictureBox1.BackgroundImage = Image.FromStream(ms01);
            numericUpDown1.Maximum = DTX01[0].PDT_QUANTIDADE_PRODUTO;

            groupBox2.Text = DTX02[0].PDT_NOME_PRODUTO;
            label2.Text = Convert.ToString("R$ " + DTX02[0].PDT_VALOR_PRODUTO);
            MemoryStream ms02 = new MemoryStream(DTX02[0].PDT_IMAGEM_PRODUTO);
            pictureBox2.BackgroundImage = Image.FromStream(ms02);
            numericUpDown2.Maximum = DTX02[0].PDT_QUANTIDADE_PRODUTO;

            groupBox3.Text = DTX03[0].PDT_NOME_PRODUTO;
            label3.Text = Convert.ToString("R$ " + DTX03[0].PDT_VALOR_PRODUTO);
            MemoryStream ms03 = new MemoryStream(DTX03[0].PDT_IMAGEM_PRODUTO);
            pictureBox3.BackgroundImage = Image.FromStream(ms03);
            numericUpDown3.Maximum = DTX03[0].PDT_QUANTIDADE_PRODUTO;

            groupBox4.Text = DTX04[0].PDT_NOME_PRODUTO;
            label4.Text = Convert.ToString("R$ " + DTX04[0].PDT_VALOR_PRODUTO);
            MemoryStream ms04 = new MemoryStream(DTX04[0].PDT_IMAGEM_PRODUTO);
            pictureBox4.BackgroundImage = Image.FromStream(ms04);
            numericUpDown4.Maximum = DTX04[0].PDT_QUANTIDADE_PRODUTO;

            groupBox5.Text = DTX05[0].PDT_NOME_PRODUTO;
            label5.Text = Convert.ToString("R$ " + DTX05[0].PDT_VALOR_PRODUTO);
            MemoryStream ms05 = new MemoryStream(DTX05[0].PDT_IMAGEM_PRODUTO);
            pictureBox5.BackgroundImage = Image.FromStream(ms05);
            numericUpDown5.Maximum = DTX05[0].PDT_QUANTIDADE_PRODUTO;

            groupBox6.Text = DTX06[0].PDT_NOME_PRODUTO;
            label6.Text = Convert.ToString("R$ " + DTX06[0].PDT_VALOR_PRODUTO);
            MemoryStream ms06 = new MemoryStream(DTX06[0].PDT_IMAGEM_PRODUTO);
            pictureBox6.BackgroundImage = Image.FromStream(ms06);
            numericUpDown6.Maximum = DTX06[0].PDT_QUANTIDADE_PRODUTO;

            groupBox7.Text = DTX07[0].PDT_NOME_PRODUTO;
            label7.Text = Convert.ToString("R$ " + DTX07[0].PDT_VALOR_PRODUTO);
            MemoryStream ms07 = new MemoryStream(DTX07[0].PDT_IMAGEM_PRODUTO);
            pictureBox7.BackgroundImage = Image.FromStream(ms07);
            numericUpDown7.Maximum = DTX07[0].PDT_QUANTIDADE_PRODUTO;

            groupBox8.Text = DTX08[0].PDT_NOME_PRODUTO;
            label8.Text = Convert.ToString("R$ " + DTX08[0].PDT_VALOR_PRODUTO);
            MemoryStream ms08 = new MemoryStream(DTX08[0].PDT_IMAGEM_PRODUTO);
            pictureBox8.BackgroundImage = Image.FromStream(ms08);
            numericUpDown8.Maximum = DTX08[0].PDT_QUANTIDADE_PRODUTO;

            groupBox9.Text = DTX09[0].PDT_NOME_PRODUTO;
            label9.Text = Convert.ToString("R$ " + DTX09[0].PDT_VALOR_PRODUTO);
            MemoryStream ms09 = new MemoryStream(DTX09[0].PDT_IMAGEM_PRODUTO);
            pictureBox9.BackgroundImage = Image.FromStream(ms09);
            numericUpDown9.Maximum = DTX09[0].PDT_QUANTIDADE_PRODUTO;

            groupBox10.Text = DTX10[0].PDT_NOME_PRODUTO;
            label10.Text = Convert.ToString("R$ " + DTX10[0].PDT_VALOR_PRODUTO);
            MemoryStream ms10 = new MemoryStream(DTX10[0].PDT_IMAGEM_PRODUTO);
            pictureBox10.BackgroundImage = Image.FromStream(ms10);
            numericUpDown10.Maximum = DTX10[0].PDT_QUANTIDADE_PRODUTO;

            groupBox11.Text = DTX11[0].PDT_NOME_PRODUTO;
            label11.Text = Convert.ToString("R$ " + DTX11[0].PDT_VALOR_PRODUTO);
            MemoryStream ms11 = new MemoryStream(DTX11[0].PDT_IMAGEM_PRODUTO);
            pictureBox11.BackgroundImage = Image.FromStream(ms11);
            numericUpDown11.Maximum = DTX11[0].PDT_QUANTIDADE_PRODUTO;

            groupBox12.Text = DTX12[0].PDT_NOME_PRODUTO;
            label12.Text = Convert.ToString("R$ " + DTX12[0].PDT_VALOR_PRODUTO);
            MemoryStream ms12 = new MemoryStream(DTX12[0].PDT_IMAGEM_PRODUTO);
            pictureBox12.BackgroundImage = Image.FromStream(ms12);
            numericUpDown12.Maximum = DTX12[0].PDT_QUANTIDADE_PRODUTO;

            groupBox13.Text = DTX13[0].PDT_NOME_PRODUTO;
            label13.Text = Convert.ToString("R$ " + DTX13[0].PDT_VALOR_PRODUTO);
            MemoryStream ms13 = new MemoryStream(DTX13[0].PDT_IMAGEM_PRODUTO);
            pictureBox13.BackgroundImage = Image.FromStream(ms13);
            numericUpDown13.Maximum = DTX13[0].PDT_QUANTIDADE_PRODUTO;

            groupBox14.Text = DTX14[0].PDT_NOME_PRODUTO;
            label14.Text = Convert.ToString("R$ " + DTX14[0].PDT_VALOR_PRODUTO);
            MemoryStream ms14 = new MemoryStream(DTX14[0].PDT_IMAGEM_PRODUTO);
            pictureBox14.BackgroundImage = Image.FromStream(ms14);
            numericUpDown14.Maximum = DTX14[0].PDT_QUANTIDADE_PRODUTO;

            groupBox15.Text = DTX15[0].PDT_NOME_PRODUTO;
            label15.Text = Convert.ToString("R$ " + DTX15[0].PDT_VALOR_PRODUTO);
            MemoryStream ms15 = new MemoryStream(DTX15[0].PDT_IMAGEM_PRODUTO);
            pictureBox15.BackgroundImage = Image.FromStream(ms15);
            numericUpDown15.Maximum = DTX15[0].PDT_QUANTIDADE_PRODUTO;

            groupBox16.Text = DTX16[0].PDT_NOME_PRODUTO;
            label16.Text = Convert.ToString("R$ " + DTX16[0].PDT_VALOR_PRODUTO);
            MemoryStream ms16 = new MemoryStream(DTX16[0].PDT_IMAGEM_PRODUTO);
            pictureBox16.BackgroundImage = Image.FromStream(ms16);
            numericUpDown16.Maximum = DTX16[0].PDT_QUANTIDADE_PRODUTO;

            groupBox17.Text = DTX17[0].PDT_NOME_PRODUTO;
            label17.Text = Convert.ToString("R$ " + DTX17[0].PDT_VALOR_PRODUTO);
            MemoryStream ms17 = new MemoryStream(DTX17[0].PDT_IMAGEM_PRODUTO);
            pictureBox17.BackgroundImage = Image.FromStream(ms17);
            numericUpDown17.Maximum = DTX17[0].PDT_QUANTIDADE_PRODUTO;

            groupBox18.Text = DTX18[0].PDT_NOME_PRODUTO;
            label18.Text = Convert.ToString("R$ " + DTX18[0].PDT_VALOR_PRODUTO);
            MemoryStream ms18 = new MemoryStream(DTX18[0].PDT_IMAGEM_PRODUTO);
            pictureBox18.BackgroundImage = Image.FromStream(ms18);
            numericUpDown18.Maximum = DTX18[0].PDT_QUANTIDADE_PRODUTO;

            groupBox19.Text = DTX19[0].PDT_NOME_PRODUTO;
            label19.Text = Convert.ToString("R$ " + DTX19[0].PDT_VALOR_PRODUTO);
            MemoryStream ms19 = new MemoryStream(DTX19[0].PDT_IMAGEM_PRODUTO);
            pictureBox19.BackgroundImage = Image.FromStream(ms19);
            numericUpDown19.Maximum = DTX19[0].PDT_QUANTIDADE_PRODUTO;

            groupBox20.Text = DTX20[0].PDT_NOME_PRODUTO;
            label20.Text = Convert.ToString("R$ " + DTX20[0].PDT_VALOR_PRODUTO);
            MemoryStream ms20 = new MemoryStream(DTX20[0].PDT_IMAGEM_PRODUTO);
            pictureBox20.BackgroundImage = Image.FromStream(ms20);
            numericUpDown20.Maximum = DTX20[0].PDT_QUANTIDADE_PRODUTO;

            groupBox21.Text = DTX21[0].PDT_NOME_PRODUTO;
            label21.Text = Convert.ToString("R$ " + DTX21[0].PDT_VALOR_PRODUTO);
            MemoryStream ms21 = new MemoryStream(DTX21[0].PDT_IMAGEM_PRODUTO);
            pictureBox21.BackgroundImage = Image.FromStream(ms21);
            numericUpDown21.Maximum = DTX21[0].PDT_QUANTIDADE_PRODUTO;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CarregarItens();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregarItens();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }
    }
}
