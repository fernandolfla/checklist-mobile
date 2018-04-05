using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckVTR.Entity
{
    public class Veiculo
    {
        public string Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Km { get; set; }
        public string UltimaTroca { get; set; }
        public string ProxTroca { get; set; }
        public string TrocaPadrao{ get; set; }
        public int Situacao { get; set; }


    }
}
