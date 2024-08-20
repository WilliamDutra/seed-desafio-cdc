using System;

namespace CasaDoCodigo.Aplicacao.Compra
{
    public class CriarCompraCommand
    {
        public string Email { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public Guid Estado { get; set; }

        public Guid Pais { get; set; }

        public string Telefone { get; set; }

        public string Cep { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public string Cupom { get; set; }

        public CriarCompraCommand()
        {
            Pedidos = new List<Pedido>();
        }

        public class Pedido
        {
            public Guid Id { get; set; }

            public int Quantidade { get; set; }
        }

    }
}
