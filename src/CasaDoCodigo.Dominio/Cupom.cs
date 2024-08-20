using System;

namespace CasaDoCodigo.Dominio
{
    public class Cupom : Entidade
    {
        public string Nome { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime Validade { get; private set; }

        private Cupom(Guid id, string nome, decimal valor, DateTime validade)
        {
            Id = id;
            Nome = nome;
            Valor = valor;

            if (validade <= DateTime.Now)
                throw new Exception("A data de validade do cupom tem quer ser maior que a data de hoje!");

            Validade = validade;
        }

        public static Cupom Criar(string nome, decimal valor, DateTime validade)
        {
            return new Cupom(Guid.NewGuid(), nome, valor, validade);
        }

        public static Cupom Restaurar(Guid id, string nome, decimal valor, DateTime validade)
        {
            return new Cupom(id, nome, valor, validade);
        }

    }
}
