using System;

namespace CasaDoCodigo.Dominio
{
    public class Estado : Entidade
    {
        public string Nome { get; private set; }

        public string Sigla { get; private set; }

        public Guid PaisId { get; private set; }

        private Estado(Guid id, string nome, string sigla, Guid paisId)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
            PaisId = paisId;
        }

        public static Estado Criar(string nome , string sigla, Guid paisId)
        {
            return new Estado(Guid.NewGuid(), nome, sigla, paisId);
        }

        public static Estado Restaurar(Guid id, string nome, string sigla, Guid paisId)
        {
            return new Estado(id, nome, sigla, paisId);
        }

    }
}
