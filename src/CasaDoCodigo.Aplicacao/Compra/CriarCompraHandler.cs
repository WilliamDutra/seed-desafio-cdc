using CasaDoCodigo.Dominio;
using System;

namespace CasaDoCodigo.Aplicacao.Compra
{
    public class CriarCompraHandler
    {
        private IAutorRepositorio _autorRepositorio;

        public CriarCompraHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public CommandResult Handle(CriarCompraCommand command)
        {

            var validator = new CriarCompraCommandValidation();
            var validate = validator.Validate(command);

            if (!validate.IsValid)
                return new CommandResult(false, string.Join(",", validate.Errors.Select(x => x.ErrorMessage)));

            if (command.Pedidos.Count() == 0)
                return new CommandResult(false, "Não existe nenhum livro dentro do seu pagamento!");

            var cupomValido = _autorRepositorio.ObterCupomPorNome(command.Cupom);

            if (cupomValido == null)
                return new CommandResult(false, "Cupom inválido!");

            var documento = new Documento(command.Cpf);
            var endereco = new Endereco(command.Endereco, command.Cep, command.Cidade, command.Estado, command.Pais, command.Complemento);
            var compra = new Dominio.Compra(command.Email, command.Nome, command.Sobrenome, documento, endereco, command.Telefone);
            
            foreach (var pedido in command.Pedidos)
            {
                var livroEncontrado = _autorRepositorio.ObterLivroPorId(pedido.Id);
                compra.AdicionarPedido(pedido.Quantidade, livroEncontrado.Preco, livroEncontrado.Id);
            }

            compra.AplicarCupom(cupomValido);

            _autorRepositorio.Salvar(compra);

            return new CommandResult(true, "pagamento registrado com sucesso!");
        }
    }
}
