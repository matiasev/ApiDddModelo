using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Service.ViewModel
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public bool Status { get; set; }
    }
}
