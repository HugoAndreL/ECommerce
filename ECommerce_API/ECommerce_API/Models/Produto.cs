using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    /// <summary>
    ///     Modelo base para os Produtos
    /// </summary>
    public class Produto
    {
        [Key]
        [Required]
        public required int Id_Prod { get; set; }
        public virtual ICollection<ImgProd>? Imgs_Prod { get; set; }
        [Required(ErrorMessage = "*O campo 'Código de Barras do Produto' se faz obrigatório!")]
        [StringLength(12, ErrorMessage = "O campo 'Código de Barras do Produto' deve ter 12 caractéres.")]
        public required string CodeBar_Prod { get; set; }
        [Required(ErrorMessage = "*O campo 'Nome do Produto' se faz obrigatório!")]
        public required string Name_Prod { get; set; }
        [Required]
        public required int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
        [Required(ErrorMessage = "*O campo 'Valor do Produto' se faz obrigatório!")]
        [Range(0.01, 999999.99, ErrorMessage = "O campo 'Valor do Produto' deve ter pelo menos 0.01 à 999999.99.")]
        public required double Val_Prod { get; set; }
        [Required]
        public required int EstoqueId { get; set; }
        public virtual Estoque? Estoque_Prod { get; set; }
        [Required]
        public required int FornecedorId { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }
        public virtual ICollection<Avaliacao>? Avalicoes_Prod { get; set; }
        public virtual ICollection<ProdComp>? Compras_Prod { get; set; }
        public virtual ICollection<HistoricoProd>? Historicos_Prod { get; set; }
    }
}
