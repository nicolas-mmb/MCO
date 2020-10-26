using MAID_COFFEE_OCIDENTAL.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAID_COFFEE_OCIDENTAL.lib.Controllers
{
    class C_USUARIO
    {
        public string USUARIO_ATUAL = "";
        public bool VerficaUsuario(string CPF, string SENHA)
        {
            USUARIOS USER = new USUARIOS();
            USUARIO_ATUAL = CPF;
            string SENHA_FINAL = Hash.generateFinalStringHASH(CPF, SENHA);

            if (USER.ChecarLogin(CPF, SENHA_FINAL))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool VerficaADM(string CPF)
        {
            USUARIOS USER = new USUARIOS();
            if (USER.ADM(CPF) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool AddUsuario(string CPF, string SENHA, bool isADM, bool IsAttendant, string nome, bool biosex, bool SenhaProtegida)
        {      
            USUARIOS add = new USUARIOS();

            switch (SenhaProtegida.ToString()) 
            {
                case "True":
                    add.AddLogin(CPF, Hash.generateFinalStringHASH(CPF, SENHA), isADM, IsAttendant, nome, biosex);
                    return true;
                case "False":
                    add.AddLogin(CPF, SENHA, isADM, IsAttendant, nome, biosex);
                    return true;
                default:
                    return false;
            }
        }

        public static bool AtualizarUsuario(string CPF, string SENHA, bool isADM, bool IsAttendant, string nome, bool biosex, bool SemSenha)
        {
            USUARIOS add = new USUARIOS();

            switch (SemSenha.ToString())
            {
                case "True":
                    add.AtualizarLogin(CPF, Hash.generateFinalStringHASH(CPF, SENHA), isADM, IsAttendant, nome, biosex);
                    return true;
                case "False":
                    add.AtualizarLoginSemSenha(CPF, isADM, IsAttendant, nome, biosex);
                    return true;
                default:
                    return false;
            }
        }


        public static bool ExcluirUsuario(string CPF)
        {
            USUARIOS PDS = new USUARIOS();
            PDS.ExcluirUsuario(CPF);
            return true;
        }



        public List<USUARIOS> RetornaUsuarios()
        {
            USUARIOS USERS = new USUARIOS();
            return USERS.ListarUsuarios();
        }

        public List<USUARIOS> ListUsers(string id)
        {
            USUARIOS USERS = new USUARIOS();
            return USERS.ListarPesquisaString(id);
        }
    }
}
