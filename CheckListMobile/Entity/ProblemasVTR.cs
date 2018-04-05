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
using CheckVTR.Entity;

namespace CheckListMobile.Entity
{
    public class ProblemasVTR
    {
        public string Placa { get; set; }
        public Veiculo VTR { get; set; }
        public List<Problema> Problemas  { get; set; }

        public ProblemasVTR()
        {
            Problemas = new List<Problema>();
        }


    }
}