using System;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Dominio
{
    public class Compra : Entidade
    {
        public string Email { get; private set; }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public Documento Documento { get; private set; }

        public Endereco Endereco { get; private set; }

        public string Telefone { get; private set; }

        private List<Pedido> _Pedidos = new List<Pedido>();

        public IReadOnlyCollection<Pedido> Pedidos => _Pedidos;

        public Cupom Cupom { get; private set; }

        public decimal Total => Pedidos.Sum(x => x.Total) - (Pedidos.Sum(x => x.Total) * Cupom.Valor);

        public Compra(string email, string nome, string sobrenome, Documento documento, Endereco endereco, string telefone)
        {
            Email = email;
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Endereco = endereco;
            Telefone = telefone;
        }

        public void AdicionarPedido(int quantidade, decimal preco, Guid id)
        {
            var item = new Pedido(id, quantidade, preco);
            _Pedidos.Add(item);
        }

        public void AplicarCupom(Cupom cupom)
        {
            Cupom = cupom;
        }

    }
}
