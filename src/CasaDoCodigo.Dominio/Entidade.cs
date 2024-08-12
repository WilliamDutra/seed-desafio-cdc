using System;

namespace CasaDoCodigo.Dominio
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }

        public DateTime CriadoEm { get; private set; }

        public Entidade()
        {
            CriadoEm = DateTime.Now;
            Id = new Guid();
        }
    }
}
