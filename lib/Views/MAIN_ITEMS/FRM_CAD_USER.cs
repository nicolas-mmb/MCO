using MAID_COFFEE_OCIDENTAL.lib.Controllers;
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
    public partial class FRM_CAD_USER : Form
    {

        bool _IsADM;
        bool _IsAttendant;
        bool _biosex;

        public FRM_CAD_USER()
        {
            InitializeComponent();
            timer1.Start();
            pictureBox1.BackgroundImage = Resources.logo;
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


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult MSGBOX = MessageBox.Show("Adicionar Usuário", "Deseja Adicionar Usuário", MessageBoxButtons.YesNo);


            if (MSGBOX == DialogResult.Yes)
            {
                C_USUARIO.AddUsuario(TXB_CPF.Text, TXB_SENHA.Text, _IsADM, _IsAttendant, TXB_NOME.Text, _biosex, true);
                this.Close();
                timer1.Stop();
            }
            else if (MSGBOX == DialogResult.No)
            {

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckAndEnableBTN();
        }

        private void FRM_CAD_USER_Load(object sender, EventArgs e)
        {

        }
    }
}
