using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Dominio
{
    public class Pais : Entidade
    {
        public string Nome { get; private set; }

        public string Sigla { get; private set; }

        private List<Estado> _Estados = new List<Estado>();

        public List<Estado> Estados => _Estados;

        private Pais(Guid id, string nome, string sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }

        public static Pais Criar(string nome, string sigla)
        {
            return new Pais(Guid.NewGuid(), nome, sigla);
        }

        public static Pais Restaurar(Guid id, string nome, string sigla)
        {
            return new Pais(id, nome, sigla);
        }

        public void AdicionarEstado(string nome, string sigla)
        {
            _Estados.Add(Estado.Criar(nome, sigla, Id));
        }

    }
}
