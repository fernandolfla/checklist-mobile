using CheckVTR.Component;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace CheckVTR.DAO
{
    class LoginDAO : Connection
    {
        public DataTable VerificaUsuario(int codUsuario)
        {
            try
            {
                CriarConexao();
                Abrir();
                SqlDataAdapter Cmd = new SqlDataAdapter("SP_ConsultaUsuarioLogin", con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = codUsuario;


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

        public DataTable EfetuaLogin(int usuario, string senha)
        {

            try
            {
                CriarConexao();
                Abrir();
                SqlDataAdapter Cmd = new SqlDataAdapter("SP_EfetuaLogin", con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = usuario;
                Cmd.SelectCommand.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = senha;


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
