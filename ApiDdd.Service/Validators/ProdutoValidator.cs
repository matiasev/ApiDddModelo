using ApiDdd.Domain.Entities;
using ApiDdd.Service.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Service.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("É necessário informar o nome.")
                .NotNull().WithMessage("É necessário informar o nome");
        }
    }
}
