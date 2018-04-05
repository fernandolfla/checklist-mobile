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
    class CadVeiculosBLL
    {
        public bool Cadastra(Veiculo c)
        {
            if (!string.IsNullOrEmpty(c.Placa))
                if (c.Placa.Length > 6)
                    if (!string.IsNullOrEmpty(c.Modelo))
                        if (!string.IsNullOrEmpty(c.Km))
                            if(!string.IsNullOrEmpty(c.ProxTroca))
                                if(!string.IsNullOrEmpty(c.TrocaPadrao))
                                    {

                                        CadVeiculosDAO DAO = new CadVeiculosDAO();
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




        public Veiculo BuscaProx(Veiculo c)
        {

            CadVeiculosDAO DAO = new CadVeiculosDAO();
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
                                c = DataToUsuario(Result, c);
                                return c;
                            }
                        }
                }
            return null;
        }


        public Veiculo BuscaAnt(Veiculo c)
        {
            CadVeiculosDAO DAO = new CadVeiculosDAO();
            DataTable Result = new DataTable();

            Result = DAO.BuscaAnt(c);

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
                    Result = DAO.BuscaAnt(c);
                    if (Result != null)
                        if (Result.Rows.Count > 0)
                        {
                            if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                            {
                                c = DataToUsuario(Result, c);
                                return c;
                            }
                        }
                }
            return null;
        }


        private Veiculo DataToUsuario(DataTable data, Veiculo c)
        {

            c.Id = data.Rows[0].ItemArray[0].ToString();
            c.Placa = data.Rows[0].ItemArray[1].ToString();
            c.Modelo= data.Rows[0].ItemArray[2].ToString();
            c.Km = data.Rows[0].ItemArray[3].ToString();
            c.UltimaTroca = data.Rows[0].ItemArray[4].ToString();
            c.ProxTroca = data.Rows[0].ItemArray[5].ToString();
            c.TrocaPadrao = data.Rows[0].ItemArray[6].ToString();

            return c;
        }



    }
}
