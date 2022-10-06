using System;
using System.Collections.Generic;
using static System.Environment;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Trem1
{
    class Cidade : IComparable<Cidade>, IRegistro
    {
        private const int tamanhoNome = 15;
        private const int tamanhoX = 5;
        private const int tamanhoY = 5;

        private string nome;
        private string coordenadaX, coordenadaY;

        private const int tamanhoRegistro = tamanhoNome + tamanhoX
                                                + tamanhoY + 2;

        public Cidade ()
        {
            Nome = "";
            CoordenadaX = "";
            CoordenadaY = "";
        }
        public Cidade (Cidade modelo)
        {
            Nome = modelo.Nome;
            CoordenadaX = modelo.CoordenadaX;
            CoordenadaY = modelo.CoordenadaY;
        }
        public Cidade (string nome, string coordenadaX, string coordenadaY)
        {
            Nome = nome;
            CoordenadaX = coordenadaX;
            CoordenadaY = coordenadaY;
        }
        public Cidade (string nome)
        {
            Nome = nome;
        }

        public string Nome { get => nome; set => nome = value.PadRight(tamanhoNome, ' ').Substring(0, tamanhoNome); }
        public string CoordenadaX { get => coordenadaX; set => coordenadaX = value.PadRight(tamanhoX, ' ').Substring(0, tamanhoX); }
        public string CoordenadaY { get => coordenadaY; set => coordenadaY = value.PadRight(tamanhoY, ' ').Substring(0, tamanhoY); }

        public int CompareTo(Cidade c) => String.Compare(nome, 0, c.nome, 0, 15, new CultureInfo("en-US"), CompareOptions.IgnoreCase);
        
        public override string ToString()
        {
            return Nome + " " + CoordenadaX + " " + CoordenadaY;
        }

        public int TamanhoRegistro => tamanhoRegistro;

        public void LerRegistro(string[] vetor, long qualRegistro)
        {
            string linha = vetor[qualRegistro];
            Nome = linha.Substring(0, tamanhoNome);
            CoordenadaX = linha.Substring(tamanhoNome + 1, tamanhoX);
            CoordenadaY = linha.Substring(tamanhoNome + tamanhoX + 2, tamanhoY);
        }

        public void GravarRegistro(StreamWriter arquivo)
        {
            arquivo.WriteLine(this.ToString());
        }
    }
}
