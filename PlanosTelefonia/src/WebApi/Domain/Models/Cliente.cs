using System;
using WebApi.Domain.Core.Models;

namespace WebApi.Domain.Models
{
    public class Cliente : Entity
    {
        public Cliente(Guid id, string nome, string ddd, string numero)
        {
            Id = id;
            Nome = nome;
            DDD = ddd;
            Numero = numero;
        }

        public Cliente() { }

        public string Nome { get; private set; }
        public string DDD { get; private set; }
        public string Numero { get; private set; }
    }
}
