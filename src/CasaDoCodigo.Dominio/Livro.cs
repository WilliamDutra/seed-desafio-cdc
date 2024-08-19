using System;

namespace CasaDoCodigo.Dominio
{
    public class Livro : Entidade
    {
        public string Isbn { get; private set; }

        public string Titulo { get; set; }

        public string Resumo { get; private set; }

        public string Sumario { get; private set; }

        public decimal Preco { get; private set; }

        public int NumeroDePaginas { get; private set; }

        public DateTime DataPublicacao { get; private set; }

        public Guid CategoriaId { get; private set; }

        public Guid AutorId { get; private set; }

        private Livro(Guid id, string isbn, string titulo, string resumo, string sumario, decimal preco, int numeroDePagina, DateTime dataPublicacao, Guid categoriaId, Guid autorId)
        {
            Id = id;
            Isbn = isbn;
            Titulo = titulo;
            Resumo = resumo;
            Sumario = sumario;
            Preco = preco;
            NumeroDePaginas = numeroDePagina;
            DataPublicacao = dataPublicacao;
            CategoriaId = categoriaId;
            AutorId = autorId;
        }

        public static Livro Criar(string isbn, string titulo, string resumo, string sumario, decimal preco, int numeroDePagina, DateTime dataPublicacao, Guid categoriaId, Guid autorId)
        {
            return new Livro(Guid.NewGuid(), isbn, titulo, resumo, sumario, preco, numeroDePagina, dataPublicacao, categoriaId, autorId);
        }

        public static Livro Restaurar(Guid id, string isbn, string titulo, string resumo, string sumario, decimal preco, int numeroDePagina, DateTime dataPublicacao, Guid categoriaId, Guid autorId) 
        {
            return new Livro(id, isbn, titulo, resumo, sumario, preco, numeroDePagina, dataPublicacao, categoriaId, autorId);
        }

    }
}
