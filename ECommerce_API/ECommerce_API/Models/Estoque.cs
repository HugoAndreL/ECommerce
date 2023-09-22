using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    /// <summary>
    ///     Modelo de base para os Estoque
    /// </summary>
    public class Estoque
    {
        [Key]
        [Required]
        public required int Id_Estoque { get; set; }
        public virtual ICollection<Produto>? Produtos_Estoque { get; set; }
        [Required(ErrorMessage = "*O campo 'Quantidade do Estoque' se faz necessário!")]
        public required int Quant_Estoque { get; set; }
        public virtual Endereco? Endereço_Estoque { get; set; }
        public virtual ICollection<Fornecedor>? Fornecedores_Estoque { get; set; }
    }
}
