using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mshop_api.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título da compra.")]
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Informe o local da compra.")]
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
        public string Place { get; set; }

        [Column(TypeName = "Decimal(10, 2)")]
        public decimal TotalValue { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
