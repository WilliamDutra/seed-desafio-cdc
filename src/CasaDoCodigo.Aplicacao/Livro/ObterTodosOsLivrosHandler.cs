using System;
using CasaDoCodigo.Dominio;

namespace CasaDoCodigo.Aplicacao.Livro
{
    public class ObterTodosOsLivrosHandler
    {
        private IAutorRepositorio _autorRepositorio;

        public ObterTodosOsLivrosHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public List<Dominio.Livro> Handle(ObterTodosOsLivrosQuery query)
        {
            return _autorRepositorio.ObterTodosOsLivros();
        }

    }
}
