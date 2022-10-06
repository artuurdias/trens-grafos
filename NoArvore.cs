using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trem1
{
    class NoArvore<Dado> : IComparable<NoArvore<Dado>> where Dado : IComparable<Dado>
    {
        // DESENVOLVEDORES DO PROGRAMA
        // Artur Dias de Oliveira - 20124
        // Gustavo Waki Teles     - 20137

        int indice;
        Dado info;
        NoArvore<Dado> esq;
        NoArvore<Dado> dir;

        public NoArvore(int indice, Dado informacao)
        {
            this.indice = indice;
            this.Info = informacao;
            this.esq = null;
            this.dir = null;
        }

        public NoArvore(int indice, Dado dados, NoArvore<Dado> esquerdo, NoArvore<Dado> direito)
        {
            this.indice = indice;
            this.Info = dados;
            this.Esq = esquerdo;
            this.Dir = direito;
        }

        public NoArvore(NoArvore<Dado> no)
        {
            this.Indice = no.Indice;
            this.Info = no.Info;
            this.Esq = no.Esq;
            this.Dir = no.Dir;
        }


        public int Indice { get => indice; set => indice = value; }
        public Dado Info { get => info; set => info = value; }
        public NoArvore<Dado> Esq { get => esq; set => esq = value; }
        public NoArvore<Dado> Dir { get => dir; set => dir = value; }

        public int CompareTo(NoArvore<Dado> o)
        {
            return info.CompareTo(o.info);
        }

        public bool Equals(NoArvore<Dado> o)
        {
            return this.info.Equals(o.info);
        }
    }
}
