using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckVTR.Seguranca
{
    static class Autenticacao
    {
        static int CodUsuario;
        static string NomeUsuario;
        static string Apelido;
        static int UltimoCheckList;

        static string Serial;
        static string Versao;
        static string Atualizacao;

        static string Servidor;

        static int Situacao;




        public static void Login(int codUsuario, string nomeUsuario, string apelido, int situacao)
        {

            CodUsuario = codUsuario;
            NomeUsuario = nomeUsuario;
            Apelido = apelido;
            Situacao = situacao;

            Serial = "Juriseg v.0.1";
            Versao = "Check-List VTR";
            Atualizacao = "Beta.v.0.01";

        }

        public static void SetUsuario(int codUsuario)
        {
            CodUsuario = codUsuario;
        }
        public static int GetUltimoCheckList()
        {
            return UltimoCheckList;
        }
        public static int GetSituacaoUsuario()
        {
            return Situacao;
        }
        public static string GetNomeUsuario()
        {
            return NomeUsuario;
        }

        public static int GetCodUsuario()
        {
            return CodUsuario;
        }
        public static string GetApelido()
        {
            return Apelido;
        }

        public static string GetVersao()
        {
            return Versao;
        }
        public static string GetAtualizacao()
        {
            return Atualizacao;
        }
        public static string GetSerial()
        {
            return Serial;
        }

        public static void SetServidor(string servidor)
        {
            Servidor = servidor;
        }
        public static string GetServidor()
        {
            return Servidor;
        }
    }
}
