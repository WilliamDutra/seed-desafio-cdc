using System;

namespace CasaDoCodigo.Dominio
{
    public abstract class Entidade
    {
        public Guid Id { get; protected set; }

        public DateTime CriadoEm { get; private set; }

        public Entidade()
        {
            CriadoEm = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
