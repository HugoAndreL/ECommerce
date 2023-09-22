using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.FonecedorDTO
{
    /// <summary>
    ///     Modelo para Adição de Fornecedores
    /// </summary>
    public class CreateFornecedorDTO
    {
        // Img_Fornecedor 1-1
        [Required(ErrorMessage = "*O campo 'Nome' se faz obrigatório!")]
        public required string Nome_Fornecedor { get; set; }
        public string? Desc_Fornecedor { get; set; }
        [Required(ErrorMessage = "*O campo 'Contato' se faz obrigatório!")]
        public required string Contato_Fornecedor { get; set; }
        public string? Social_Fornecedor { get; set; }
        // Categoria_Fornecedor 1-n
        [Required]
        public required int EstoqueId { get; set; }
        // Avaliações_Fornecedor 1-n
    }
}
