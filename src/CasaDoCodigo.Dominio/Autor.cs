using System;

namespace CasaDoCodigo.Dominio
{
    public class Autor : Entidade
    {
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Descricao { get; private set; }

        private Autor(Guid id, string nome, string email, string descricao) : base()
        {
            Id = id;
            Nome = nome;
            Email = email;
            Descricao = descricao;
        }

        public static Autor Criar(string nome, string email, string descricao)
        {
            return new Autor(Guid.NewGuid(), nome, email, descricao);
        }

        public static Autor Restaurar(Guid id, string nome, string email, string descricao)
        {
            return new Autor(id, nome, email, descricao);
        }

    }
}
