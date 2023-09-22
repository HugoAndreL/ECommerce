using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    /// <summary>
    ///     Modelo base para os Fornecedores
    /// </summary>
    public class Fornecedor
    {
        [Key]
        [Required]
        public required int Id_Fornecedor { get; set; }
        // Img_Fornecedor 1-1
        [Required(ErrorMessage = "*O campo 'Nome' se faz obrigatório!")]
        public required string Nome_Fornecedor { get; set; }
        public string? Desc_Fornecedor { get; set; }
        [Required(ErrorMessage = "*O campo 'Contato' se faz obrigatório!")]
        [StringLength(30, ErrorMessage = "O campo 'Contato deve conter 11 caractéres'")]
        public required string Contato_Fornecedor { get; set; }
        public string? Social_Fornecedor { get; set; }
        public virtual ICollection<Produto>? Produtos_Fornecedor { get; set; }
        // Categoria_Fornecedor 1-n
        [Required]
        public required int EstoqueId { get; set; }
        public virtual Estoque? Estoque { get; set; }
        // Avaliações_Fornecedor 1-n
    }
}
