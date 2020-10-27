using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.ViewModels
{
    public class ClienteViewModel
    {

        public ClienteViewModel() { }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "The DDD is Required")]
        [DisplayName("DDD")]
        public string DDD { get; set; }

        [Required(ErrorMessage = "The Number is Required")]
        [DisplayName("Número")]
        public string Numero{ get; set; }
    }
}
