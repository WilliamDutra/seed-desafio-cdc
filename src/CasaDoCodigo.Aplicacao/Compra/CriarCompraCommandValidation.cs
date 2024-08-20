using System;
using FluentValidation;

namespace CasaDoCodigo.Aplicacao.Compra
{
    public class CriarCompraCommandValidation : AbstractValidator<CriarCompraCommand>
    {
        public CriarCompraCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório!");

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .WithMessage("O sobrenome é obrigatório!");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("O cpf/cnpj é obrigatório!");

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .WithMessage("O endereço é obrigatório!");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .WithMessage("A cidade é obrigatório!");

            RuleFor(x => x.Pais)
                .NotEmpty()
                .WithMessage("O país é obrigatório!");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("O telefone é obrigatório!");

        }
    }
}
