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
    class CadChavesBLL
    {


        public bool Cadastra(Chave c)
        {
            if(!string.IsNullOrEmpty(c.Id))
                if (c.Id.Length == 4 )
                    if (!string.IsNullOrEmpty(c.Nome))
                        if (c.Nome.Length > 0)
                           if (!string.IsNullOrEmpty(c.Area.ToString()))
                            {

                               CadChavesDAO DAO = new CadChavesDAO();
                                DataTable Result = new DataTable();

                                Result = DAO.Cadastra(c, Autenticacao.GetCodUsuario());
                                if (Result != null)
                                    if (Result.Rows.Count > 0)
                                        if (Result.Rows[0].ItemArray[0].ToString().Equals("1"))
                                            return true;
                                        else return false;
                            }


            return false;
        }




        public Chave BuscaProx(Chave c)
        {

            CadChavesDAO DAO = new CadChavesDAO();
            DataTable Result = new DataTable();

            Result = DAO.BuscaProx(c);

            if (Result != null)
                if (Result.Rows.Count > 0)
                {
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                    {
                        c = DataToUsuario(Result, c);
                        return c;
                    }
                    else return null;
                }
                else
                {
                    c.Id = null;
                    Result = DAO.BuscaProx(c);
                    if (Result != null)
                        if (Result.Rows.Count > 0)
                        {
                            if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                            {
                                c = DataToUsuario(Result,c);
                                return c;
                            }
                        }
                }
            return null;
        }


        public Chave BuscaAnt(Chave c)
        {
            CadChavesDAO DAO = new CadChavesDAO();
            DataTable Result = new DataTable();

            Result = DAO.BuscaAnt(c);

            if (Result != null)
                if (Result.Rows.Count > 0)
                {
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                    {
                        c= DataToUsuario(Result, c );
                        return c;
                    }
                    else return null;
                }
                else
                {
                    c.Id = null;
                    Result = DAO.BuscaAnt(c);
                    if (Result != null)
                        if (Result.Rows.Count > 0)
                        {
                            if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                            {
                                c = DataToUsuario(Result,c);
                                return c;
                            }
                        }
                }
            return null;
        }

        public bool Apaga(string cod)
        {

            CadChavesDAO DAO = new CadChavesDAO();
            if (!string.IsNullOrEmpty(cod))
            {

                DataTable Result = new DataTable();

                Result = DAO.Apaga(cod);
                if (Result != null)
                    if (Result.Rows.Count > 0)
                        if (Result.Rows[0].ItemArray[0].ToString().Equals("1"))
                            return true;
            }
            return false;
        }


        private Chave DataToUsuario(DataTable data, Chave c)
        {

            c.Id = data.Rows[0].ItemArray[0].ToString();
            c.Nome = data.Rows[0].ItemArray[1].ToString();
            c.Area = data.Rows[0].ItemArray[2].ToString();
            return c;
        }



    }
}
