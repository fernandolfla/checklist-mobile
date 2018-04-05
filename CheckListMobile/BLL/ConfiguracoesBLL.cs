using CheckVTR.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckVTR.BLL
{
    class ConfiguracoesBLL
    {

        public DataTable ListaAtivos()
        {
            ConfiguracoesDAO DAO = new ConfiguracoesDAO();
            DataTable Result = new DataTable();

            Result = DAO.ListaAtivos();
            if (Result != null)
                if (Result.Rows.Count > 0)
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                        return Result;

            return null;
        }

    }
}
