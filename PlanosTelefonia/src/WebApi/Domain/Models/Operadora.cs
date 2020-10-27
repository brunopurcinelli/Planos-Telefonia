using System;
using System.Collections;
using System.Collections.Generic;
using WebApi.Domain.Core.Models;

namespace WebApi.Domain.Models
{
    public class Operadora : Entity
    {
        public Operadora(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // Empty constructor for EF
        public Operadora() { }

        public string Nome { get; private set; }

        public ICollection<Plano> Planos{ get; set; }
    }
}
