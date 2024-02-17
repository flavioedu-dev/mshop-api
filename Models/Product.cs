using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mshop_api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o local da compra.")]
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
        public string Place { get; set; }

        [Column(TypeName = "Decimal(10, 2)")]
        public decimal TotalValue { get; set; }

        public int Amount { get; set; }
    }
}
