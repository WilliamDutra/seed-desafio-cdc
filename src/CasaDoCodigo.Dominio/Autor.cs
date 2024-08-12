using System;

namespace CasaDoCodigo.Dominio
{
    public class Autor : Entidade
    {
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Descricao { get; private set; }

        public Autor(string nome, string email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;
        }
    }
}
