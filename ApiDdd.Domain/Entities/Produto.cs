using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Domain.Entities
{
    public class Produto 
    {
        public int ProdutoId { get; private set; }

        public string Nome { get; private set; }

        public int Quantidade { get; private set; }

        public bool Status { get; private set; }

        protected Produto() { }

        public Produto(string nome, int quantidade, bool status)
        {
            Nome = nome;
            Quantidade = quantidade;
            Status = status;
        }
    }
}