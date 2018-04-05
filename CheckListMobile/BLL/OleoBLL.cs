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
    class OleoBLL
    {

        public List<Veiculo> ListaVeiculos()
        {
            OleoDAO DAO = new OleoDAO();

            DataTable Result = new DataTable();
            Result = DAO.ListaVeiculos();

            if (Result != null)
                if (Result.Rows.Count > 0)
                {
                    List<Veiculo> C = new List<Veiculo>();
                    try
                    {
                        foreach (DataRow linha in Result.Rows)
                        {
                            Veiculo c = new Veiculo();
                            c.Id = linha.ItemArray[0].ToString();
                            c.Placa = linha.ItemArray[1].ToString();
                            c.Modelo = linha.ItemArray[2].ToString();
                            c.Km = linha.ItemArray[3].ToString();
                            c.UltimaTroca = linha.ItemArray[4].ToString();
                            c.ProxTroca= linha.ItemArray[5].ToString();
                            c.TrocaPadrao = linha.ItemArray[6].ToString();
                            try { c.Situacao = Convert.ToInt32(linha.ItemArray[7]); } catch { c.Situacao = 0; }            

                            C.Add(c);
                        }

                    }
                    catch (Exception) { return null; }
                    return C;
                }
            return null;
        }



        public bool Cadastra(OleoBD c)
        {
            if (!string.IsNullOrEmpty(c.Placa))
                if (c.Placa.Length > 6)
                    if (!string.IsNullOrEmpty(c.Km))
                        if (!string.IsNullOrEmpty(c.Local))
                        {
                            OleoDAO DAO = new OleoDAO();
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










    }
}
