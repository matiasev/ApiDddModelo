using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioViewModel>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("É necessário informar o nome.")
                .NotNull().WithMessage("É necessário informar o nome");
        }
    }
}
