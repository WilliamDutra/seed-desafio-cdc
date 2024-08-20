using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Dominio
{
    public class Endereco
    {
        public string Logradouro { get; private set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public Guid? EstadoId { get; private set; }

        public Guid PaisId { get; private set; }

        public string Complemento { get; private set; }

        public Endereco(string logradouro, string cep, string cidade, Guid? estadoId, Guid paisId, string complemento)
        {
            Logradouro = logradouro;
            Cep = cep;
            Cidade = cidade;
            EstadoId = estadoId;
            PaisId = paisId;
            Complemento = complemento;
        }
    }
}
