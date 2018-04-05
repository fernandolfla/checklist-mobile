using CheckVTR.Component;
using CheckVTR.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckVTR.DAO
{
    class ManutencaoDAO : Connection
    {
        public DataTable Cadastra(ManutencaoBD c, int usuario)
        {
            try
            {
                CriarConexao();
                Abrir();
                SqlDataAdapter Cmd;

                Cmd = new SqlDataAdapter("SP_CadastraManutencao", con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = usuario;
                Cmd.SelectCommand.Parameters.Add("@PLACA", SqlDbType.VarChar).Value = c.Placa;
                Cmd.SelectCommand.Parameters.Add("@KM", SqlDbType.VarChar).Value = c.KM;
                Cmd.SelectCommand.Parameters.Add("@DESCRICAO", SqlDbType.VarChar).Value = c.Descricao;
                Cmd.SelectCommand.Parameters.Add("@LOCAL", SqlDbType.VarChar).Value = c.Local;
                Cmd.SelectCommand.Parameters.Add("@VALOR", SqlDbType.VarChar).Value = c.Valor.Replace(",",".").Trim();

                DataTable data = new DataTable();

                Cmd.Fill(data);
                Fechar();
                return data;

            }
            catch (Exception e)
            {
                Erros.SetErroBanco(e);
                Erros.SetHaErro(true);
            }
            finally
            {
                Fechar();
            }
            return null;
        }




    }
}
