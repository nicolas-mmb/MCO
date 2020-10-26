using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID_COFFEE_OCIDENTAL.lib.Models
{

    public class CONEXAO
    {
        private SqlConnection CNTN;

        public CONEXAO()
        {
              string STRING_CONNECTION_LOCAL = @"Data Source=MASTER\;Initial Catalog=MCO;Integrated Security=True";
              string STRING_CONNECTION_SERVER = @"Data Source=34.95.176.146;Initial Catalog=MCO;Persist Security Info=True;User ID=sa;Password=Nicolas@1020";

            try
            {
                CNTN = new SqlConnection(STRING_CONNECTION_SERVER);
                CNTN.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Erro:\n\n"+ ex.Message +"\n\nContate o Administrador do Sistema");
            }
            finally
            {
            }
        }


        public void Connect()
        {
            if (CNTN.State == ConnectionState.Closed)
            {
                CNTN.Open();
            }
        }

        public void Disconnect()
        {
            if(CNTN.State == ConnectionState.Open)
            {
                CNTN.Close();
            }
        }

        public SqlConnection ReturnConnection()
        {
            return CNTN;
        }
    }
}
