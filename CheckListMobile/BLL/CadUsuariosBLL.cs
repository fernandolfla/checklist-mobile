using CheckVTR.DAO;
using CheckVTR.Entity;
using CheckVTR.Seguranca;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckVTR.BLL
{
    class CadUsuariosBLL
    {

        public bool Cadastra(Usuario user)
        {
            if(!string.IsNullOrEmpty(user.Apelido))
                if (user.Apelido.Length > 0)
                    if(!string.IsNullOrEmpty(user.Nome))
                        if(user.Nome.Length > 3)
                            if(!string.IsNullOrEmpty(user.Senha))
                            {

                                CadUsuariosDAO DAO = new CadUsuariosDAO();
                                DataTable Result = new DataTable();

                                Result = DAO.Cadastra(user, Autenticacao.GetCodUsuario());
                                if (Result != null)
                                    if (Result.Rows.Count > 0)
                                        if (Result.Rows[0].ItemArray[0].ToString().Equals("1"))
                                            return true;
                                        else return false;
                            }


            return false;
        }




        public Usuario BuscaProx(Usuario user)
        {

            CadUsuariosDAO DAO = new CadUsuariosDAO();
            DataTable Result = new DataTable();

            Result = DAO.BuscaProx(user);

            if (Result != null)
                if (Result.Rows.Count > 0)
                {
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                    {
                        user = DataToUsuario(Result, user);
                        return user;
                    }
                    else return null;
                }
                else
                {
                    user.Id = null;
                    Result = DAO.BuscaProx(user);
                    if (Result != null)
                        if (Result.Rows.Count > 0)
                        {
                            if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                            {
                                user = DataToUsuario(Result, user);
                                return user;
                            }
                        }
                }
            return null;
        }


        public Usuario BuscaAnt(Usuario user)
        {
            CadUsuariosDAO DAO = new CadUsuariosDAO();
            DataTable Result = new DataTable();

            Result = DAO.BuscaAnt(user);

            if (Result != null)
                if (Result.Rows.Count > 0)
                {
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                    {
                        user = DataToUsuario(Result, user);
                        return user;
                    }
                    else return null;
                }
                else
                {
                    user.Id = null;
                    Result = DAO.BuscaAnt(user);
                    if (Result != null)
                        if (Result.Rows.Count > 0)
                        {
                            if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                            {
                                user = DataToUsuario(Result, user);
                                return user;
                            }
                        }
                }
            return null;
        }


        private Usuario DataToUsuario(DataTable data, Usuario user)
        {
           
             user.Id = data.Rows[0].ItemArray[0].ToString();
            user.Nome = data.Rows[0].ItemArray[1].ToString();
            user.Apelido = data.Rows[0].ItemArray[2].ToString();
            return user;
        }





    }
}
