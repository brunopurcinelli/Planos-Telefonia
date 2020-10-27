using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Core.Models;

namespace WebApi.Domain.Models
{
    public class Plano : Entity
    {
        public Plano(Guid id, string nome, string minutos, string franquiaInternet, decimal valor, TipoPlano tipo)
        {
            Id = id;
            Nome = nome;
            Minutos = minutos;
            FranquiaInternet = franquiaInternet;
            Valor = valor;
            Tipo = tipo;
        }

        // Empty constructor for EF
        protected Plano() { }

        public string Nome { get; private set; }
        public string Minutos { get; private set; }
        public string FranquiaInternet { get; private set; }
        public decimal Valor { get; private set; }
        public TipoPlano Tipo { get; private set; }
        public Operadora Operadora { get; private set; }
    }
    public enum TipoPlano
    {
        Controle = 0,
        PosPago = 1,
        Prepago = 2
    }
}
