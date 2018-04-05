using CheckVTR.DAO;
using CheckVTR.Seguranca;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckVTR.BLL
{
    public class LoginBLL
    {

        public string VerificaUsuario(string usuario)
        {
            if (!string.IsNullOrEmpty(usuario) || !usuario.Equals(""))
            {
                int CodUsuario = Convert.ToInt32(usuario);

                LoginDAO DAO = new LoginDAO();

                DataTable Usuario = DAO.VerificaUsuario(CodUsuario);
                if (Usuario != null)
                    if (Usuario.Rows.Count > 0)
                    {
                        return Usuario.Rows[0].ItemArray[1].ToString();

                    }

            }
            return "";
        }

        public int Logar(string usuario, string senha )
        {

            if (!string.IsNullOrEmpty(usuario) || !usuario.Equals("")) //4
            {
                    if (!string.IsNullOrEmpty(senha) || !senha.Equals("")) //2
                    {
                        int CodUsuario = Convert.ToInt32(usuario);

                        LoginDAO DAO = new LoginDAO();

                        DataTable Usuario = DAO.EfetuaLogin(CodUsuario, senha);
                        if (Usuario != null)
                            if (Usuario.Rows.Count > 0) 
                            {
                            try { Autenticacao.Login(Convert.ToInt32(usuario), Usuario.Rows[0].ItemArray[1].ToString(), Usuario.Rows[0].ItemArray[2].ToString(), Convert.ToInt32(Usuario.Rows[0].ItemArray[3])); }
                            catch (Exception) { return 2; }

                            return 1;
                            }
                        return 3;
                    }
                    return 2;
            }
            return 4;
        }



    }
}
