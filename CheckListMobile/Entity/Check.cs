using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckVTR.Entity
{
    public class Check
    {

        public string Tatico { get; set; }
        public string CodTatico { get; set; }
        public string Area { get; set; }
        public string Placa { get; set; }
        public string KmInicial { get; set; }
        public string Obs { get; set; }

        public int Oleo { get; set; }
        public int Combustivel { get; set; }
        public int P90 { get; set; }
        public int Retrovisores { get; set; }
        public int Farois { get; set; }
        public int Ferramentas { get; set; }
        public int Pneu { get; set; }
        public int Lanternas { get; set; }
        public int Pintura { get; set; }
        public int Documento { get; set; }
        public int Chave { get; set; }
        public int suporte { get; set; }
        public int carregador { get; set; }

        public List<Chave> Chaves = new List<Entity.Chave>();





    }
}
