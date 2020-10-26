using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAID_COFFEE_OCIDENTAL.lib.Controllers
{
    class Hash
    {
        private static string GenerateHash(string SALT_CPF2HASH)
        {
            SHA512 CPF512 = SHA512Managed.Create();
            byte[] Byte = Encoding.UTF8.GetBytes(SALT_CPF2HASH);
            byte[] Result = CPF512.ComputeHash(Byte);
            return GenerateHashString(Result);      
        }

        public static string generateFinalStringHASH(string CPF, string SENHA)
        {
            string salt_ASII = SALT_ASII(CPF).ToString();
            string cpfHASH = GenerateHash(CPF);
            string senhaHASH = GenerateHash(SENHA);

            string final_pass = cpfHASH + salt_ASII + senhaHASH;

            Console.WriteLine("{0}", final_pass);

            return final_pass; // <--- Retorna a CHAVE
        }

        private static string GenerateHashString(byte[] hash)
        {
            StringBuilder byte2stringHASH = new StringBuilder();
            if (hash != null)
            {
                for (int i = 0; i < hash.Length; i++)
                {
                    byte2stringHASH.Append(hash[i].ToString("X2")); // <-- formata corretamente a string 
                }
                return byte2stringHASH.ToString();
            }
            return null;
        }


        private static int SALT_ASII(String CPF)
        {
            char[] CPFX = CPF.ToCharArray();
            int SALT_CPF_SUM_ASII = 0 ;

            for(int i = 0; i < CPFX.Length; i++)
            {
                SALT_CPF_SUM_ASII += Convert.ToInt16(CPFX[i]);

            }
            return SALT_CPF_SUM_ASII;
        }

    }
}
