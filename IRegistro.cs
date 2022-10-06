using System;
using System.IO;
interface IRegistro
{
    void LerRegistro(string[] vetor, long qualRegistro);
    void GravarRegistro(StreamWriter arquivo);
    int TamanhoRegistro { get; }
}