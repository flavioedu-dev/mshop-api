using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mshop_api.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
        public string Name { get; set; }

        [Column(TypeName = "Decimal(10, 2)")]
        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
