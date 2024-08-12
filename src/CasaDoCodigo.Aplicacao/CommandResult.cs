using System;

namespace CasaDoCodigo.Aplicacao
{
    public class CommandResult
    {
        public bool Sucesso { get; private set; }

        public string Mensagem { get; private set; }

        public CommandResult(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }
}
