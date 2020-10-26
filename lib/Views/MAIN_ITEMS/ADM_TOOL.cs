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
    public partial class ADM_TOOL : Form
    {

        bool _IsADM, _IsAttendant, _biosex;

        public void ListViewChargerPesquisa(string Produto)
        {
            LTVW_PD.Items.Clear();
            C_USUARIO CPD = new C_USUARIO();
            List<USUARIOS> DataListView = CPD.ListUsers(Produto);

            if (DataListView != null)
            {
                LTVW_PD.View = View.Details;
                foreach (var items in DataListView)
                {
                    ListViewItem LVI = new ListViewItem(items.cpf.ToString());
                    LVI.SubItems.Add(items.nomes);
                    LVI.SubItems.Add(items.IsADM.ToString()         == "True" ? "Sim" : "Não");
                    LVI.SubItems.Add(items.IsAttendant.ToString()   == "True" ? "Sim" : "Não");
                    LVI.SubItems.Add(items.BiologicalSex.ToString() == "True" ? "Homen " : "Mulher");
                    LVI.SubItems.Add(items.senha);
                    LTVW_PD.Items.Add(LVI);
                }
            }
        }

        public void ListViewCharger()
        {
            LTVW_PD.Items.Clear();
            C_USUARIO CPD = new C_USUARIO();
            List<USUARIOS> DataListView = CPD.RetornaUsuarios();

            if (DataListView != null)
            {
                LTVW_PD.View = View.Details;
                foreach (var items in DataListView)
                {
                    ListViewItem LVI = new ListViewItem(items.cpf.ToString());
                    LVI.SubItems.Add(items.nomes);
                    LVI.SubItems.Add(items.IsADM.ToString()         == "True" ? "Sim" : "Não");
                    LVI.SubItems.Add(items.IsAttendant.ToString()   == "True" ? "Sim" : "Não");
                    LVI.SubItems.Add(items.BiologicalSex.ToString() == "True" ? "Homem" : "Mulher");
                    LVI.SubItems.Add(items.senha);
                    LTVW_PD.Items.Add(LVI);
                }
            }

            
        }

        public void CheckAndEnableBTN()
        {
            if (checkBox1.Checked != checkBox2.Checked && radioButton1.Checked != radioButton2.Checked && TXB_CPF.Text != "" && TXB_NOME.Text != "" && TXB_SENHA.Text != "")
            {
                BTN_ADDeUP.Enabled = true;
            }
            else
            {
                BTN_ADDeUP.Enabled = false;
            }

            // LOGICA DO XOR
            //true  xor false = true
            //true  xor true  = false
            //false xor true  = true
            //false xor false = false

            //(true  != false) // true
            //(true  != true)  // false
            //(false != true)  // true
            //(false != false) // false
        }

        public void ListViewItemComplete()
        {
            TXB_CPF.Text  = Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[0].Text);
            TXB_NOME.Text = Convert.ToString(LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[1].Text);
            _IsADM  = LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[2].Text.Equals("Sim");
            _biosex = LTVW_PD.Items[LTVW_PD.FocusedItem.Index].SubItems[4].Text.Equals("Homem");

        }





        public void LimparCampos()
        {
            TXB_CPF.Clear();
            TXB_NOME.Clear();
            TXB_SENHA.Clear();
            TXB_COD.Focus();
        }


        public ADM_TOOL(string CPF)
        {
            InitializeComponent();
            ListViewCharger();
            timer1.Start();

        }

        private void ADM_TOOL_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewChargerPesquisa(TXB_COD.Text);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            _IsADM = false;
            _IsAttendant = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            _IsADM = true;
            _IsAttendant = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult MSGBOX = MessageBox.Show("Atualizar as Informações do Usuário", "Deseja Modificar", MessageBoxButtons.YesNo);


            if (MSGBOX == DialogResult.Yes)
            {
                C_USUARIO.AtualizarUsuario(TXB_CPF.Text, TXB_SENHA.Text, _IsADM, _IsAttendant, TXB_NOME.Text, _biosex, true);
                LimparCampos();
                ListViewCharger();
            }
            else if (MSGBOX == DialogResult.No)
            {
                ListViewCharger();
            }
        }

        private void LTVW_PD_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItemComplete();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _biosex = false;
            radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _biosex = true;
            radioButton1.Checked = false;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult MSGBOX = MessageBox.Show("Excluir o Usuário", "Essa Alteração Não Poderá ser Revertida", MessageBoxButtons.YesNo);

            if (MSGBOX == DialogResult.Yes)
            {
                C_USUARIO.ExcluirUsuario(TXB_CPF.Text);
                ListViewCharger();
            }
            else if (MSGBOX == DialogResult.No)
            {
                ListViewCharger();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckAndEnableBTN();
        }
    }
}
