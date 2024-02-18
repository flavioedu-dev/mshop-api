using System.ComponentModel.DataAnnotations;

namespace mshop_api.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [StringLength(150, ErrorMessage = "Tamanho máximo de 150 caracteres.")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Tamanho máximo de 150 caracteres.")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Tamanho mínimo de {2} e máximo de {1} caracteres.")]
        public string Password { get; set; }
    }
}
