using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Infra.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
    }
}
