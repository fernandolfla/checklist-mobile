using CheckVTR.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckVTR.BLL
{
    class RelatoriosBLL
    {

       public DataTable RelatorioChecklist(DateTime inicio)
        {
            RelatoriosDAO DAO = new RelatoriosDAO();
            DataTable Result = new DataTable();

            Result = DAO.RelatorioChecklist(inicio);
            if (Result != null)
                if (Result.Rows.Count > 0)
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                        return Result;

            return null;
        }

        public DataTable RelatorioOleo(string oleo)
        {
            RelatoriosDAO DAO = new RelatoriosDAO();
            DataTable Result = new DataTable();

            Result = DAO.RelatorioOleo(oleo);
            if (Result != null)
                if (Result.Rows.Count > 0)
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                        return Result;

            return null;
        }

        public DataTable RelatorioManutencao(string oleo)
        {
            RelatoriosDAO DAO = new RelatoriosDAO();
            DataTable Result = new DataTable();

            Result = DAO.RelatorioManutencao(oleo);
            if (Result != null)
                if (Result.Rows.Count > 0)
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                        return Result;

            return null;
        }

        public DataTable RelatorioChecklist_Chaves(int id)
        {
            RelatoriosDAO DAO = new RelatoriosDAO();
            DataTable Result = new DataTable();

            Result = DAO.RelatorioChecklist_Chaves(id);
            if (Result != null)
                if (Result.Rows.Count > 0)
                    if (!Result.Rows[0].ItemArray[0].ToString().Equals("-1"))
                        return Result;

            return null;
        }

    }
}
