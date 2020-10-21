using System.ComponentModel.DataAnnotations;

namespace Nyous.Api.DTO
{
    public class Register
    {
        [Required(ErrorMessage = "Informe o Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
    }
}
