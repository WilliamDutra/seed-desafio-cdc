using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Dominio
{
    public interface IAutorRepositorio
    {
        void Salvar(Autor autor);

        Autor? ObterPorEmail(string email);

        void Salvar(Categoria categoria);

        Categoria? ObterCategoriaPorNome(string nome);

        void Salvar(Livro livro);

        List<Livro> ObterLivroPorNome(string nome);

        List<Livro> ObterTodosOsLivros();

        Livro? ObterLivroPorId(Guid id);

        void Salvar(Estado estado);

        void Salvar(Pais pais);

        Pais? ObterPaisPorNome(string nome);

        Pais? ObterPaisPorId(Guid id);

        Cupom? ObterCupomPorNome(string nome);

        void Salvar(Cupom cupom);

    }
}
