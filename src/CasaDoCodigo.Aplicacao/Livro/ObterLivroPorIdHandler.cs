using CasaDoCodigo.Dominio;
using System;

namespace CasaDoCodigo.Aplicacao.Livro
{
    public class ObterLivroPorIdHandler
    {
        private IAutorRepositorio _autorRepositorio;

        public ObterLivroPorIdHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public Dominio.Livro Handle(ObterLivroPorIdQuery query)
        {
            return _autorRepositorio.ObterLivroPorId(query.Id);
        }
    }
}
