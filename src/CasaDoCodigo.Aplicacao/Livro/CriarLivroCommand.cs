using System;

namespace CasaDoCodigo.Aplicacao.Livro
{
    public class CriarLivroCommand 
    {
        public string Isbn { get; set; }

        public string Titulo { get; set; }

        public string Resumo { get; set; }

        public string Sumario { get; set; }

        public int NumeroDePaginas { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataPublicacao { get; set; }

        public Guid AutorId { get; set; }

        public Guid CategoriaId { get; set; }
    }
}
