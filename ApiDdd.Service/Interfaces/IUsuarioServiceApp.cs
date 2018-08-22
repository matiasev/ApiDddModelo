using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Entities.Admin;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUsuarioServiceApp
    {
        void Add(UsuarioViewModel obj);

        LoginViewModel GetByUser(LoginViewModel obj);
    }
}
