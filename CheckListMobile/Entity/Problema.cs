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

namespace CheckListMobile.Entity
{
    public class Problema
    {
        public int Id { get; set; }
        public DateTime DataInsert { get; set; }
        public string Usuario { get; set; }
        public int Resolvido { get; set; }
        public string CheckList{ get; set; }
        public string Placa { get; set; }
        public string Descricao { get; set; }
        public string UsuarioResolveu { get; set; }
        public DateTime DataResolveu { get; set; }
        public string Manutencao { get; set; }
        public string Comentario { get; set; }

    }
}