using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Domain.Entities
{
    public class Product 
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int Amount { get; private set; }

        public bool Status { get; private set; }

        protected Product() { }

        public Product(string name, int amount, bool status)
        {
            Name = name;
            Amount = amount;
            Status = status;
        }
    }
}