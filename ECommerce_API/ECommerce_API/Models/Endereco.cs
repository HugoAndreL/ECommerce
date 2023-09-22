using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public required int Id_Endereco { get; set; }
        [Required]
        public required int EstoqueId { get; set; }
        public virtual Estoque? Estoque { get; set; }
        [Required(ErrorMessage = "*O campo 'CEP do Endereço' se faz necessário!")]
        [StringLength(20, ErrorMessage = "O campo 'CEP do Endereço' só pode conter 20 caractéres.")]
        public required string CEP_Endereco { get; set; }
        [StringLength(60, ErrorMessage = "O campo 'Descrição do Endereço' só pode conter 60 caractéres.")]
        public string? Desc_Endereco { get; set; }
    }
}
