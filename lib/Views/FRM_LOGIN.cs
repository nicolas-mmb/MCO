using MAID_COFFEE_OCIDENTAL.lib.Controllers;
using MAID_COFFEE_OCIDENTAL.lib.Models;
using MAID_COFFEE_OCIDENTAL.lib.Views;
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

namespace MAID_COFFEE_OCIDENTAL
{
    public partial class FRM_LOGIN : Form
    {
        public FRM_LOGIN()
        {
            InitializeComponent();
            pictureBox1.BackgroundImage = Resources.logo;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            C_USUARIO USER = new C_USUARIO();
            //Console.WriteLine("{0}", Hash.generateFinalStringHASH(TXB_CPF.Text, TXB_SENHA.Text));

            if (USER.VerficaUsuario(TXB_CPF.Text, TXB_SENHA.Text) != false)
            {
                MessageBox.Show(String.Format("LOGADO COM SUCESSO: {0}", USER.USUARIO_ATUAL));
                this.Hide();

                FRM_MAIN frmMAIN = new FRM_MAIN(USER.USUARIO_ATUAL, C_USUARIO.VerficaADM(TXB_CPF.Text));
                frmMAIN.Show();
                //Console.WriteLine(C_USUARIO.VerficaADM(TXB_CPF.Text));
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }


        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void FRM_LOGIN_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
