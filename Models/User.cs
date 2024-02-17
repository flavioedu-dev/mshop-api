using System.ComponentModel.DataAnnotations;

namespace mshop_api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o seu nome.")]
        [StringLength(150, ErrorMessage = "Tamanho máximo de 150 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o seu email.")]
        [StringLength(150, ErrorMessage = "Tamanho máximo de 150 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a sua senha.")]
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
        public string Password { get; set; }
    }
}
