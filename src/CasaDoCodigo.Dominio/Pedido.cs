using System;

namespace CasaDoCodigo.Dominio
{
    public class Pedido
    {
        public decimal Total { get; private set; }

        public Guid Id { get; private set; }

        public int Quantidade { get; private set; }

        public decimal Preco { get; private set; }

        public Pedido(Guid id, int quantidade, decimal preco)
        {
            Id = id;
            Quantidade = quantidade;
            Preco = preco;
            Total = Quantidade * Preco;
        }
    }
}
