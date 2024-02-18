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
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a sua senha.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Tamanho mínimo de {2} e máximo de {1} caracteres.")]
        public string Password { get; set; }
    }
}
