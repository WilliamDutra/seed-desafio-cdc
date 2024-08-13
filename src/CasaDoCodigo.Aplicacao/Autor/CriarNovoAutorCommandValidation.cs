using System;
using FluentValidation;

namespace CasaDoCodigo.Aplicacao.Autor
{
    public class CriarNovoAutorCommandValidation : AbstractValidator<CriarNovoAutorCommand>
    {
        public CriarNovoAutorCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do autor é obrigatório!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório!");

            RuleFor(x => x.Email)
                .Must(ValidaEmail)
                .WithMessage("O e-mail é inválido!");

            RuleFor(x => x.Descricao)
                .MaximumLength(400)
                .WithMessage("A descrição não pode ser maior que 400 caracteres!");

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("A descrição é obrigatória!");

        }

        private bool ValidaEmail(string arg)
        {
            return arg.Contains("@");
        }
    }
}
