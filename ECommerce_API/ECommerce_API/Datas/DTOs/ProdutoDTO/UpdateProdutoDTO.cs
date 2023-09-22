using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.ProdutoDTO
{
    /// <summary>
    ///     Modelo de Atualização de Produtos das 2 maneiras (PATCH E PUT)
    /// </summary>
    public class UpdateProdutoDTO
    {
        [Required(ErrorMessage = "*O campo 'Código de Barras do Produto' se faz obrigatório!")]
        [StringLength(12, ErrorMessage = "O campo 'Código de Barras do Produto' deve ter 12 caractéres.")]
        public required string CodeBar_Prod { get; set; }
        [Required(ErrorMessage = "*O campo 'Nome do Produto' se faz obrigatório!")]
        public required string Name_Prod { get; set; }
        // Category_Prod 1-1
        [Required(ErrorMessage = "*O campo 'Valor do Produto' se faz obrigatório!")]
        [Range(0.01, 999999.99, ErrorMessage = "O campo 'Valor do Produto' deve ter pelo menos 0.01 à 999999.99.")]
        public required double Val_Prod { get; set; }
    }
}
