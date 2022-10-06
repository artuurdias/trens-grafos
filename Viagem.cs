using System;
using System.IO;
using static System.Environment;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Trem1
{
    class Viagem : IComparable<Viagem>, IRegistro
    {
        private const int tamanhoNomeOrigem = 15;
        private const int tamanhoNomeDestino = 15;
        private const int tamanhoDistancia = 3;
        private const int tamanhoPreco = 3;

        private string nomeOrigem, nomeDestino;
        private string preco, distancia;

        private const int tamanhoRegistro = tamanhoNomeDestino + tamanhoNomeOrigem
                                            + tamanhoDistancia + 3 + tamanhoPreco;

        public Viagem()
        {
            NomeOrigem = "";
            NomeDestino = "";
            Distancia = "";
            Preco = "";
        }

        public Viagem(string nomeOrigem, string nomeDestino, string distancia, string preco)
        {
            NomeOrigem = nomeOrigem;
            NomeDestino = nomeDestino;
            Distancia = distancia;
            Preco = preco;
        }

        public string NomeOrigem { get => nomeOrigem; set => nomeOrigem = value.PadRight(tamanhoNomeOrigem, ' ').Substring(0, tamanhoNomeOrigem); }
        public string NomeDestino { get => nomeDestino; set => nomeDestino = value.PadRight(tamanhoNomeDestino, ' ').Substring(0, tamanhoNomeDestino); }
        public string Distancia { get => distancia; set => distancia = value.PadRight(tamanhoDistancia, ' ').Substring(0, tamanhoDistancia); }
        public string Preco { get => preco; set => preco = value.PadRight(tamanhoPreco, ' ').Substring(0, tamanhoPreco); }

        public int CompareTo(Viagem v) => String.Compare(this.ToString().Trim(), 0, v.ToString().Trim(), 0, tamanhoRegistro, new CultureInfo("en-US"), CompareOptions.IgnoreCase);

        public override string ToString()
        {
            return NomeOrigem + NomeDestino + " " + Distancia + "  " + Preco;
        }


        public int TamanhoRegistro => tamanhoRegistro;

        public void LerRegistro(string[] vetor, long qualRegistro)
        {
            string linha = vetor[qualRegistro];
            NomeOrigem = linha.Substring(0, tamanhoNomeOrigem);
            NomeDestino = linha.Substring(tamanhoNomeOrigem, tamanhoNomeDestino);
            Distancia = linha.Substring(tamanhoNomeDestino + tamanhoNomeOrigem + 1, tamanhoDistancia);
            Preco = linha.Substring(tamanhoNomeDestino + tamanhoNomeOrigem + tamanhoDistancia + 3, tamanhoPreco);
                    
        }

        public void GravarRegistro(StreamWriter arquivo)
        {
            arquivo.WriteLine(this.ToString());
        }
    }
}
