using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApi.Domain.Models;

namespace WebApi.Application.ViewModels
{
    public class PlanoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "The Minute is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Minutos")]
        public string Minutos { get; set; }

        [Required(ErrorMessage = "The Minute is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Franquia de Internet")]
        public string FranquiaInternet { get; set; }

        [Required(ErrorMessage = "The Amount is Required")]
        [DisplayName("Nome")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "The Type is Required")]
        [DisplayName("Tipo do Plano")]
        public TipoPlano Tipo { get; set; }

        public OperadoraViewModel Operadora { get; set; }
    }
}
