using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CheckVTR.BLL;
using CheckVTR.Entity;
using CheckListMobile.DAO;
using System.Data;
using CheckListMobile.Entity;
using CheckVTR.Seguranca;

namespace CheckListMobile.BLL
{
    public class ProblemaBLL
    {
        
        public List<ProblemasVTR> buscar()
        {
            OleoBLL BLL = new OleoBLL();
            List<Veiculo> Veiculos = BLL.ListaVeiculos();
            List<Problema> Problemas = ListaProblemas();
            List<ProblemasVTR> ListaDeProblemas = new List<ProblemasVTR>();
            
                        

            if (Veiculos != null)
            {
                foreach(var v in Veiculos)
                {
                    ProblemasVTR p = new ProblemasVTR();
                    p.Placa = v.Placa;
                    p.VTR = v;
                    if(Problemas != null)
                        foreach (var l in Problemas)
                        {
                            if(l.Placa.Equals(p.Placa))
                            {
                                p.Problemas.Add(l);
                            }

                        }
                    ListaDeProblemas.Add(p);
                }

    
            }

            return ListaDeProblemas;
        }

        public bool Atualiza(int id, string manutencao, string comentario)
        {
            ProblemaDAO DAO = new ProblemaDAO();
            DataTable Result;
            Result = DAO.Atualiza(id, Autenticacao.GetCodUsuario(), manutencao, comentario);

            if (Result != null)
                if (Result.Rows.Count > 0)
                    if (Result.Rows[0].ItemArray[0].ToString().Equals("1"))
                        return true;
            return false;
        }

        private List<Problema> ListaProblemas()
        {
            ProblemaDAO DAO = new ProblemaDAO();
            List<Problema> Problemas = DataToEntity(DAO.LlistaProblemas());

            return Problemas;
        }

        private List<Problema> DataToEntity(DataTable data)
        {

            if (data != null)
                if (data.Rows.Count > 0)
                {
                    List<Problema> P = new List<Problema>();
                    try
                    {
                        foreach (DataRow linha in data.Rows)
                        {
                            Problema p = new Problema();
                            try { p.Id = Convert.ToInt32(linha.ItemArray[0]); } catch { }
                            try { p.DataInsert = (DateTime)linha.ItemArray[1]; } catch { }
                            try { p.Resolvido = Convert.ToInt32(linha.ItemArray[2]); } catch { }
                            try { p.CheckList = linha.ItemArray[3].ToString(); } catch { }
                            try { p.Placa = linha.ItemArray[4].ToString(); } catch { }
                            try { p.Descricao = linha.ItemArray[5].ToString(); } catch { }
                            try { p.UsuarioResolveu = linha.ItemArray[6].ToString(); } catch { }
                            try { p.DataResolveu = (DateTime)linha.ItemArray[7]; } catch { }
                            try { p.Manutencao = linha.ItemArray[8].ToString(); } catch { }
                            try { p.Comentario = linha.ItemArray[9].ToString(); } catch { }
                            try { p.Usuario = linha.ItemArray[10].ToString(); } catch { }


                            P.Add(p);
                        }

                    }
                    catch (Exception) { return null; }

                    return P;
                }
            return null;
        }

    }
}