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
    class ManutencaoBLL
    {

        public bool Cadastra(ManutencaoBD c)
        {
            if (!string.IsNullOrEmpty(c.Placa))
                if (c.Placa.Length > 6)
                    if (!string.IsNullOrEmpty(c.KM))
                        if (!string.IsNullOrEmpty(c.Local))
                            if (!string.IsNullOrEmpty(c.Descricao))
                                if (!string.IsNullOrEmpty(c.Valor))
                                {
                                        ManutencaoDAO DAO = new ManutencaoDAO();
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
