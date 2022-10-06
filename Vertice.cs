using System;

namespace Trem1
{
    class Vertice
    {
        // DESENVOLVEDORES DO PROGRAMA
        // Artur Dias de Oliveira - 20124
        // Gustavo Waki Teles     - 20137

        private Cidade cidade;
        private bool visitado;

        public Vertice(Cidade cidade)
        {
            this.cidade = cidade;
            visitado = false;
        }

        public bool Visitado { get => visitado; set => visitado = value; }
        public Cidade Cidade { get => cidade; set => cidade = value; }
    }
}
