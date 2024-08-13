using System;

namespace CasaDoCodigo.Dominio
{
    public interface IAutorRepositorio
    {
        void Salvar(Autor autor);

        Autor? ObterPorEmail(string email);
    }
}
