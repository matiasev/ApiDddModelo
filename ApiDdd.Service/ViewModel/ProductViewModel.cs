using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Service.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public bool Status { get; set; }
    }
}
