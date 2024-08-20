using System;

namespace CasaDoCodigo.Dominio
{
    public class Documento
    {
        public string Numero { get; private set; }

        public Documento(string numero)
        {
            Numero = numero;
        }
    }
}
