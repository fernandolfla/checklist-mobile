using System.Data.SqlClient;

namespace CheckVTR.DAO
{
    class Connection
    {
        public SqlConnection con = null;

        private string _conexao;
        public Connection()
        {
           _conexao = "Data Source=177.92.18.155;Initial Catalog=VTR;Integrated Security=FALSE;User ID=sa;Password=masterkey;Connect Timeout=30";
            //_conexao = "Data Source=177.92.18.155;Initial Catalog=VTR;Integrated Security=FALSE;User ID=sa;Password=masterkey;Connect Timeout=30";
        }

        public void CriarConexao()
        {
       
                con = new SqlConnection(_conexao);

        }
        public void Abrir()
        {

            if (con != null)
            {
                con.Close();
                con.Open();
            }
            else
                con.Open();
        }

        public void Fechar()
        {
            con.Close();
        }


    }
}
