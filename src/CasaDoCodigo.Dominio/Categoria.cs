using System;

namespace CasaDoCodigo.Dominio
{
    public class Categoria : Entidade
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        private Categoria(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public static Categoria Criar(string nome, string descricao)
        {
            return new Categoria(Guid.NewGuid(), nome, descricao);
        }

        public static Categoria Restaurar(Guid id, string nome, string descricao)
        {
            return new Categoria(id, nome, descricao);
        }

    }
}
