using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public required int Id_Cat { get; set; }
        [Required(ErrorMessage = "*O campo 'Nome da Categoria' se faz necessário!")]
        [StringLength(30, ErrorMessage = "O campo 'Nome da Categoria' só pode conter 30 caractéres.")]
        public required string Name_Cat { get; set; }
        public string? Desc_Cat { get; set; }
        public virtual ICollection<Produto>? Produtos_Cat { get; set; }
    }
}
