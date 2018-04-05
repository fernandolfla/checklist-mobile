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
    class CheckListDAO : Connection
    {

        public DataTable ListaChaves()
        {
            try
            {
                CriarConexao();
                Abrir();

                SqlDataAdapter Cmd = new SqlDataAdapter("SP_ListaChaves", con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

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



        public DataTable Cadastra(Check c, int usuario) 
        {
            try
            {
                CriarConexao();
                Abrir();
                SqlDataAdapter Cmd;

                Cmd = new SqlDataAdapter("SP_CadastraCheckList", con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.NText).Value = usuario;
                Cmd.SelectCommand.Parameters.Add("@TATICO", SqlDbType.NText).Value = c.Tatico;
                Cmd.SelectCommand.Parameters.Add("@AREA", SqlDbType.Int).Value = c.Area;
                Cmd.SelectCommand.Parameters.Add("@PLACA", SqlDbType.VarChar).Value = c.Placa;
                Cmd.SelectCommand.Parameters.Add("@KMINICIAL", SqlDbType.VarChar).Value = c.KmInicial;
                Cmd.SelectCommand.Parameters.Add("@OLEO", SqlDbType.Int).Value = c.Oleo;
                Cmd.SelectCommand.Parameters.Add("@COMBUSTIVEL", SqlDbType.Int).Value = c.Combustivel;
                Cmd.SelectCommand.Parameters.Add("@P90", SqlDbType.Int).Value = c.P90;
                Cmd.SelectCommand.Parameters.Add("@RETROVISORES", SqlDbType.Int).Value = c.Retrovisores;
                Cmd.SelectCommand.Parameters.Add("@FAROIS", SqlDbType.Int).Value = c.Farois;
                Cmd.SelectCommand.Parameters.Add("@FERRAMENTAS", SqlDbType.Int).Value = c.Ferramentas;
                Cmd.SelectCommand.Parameters.Add("@PNEU", SqlDbType.Int).Value = c.Pneu;
                Cmd.SelectCommand.Parameters.Add("@LANTERNAS", SqlDbType.Int).Value = c.Lanternas;
                Cmd.SelectCommand.Parameters.Add("@PINTURA", SqlDbType.Int).Value = c.Pintura;
                Cmd.SelectCommand.Parameters.Add("@DOCUMENTO", SqlDbType.Int).Value = c.Documento;
                Cmd.SelectCommand.Parameters.Add("@CHAVE", SqlDbType.Int).Value = c.Chave;
                Cmd.SelectCommand.Parameters.Add("@SUPORTE", SqlDbType.Int).Value = c.suporte;
                Cmd.SelectCommand.Parameters.Add("@CARREGADOR", SqlDbType.Int).Value = c.carregador;
                Cmd.SelectCommand.Parameters.Add("@OBS", SqlDbType.NText).Value = c.Obs;

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



        public DataTable Cadastra_Chaves(Chave c, int checkID, int usuario)
        {
            try
            {
                CriarConexao();
                Abrir();
                SqlDataAdapter Cmd;

                Cmd = new SqlDataAdapter("SP_CadastraCheckList_Chaves", con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = usuario;
                Cmd.SelectCommand.Parameters.Add("@CHECKID", SqlDbType.VarChar).Value = checkID;
                Cmd.SelectCommand.Parameters.Add("@CHAVEID", SqlDbType.VarChar).Value = c.Id;
                Cmd.SelectCommand.Parameters.Add("@CHAVENOME", SqlDbType.VarChar).Value = c.Nome;
                Cmd.SelectCommand.Parameters.Add("@CHECK", SqlDbType.VarChar).Value = c.Check;
                


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

        public DataTable Cadastra_Finaliza(string km, string obs, int usuario)
        {
            try
            {
                CriarConexao();
                Abrir();
                SqlDataAdapter Cmd;

                Cmd = new SqlDataAdapter("SP_CadastraCheckList_Finaliza", con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = usuario;
                Cmd.SelectCommand.Parameters.Add("@KM", SqlDbType.VarChar).Value = km;
                Cmd.SelectCommand.Parameters.Add("@OBS", SqlDbType.NText).Value = obs;
                //Cmd.SelectCommand.Parameters.Add("@CHECK", SqlDbType.VarChar).Value = check;

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
