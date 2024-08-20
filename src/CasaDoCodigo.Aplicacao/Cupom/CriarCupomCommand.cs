using System;

namespace CasaDoCodigo.Aplicacao.Cupom
{
    public class CriarCupomCommand
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime Validade { get; set; }
    }
}
